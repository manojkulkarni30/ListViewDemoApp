using ListViewDemoApp.Models;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewDemoApp.ViewModels
{
    public class ListViewSample2ViewModel : BaseViewModel
    {
        #region Fields

        private ICommand _selectedItem;

        #endregion

        #region Properties

        public ObservableCollection<ChatModel> Chats { get; set; }

        #endregion

        #region Commands

        public ICommand SelectedItemCommand => _selectedItem ?? (_selectedItem = new Command<ChatModel>(async (ChatModel chatModel) => await ViewDetailsAsync(chatModel)));

        #endregion

        #region Constructor

        public ListViewSample2ViewModel()
        {
            Chats = new ObservableCollection<ChatModel>()
            {
                new ChatModel
                {
                    Photo = "http://www.maisopiniao.com/wp-content/uploads/bola_futebol-150x150.jpg",
                    SentFrom = "Luiz Pereira:",
                    CreatedAt = DateTimeOffset.Now,
                    Message = "O jogo ficou confirmado para quarta??",
                    MessageIcon = string.Empty,
                    IsMuted = true,
                    TotalUnread = 9
                },

                new ChatModel
                {
                    Photo = "https://i.imgflip.com/2/e4t4k.jpg",
                    SentFrom = "Luiz Pereira:",
                    CreatedAt = DateTimeOffset.Now,
                    Message = "O jogo ficou confirmado para quarta??",
                    MessageIcon = string.Empty,
                    IsMuted = true,
                    TotalUnread = 9
                },

                new ChatModel
                {
                    Photo = "http://www.georgefiorini.eu/images/ritorno-al-futuro/doc-brown.jpg",
                    SentFrom = "Luiz Pereira:",
                    CreatedAt = DateTimeOffset.Now,
                    Message = "O jogo ficou confirmado para quarta??",
                    MessageIcon = string.Empty,
                    IsMuted = true,
                    TotalUnread = 9
                },

                new ChatModel
                {
                    Photo = "http://helixholidays.com/wp-content/uploads/2016/01/family-shutter2-1-150x150.jpg",
                    SentFrom = "Luiz Pereira:",
                    CreatedAt = DateTimeOffset.Now,
                    Message = "O jogo ficou confirmado para quarta??",
                    MessageIcon = string.Empty,
                    IsMuted = true,
                    TotalUnread = 9
                },
        };
        }

        #endregion

        #region Methods


        private async Task ViewDetailsAsync(ChatModel chatModel)
        {
            await Application.Current.MainPage.DisplayAlert("List View Sample 2", "Test", "ok");
        }

        #endregion
    }
}
