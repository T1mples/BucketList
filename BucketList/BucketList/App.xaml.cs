using BucketList.Persistence;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketList
{
    public partial class App : Application
    {
        public static TodoRepository TodoRepository = new TodoRepository();
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TodoListView());  //TodoListView          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
