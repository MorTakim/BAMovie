using ProjectTemplate.Core.Abstractions;

namespace ProjectTemplate.Core.Entities
{
    public class Firm : IEntityKey<int>
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}