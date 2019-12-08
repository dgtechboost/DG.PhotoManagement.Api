using System.Collections.Generic;

namespace DG.PhotoManagement.Data.Entities
{
    public class Album 
        : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
