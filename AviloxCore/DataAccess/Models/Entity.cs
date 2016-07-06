using System;

namespace AviloxCore.DataAccess.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public Entity() {
            CreationDate = DateTime.UtcNow;
        }
    }
}