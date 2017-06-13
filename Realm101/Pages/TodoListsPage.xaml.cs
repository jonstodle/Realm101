using System;
using System.Collections.Generic;
using System.Linq;
using Realm101.Models;
using Realms;
using Xamarin.Forms;

namespace Realm101.Pages
{
    public partial class TodoListsPage : ContentPage
    {
        public TodoListsPage()
        {
            InitializeComponent();

            TodoListsListView.ItemsSource = _realm.All<TodoList>().OrderBy(list => list.Name).AsRealmCollection();
        }

        void AddToolbarItems_Clicked(object sender, System.EventArgs e) => AddTodoListGrid.IsVisible = true;

        async void TodoListsListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TodoListPage((e.Item as TodoList).Id));
        }

        void RemoveMenuItem_Clicked(object sender, System.EventArgs e)
        {
            var todoList = (sender as MenuItem)?.CommandParameter as TodoList;
            if (todoList != null)
            {
                _realm.Write(() => _realm.Remove(todoList));
            }
        }

        void AddTodoListAddButton_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddTodoListEntry.Text))
            {
                _realm.Write(() => _realm.Add(new TodoList { Name = AddTodoListEntry.Text }));
                AddTodoListEntry.Text = "";
                AddTodoListGrid.IsVisible = false;
            }
        }

        void AddTodoListCancelButton_Clicked(object sender, System.EventArgs e)
        {
            AddTodoListEntry.Text = "";
            AddTodoListGrid.IsVisible = false;
        }

        Realm _realm = Realm.GetInstance();
    }
}
