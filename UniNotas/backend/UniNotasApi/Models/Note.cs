using System;

namespace UniNotasApi.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string Video { get; set; }
        public string Audio { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; } 
        public long BookId { get; set; }
        public Book Book { get; set; }

    }
}