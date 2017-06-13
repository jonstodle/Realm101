using System;
using Realms;

namespace Realm101.Models
{
    public class Task : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public Todo Parent { get; set; }
    }
}
