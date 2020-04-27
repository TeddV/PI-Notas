namespace UniNotasApi.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public Book Book { get; set; }
    }
}
