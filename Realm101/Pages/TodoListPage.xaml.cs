﻿using System;
using System.Collections.Generic;
using System.Linq;
using Realm101.Models;
using Realms;
using Xamarin.Forms;

namespace Realm101.Pages
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage(string todoListId)
        {
            InitializeComponent();

            _todoList = _realm.Find<TodoList>(todoListId);
            TodosListView.ItemsSource = _todoList.Todos.OrderBy(todo => todo.DueDate).AsRealmCollection();
        }

        void AddToolbarItem_Clicked(object sender, System.EventArgs e) => AddTodoGrid.IsVisible = true;

        void RemoveMenuitem_Clicked(object sender, System.EventArgs e)
        {
            var todo = (sender as MenuItem)?.CommandParameter as Todo;
            if (todo != null)
            {
                _realm.Write(() => _realm.Remove(todo));
            }
        }

        void AddTodoAddButton_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddTodoEntry.Text))
            {
                _realm.Write(() => _realm.Add(new Todo { Title = AddTodoEntry.Text, DueDate = AddTodoDatePicker.Date, Parent = _todoList }));
                AddTodoEntry.Text = "";
                AddTodoDatePicker.Date = DateTimeOffset.Now.Date;
                AddTodoGrid.IsVisible = false;
            }
        }

        void AddTodoCancelButton_Clicked(object sender, System.EventArgs e)
        {
                AddTodoEntry.Text = "";
                AddTodoDatePicker.Date = DateTimeOffset.Now.Date;
                AddTodoGrid.IsVisible = false;
        }

        Realm _realm = Realm.GetInstance();
        TodoList _todoList;
    }
}
