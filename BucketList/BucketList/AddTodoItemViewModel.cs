using System;
using Xamarin.Forms;

namespace BucketList
{
    class AddTodoItemViewModel : BaseFodyObservable
    {

        public AddTodoItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
            CommentSave = new Command(HandleCommentSave);
            CommentCancel = new Command(HandleCommentCancel);

        }

        private INavigation _navigation;
        public string TodoTitle { get; set; }

        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.TodoRepository.AddItem(new TodoItem { Title = TodoTitle });
            await _navigation.PopModalAsync();
        }
        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }

        public string TodoComment { get; set; }
        public Command CommentSave { get; set; }
        public async void HandleCommentSave()
        {
            if (TodoTitle == null)
            {
                await App.TodoRepository.AddItem(new TodoItem { Title = "Пустая цель" });
                await _navigation.PopModalAsync();
            }
            if (TodoTitle != null && TodoComment != null)
            {
                await App.TodoRepository.AddItem(new TodoItem { Title = TodoTitle + Environment.NewLine + "        \"" + TodoComment + "\"" });
                await _navigation.PopModalAsync();
            }
            if (TodoTitle != null && TodoComment == null)
            {
                await App.TodoRepository.AddItem(new TodoItem { Title = TodoTitle});
                await _navigation.PopModalAsync();
            }
        }
        public Command CommentCancel { get; set; }
        public async void HandleCommentCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}
