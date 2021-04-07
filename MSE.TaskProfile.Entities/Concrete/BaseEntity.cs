using System;

namespace MSE.TaskProfile.Entities.Concrete
{
    public class BaseEntity
    {
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
