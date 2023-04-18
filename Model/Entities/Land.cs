using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Land
    {
        public Land()
        {
            Steden = new List<Stad>();
            Talen = new List<Taal>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LandCode { get; set; }
        [Required]
        public string Naam { get; set; }
        public virtual ICollection<Stad> Steden { get; set; }
        public virtual ICollection<Taal> Talen { get; set; }
    }
}
