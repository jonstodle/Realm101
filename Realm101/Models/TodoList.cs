using System;
using System.Collections.Generic;
using Realms;

namespace Realm101.Models
{
    public class TodoList : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public IList<Todo> Todos { get; }
    }
}
