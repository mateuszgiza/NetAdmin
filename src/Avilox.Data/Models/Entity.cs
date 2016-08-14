using System;

namespace Avilox.Data.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ModificationCount { get; set; }

        protected Entity() {
            CreationDate = DateTime.UtcNow;
        }
    }
}