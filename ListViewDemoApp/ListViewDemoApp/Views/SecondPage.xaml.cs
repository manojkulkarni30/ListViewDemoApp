
using ListViewDemoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewDemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        #region Fields

        private readonly Story _story;

        #endregion

        #region Constructor

        public SecondPage(Story story = null)
        {
            InitializeComponent();
            _story = story;
            Title = "News Details";
        }

        public SecondPage()
        {
            InitializeComponent();
        }

        #endregion
    }
}