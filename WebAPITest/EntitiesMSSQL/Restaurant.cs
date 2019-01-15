using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Entities
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FoundedDate { get; set; }
        [Column(TypeName = "jsonb")]
        public string JsonData { get; set; }
        public int stars { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
    }
}
