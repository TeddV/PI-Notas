using System.Collections.Generic;

namespace UniNotasApi.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Note> Notes { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }

    }
}