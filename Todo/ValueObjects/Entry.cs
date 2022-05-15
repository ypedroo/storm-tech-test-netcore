using System.Collections.Generic;

namespace Todo.ValueObjects
{
    public record Entry
    {
        public List<Photo> Photos { get; set; }
        public string DisplayName { get; set; }
    }
}