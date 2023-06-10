using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyModalPage : ContentPage
    {
        public MyModalPage()
        {
            InitializeComponent();
        }
        private async void OnCloseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private string entryText;

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            entryText = e.NewTextValue;
        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await App.TodoRepository.AddItemCommented(new TodoItem { Comment = "( " + entryText + " )" });
            await Navigation.PopModalAsync();
        }
    }
}