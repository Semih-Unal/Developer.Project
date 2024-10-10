using Core.Entities;

namespace Entities.Concrete
{
    public class Form : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string Fields { get; set; }
    }
}
