using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewDemoApp.Controls
{
    public class CustomListView : ListView
    {
        public event EventHandler SaveInstanceState;

        public event EventHandler RestoreInstanceState;

        public static readonly BindableProperty ItemTappedCommandProperty =
          BindableProperty.Create(
              nameof(ItemTappedCommand),
              typeof(ICommand),
              typeof(ListView),
              null
          );

        public ICommand ItemTappedCommand
        {
            get => (ICommand)GetValue(ItemTappedCommandProperty);
            set => SetValue(ItemTappedCommandProperty, value);
        }

        public CustomListView() : base(ListViewCachingStrategy.RecycleElement)
        {
            ItemTapped += ListView_ItemTapped;
        }

        ~CustomListView()
        {
            ItemTapped -= ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ItemTappedCommand != null && ItemTappedCommand.CanExecute(null))
            {
                ItemTappedCommand.Execute(e.Item);
            }

            SelectedItem = null;
        }


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
