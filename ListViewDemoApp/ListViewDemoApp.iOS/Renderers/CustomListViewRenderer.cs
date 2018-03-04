using CoreGraphics;
using ListViewDemoApp.Controls;
using ListViewDemoApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace ListViewDemoApp.iOS.Renderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        #region Fields

        private UITableView iosTableView;
        private CGPoint UIOffset;

        #endregion

        #region Methods

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                iosTableView = (UITableView)Control;
            }
            if (e.OldElement != null)
            {
                ((CustomListView)e.NewElement).SaveInstanceState -= CustomListViewiOS_OnSaveInstanceState;
                ((CustomListView)e.NewElement).RestoreInstanceState -= CustomListViewiOS_RestoreInstanceState;
            }
            if (e.NewElement != null)
            {
                ((CustomListView)e.NewElement).SaveInstanceState += CustomListViewiOS_OnSaveInstanceState;
                ((CustomListView)e.NewElement).RestoreInstanceState += CustomListViewiOS_RestoreInstanceState;
            }
        }

        private void CustomListViewiOS_RestoreInstanceState(object sender, System.EventArgs e)
        {
            if (UIOffset != null)
                iosTableView.SetContentOffset(UIOffset, true);
        }

        private void CustomListViewiOS_OnSaveInstanceState(object sender, System.EventArgs e)
        {
            UIOffset = iosTableView.ContentOffset;
        }

        #endregion
    }
}
