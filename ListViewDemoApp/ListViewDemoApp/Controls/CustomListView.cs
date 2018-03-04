using System;
using Xamarin.Forms;

namespace ListViewDemoApp.Controls
{
    public class CustomListView : ListView
    {
        public event EventHandler SaveInstanceState;

        public event EventHandler RestoreInstanceState;

        public void SaveState()
        {
            SaveInstanceState?.Invoke(this, EventArgs.Empty);
        }

        public void RestoreState()
        {
            RestoreInstanceState?.Invoke(this, EventArgs.Empty);
        }
    }
}
