using MSE.TaskProfile.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSE.TaskProfile.Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long ID { get; set; }
        [Required(ErrorMessage = "User must have name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User must have surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "User must have birthday")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "User must have address")]
        public string Address { get; set; }

        public User()
        {
            this.CreatedDate = DateTime.Now;
            this.LastModifiedDate = DateTime.Now;
        }
    }
}
