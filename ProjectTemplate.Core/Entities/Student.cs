using ProjectTemplate.Core.Abstractions;

namespace ProjectTemplate.Core.Entities
{
    public class Student : IEntityKey<int>
    { 
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; } 
    }
}