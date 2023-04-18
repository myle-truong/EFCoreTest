using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Taal
    {
        public Taal()
        {
            Landen = new List<Land>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TaalCode { get; set; }
        [Required]
        public string Naam { get; set; }
        public virtual ICollection<Land> Landen { get; set; }
    }
}
