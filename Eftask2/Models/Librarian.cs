using MaterialDesignThemes.Wpf;

namespace Eftask2.Models;

    public class Librarian:BaseEntity
    {
        public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<S_Cards> S_Cards { get; set; }
}