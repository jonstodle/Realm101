using System;
using System.Collections.Generic;
using System.Linq;
using Realm101.Models;
using Realms;
using Xamarin.Forms;

namespace Realm101.Pages
{
    public partial class TodoPage : ContentPage
    {
        public TodoPage(string todoId)
        {
            InitializeComponent();

            BindingContext = _todo = _realm.Find<Todo>(todoId);
            Title = _todo.Title;
            TasksListView.ItemsSource = _realm.All<Task>().OrderBy(task => task.DueDate).AsRealmCollection();
        }

        void AddTaskButton_Clicked(object sender, System.EventArgs e) => AddTaskGrid.IsVisible = true;

        void DoneMenuItem_Clicked(object sender, System.EventArgs e)
        {
            var task = (sender as MenuItem)?.CommandParameter as Task;
            if (task != null)
            {
                _realm.Write(() => _realm.Remove(task));
            }
        }

        void AddTaskAddButton_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddTaskEntry.Text))
            {
                _realm.Write(() => _realm.Add(new Task { Title = AddTaskEntry.Text, DueDate = AddTaskDatePicker.Date, Details = AddTaskEditor.Text, Parent = _todo }));
                AddTaskEntry.Text = "";
                AddTaskEditor.Text = "";
                AddTaskDatePicker.Date = DateTimeOffset.Now.Date;
                AddTaskGrid.IsVisible = false;
            }
        }

        void AddTaskCancelButton_Clicked(object sender, System.EventArgs e)
        {
            AddTaskEntry.Text = "";
            AddTaskEditor.Text = "";
            AddTaskDatePicker.Date = DateTimeOffset.Now.Date;
            AddTaskGrid.IsVisible = false;
        }

        Realm _realm = Realm.GetInstance();
        Todo _todo;
    }
}
