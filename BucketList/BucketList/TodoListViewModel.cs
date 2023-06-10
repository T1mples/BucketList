using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BucketList
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
            AddItem = new Command(HandleAddItem);
            Comment = new Command<TodoItem>(HandleComment);
            Edit = new Command<TodoItem>(HandleEdit);

        }

        private INavigation _navigation;
        public Command AddItem { get; set; }
        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AddTodoItem());
        }
        public Command<TodoItem> Delete { get; set; }
        public async void HandleDelete(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItem(itemToDelete);
            GroupedTodoList = await GetGroupedTodoList();
        }
        //
        public Command<TodoItem> Edit { get; set; }
        public async void HandleEdit(TodoItem itemToEdit)
        {
            await App.TodoRepository.DeleteItem(itemToEdit);
            await _navigation.PushModalAsync(new AddTodoItem());
        }
        //
        //
        public Command<TodoItem> Comment { get; set; }
        public async void HandleComment(TodoItem itemToComment)
        {
            await _navigation.PushModalAsync(new MyModalPage());
        }
        //
        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public async void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            await App.TodoRepository.ChangeItemIsCompleted(itemToUpdate);
            GroupedTodoList = await GetGroupedTodoList();
        }

        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "";

        private List<TodoItem> _todoList = new List<TodoItem>
        {
            
        };

        private async Task<ILookup<string, TodoItem>> GetGroupedTodoList()
        {
            return (await App.TodoRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "Выполнено" : "Активно");
        }
        public async Task RefreshTaskList()
        {
            GroupedTodoList = await GetGroupedTodoList();
        }

    }

}
