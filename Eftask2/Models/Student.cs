namespace Eftask2.Models;

    public class Student:BaseEntity
    {
        public int Term { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }