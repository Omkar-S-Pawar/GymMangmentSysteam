using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DAL.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
         public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        // One to Many
        public virtual ICollection<User> Users { get; set; }
    }
}
