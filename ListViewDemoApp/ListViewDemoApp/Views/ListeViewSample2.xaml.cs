using ListViewDemoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewDemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeViewSample2 : ContentPage
    {
        #region Fields

        private readonly ListViewSample2ViewModel listViewSample2ViewModel;

        #endregion

        #region Constructor

        public ListeViewSample2()
        {
            InitializeComponent();
            BindingContext = listViewSample2ViewModel = new ListViewSample2ViewModel();
        }

        #endregion
    }
}