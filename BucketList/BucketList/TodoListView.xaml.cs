﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {
        public TodoListView()
        {
            InitializeComponent();
            BindingContext = new TodoListViewModel(Navigation);
            //TodoListViewModel
            //MyModalPage
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as TodoListViewModel).RefreshTaskList();
        }

    }

}