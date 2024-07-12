namespace Eftask2.Models;

    public class Author:BaseEntity
    {
        public string  Name { get; set; }
        public string  LastName { get; set; }
        public List<Book> Books { get; set; }
    }