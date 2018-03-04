using Android.Content;
using Android.OS;
using ListViewDemoApp.Controls;
using ListViewDemoApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace ListViewDemoApp.Droid.Renderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        #region Fields

        private Android.Widget.ListView androidListView;
        private IParcelable state;

        #endregion

        #region Constructor

        public CustomListViewRenderer(Context context) : base(context)
        {
        }

        #endregion

        #region Methods

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (Control != null)
                {
                    androidListView = Control;
                }
                if (e.OldElement != null)
                {
                    ((CustomListView)e.OldElement).SaveInstanceState -= OnSaveInstanceState;
                    ((CustomListView)e.OldElement).RestoreInstanceState -= OnRestoreInstanceState;
                }
                if (e.NewElement != null)
                {
                    ((CustomListView)e.NewElement).SaveInstanceState += OnSaveInstanceState;
                    ((CustomListView)e.NewElement).RestoreInstanceState += OnRestoreInstanceState;
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void OnRestoreInstanceState(object sender, System.EventArgs e)
        {
            if (state != null)
            {
                androidListView.OnRestoreInstanceState(state);
            }
        }

        private void OnSaveInstanceState(object sender, System.EventArgs e)
        {
            state = androidListView.OnSaveInstanceState();
        }

        #endregion

    }
}