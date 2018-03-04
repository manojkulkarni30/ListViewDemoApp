using ListViewDemoApp.Models;
using ListViewDemoApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewDemoApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields

        private readonly HackerNewsApiService _hackerNewsApiService;
        private ICommand _refreshCommand;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            _hackerNewsApiService = new HackerNewsApiService();

        }

        #endregion

        #region Properties

        private ObservableRangeCollection<Story> _topStories;

        public ObservableRangeCollection<Story> TopStories
        {
            get => _topStories;
            set => SetProperty(ref _topStories, value);
        }

        #endregion

        #region Command

        public ICommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new Command(async () => await ExecuteRefreshCommandAsync()));

        #endregion

        #region Utility Methods

        private Task<List<string>> GetTopStoryIdsAsync() =>
            _hackerNewsApiService.GetDataAsync<List<string>>("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty");

        private Task<Story> GetStoryInfoAsync(string storyId) =>
            _hackerNewsApiService.GetDataAsync<Story>($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json?print=pretty");

        private async Task<List<Story>> GetTopStoriesAsync(int numberOfStories)
        {
            var topStoryIds = await GetTopStoryIdsAsync().ConfigureAwait(false);

            var getTop20StoriesTaskList = new List<Task<Story>>();
            for (int i = 0; i < numberOfStories; i++)
            {
                getTop20StoriesTaskList.Add(GetStoryInfoAsync(topStoryIds[i]));
            }

            await Task.WhenAll(getTop20StoriesTaskList).ConfigureAwait(false);

            var topStoryList = new List<Story>();
            foreach (var getStoryTask in getTop20StoriesTaskList)
            {
                Story item = await getStoryTask.ConfigureAwait(false);
                item.Description = $"{item.Score} points by {item.By}";
                topStoryList.Add(item);
            }

            TopStories = new ObservableRangeCollection<Story>();
            TopStories.AddRange(topStoryList);

            return topStoryList.OrderByDescending(x => x.Score).ToList();
        }

        #endregion

        #region Methods

        public async Task ExecuteRefreshCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await GetTopStoriesAsync(80).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
