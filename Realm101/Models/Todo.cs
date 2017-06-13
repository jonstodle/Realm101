using System;
using System.Linq;
using Realms;

namespace Realm101.Models
{
    public class Todo : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public TodoList Parent { get; set; }
        [Backlink(nameof(Task.Parent))]
        public IQueryable<Task> Tasks { get; }
    }
}
