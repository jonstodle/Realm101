using System;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace Realm101.Models
{
    public class TodoList : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        [Backlink(nameof(Todo.Parent))]
        public IQueryable<Todo> Todos { get; }
    }
}
