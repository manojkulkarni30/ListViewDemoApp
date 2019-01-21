using ListViewDemoApp.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ListViewDemoApp.Views
{
    public partial class MainPage : ContentPage
    {
        #region Fields

        private readonly MainPageViewModel mainPageViewModel;

        #endregion

        #region Constructor

        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainPageViewModel = new MainPageViewModel();
        }

        #endregion

        #region Methods

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await mainPageViewModel.ExecuteRefreshCommandAsync().ConfigureAwait(false);
                Device.BeginInvokeOnMainThread(() => newsListView.ItemsSource = mainPageViewModel.TopStories);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() => newsListView.RestoreState());
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            newsListView.SaveState();
            mainPageViewModel.TopStories.Clear();
            mainPageViewModel.TopStories = null;
        }

        #endregion
    }
}
