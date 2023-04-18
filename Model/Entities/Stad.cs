using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Stad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StadNr { get; set; }
        [Required]
        public string Naam { get; set; }
        public string LandCode { get; set; }
        [ForeignKey("LandCode")]
        public virtual Land Land { get; set; }
    }
}
