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
        /* StadNr: đây là khóa chính của đối tượng Stad và được tự động tạo khi một đối tượng mới được thêm vào cơ sở dữ liệu. 
        Điều này được chỉ định bằng thuộc tính [Key] và [DatabaseGenerated(DatabaseGeneratedOption.Identity)]. */
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StadNr { get; set; }
        
        /*Naam: tên của thành phố. Thuộc tính này được đánh dấu là [Required], nghĩa là giá trị của nó không được để trống.*/
        [Required]
        public string Naam { get; set; }
        //LandCode: mã của quốc gia mà thành phố đó thuộc về
        public string LandCode { get; set; }
        
        /* Land: đối tượng Land tương ứng với quốc gia mà thành phố đó thuộc về. 
         Thuộc tính này được đánh dấu bằng [ForeignKey("LandCode")] để chỉ định rằng LandCode là khóa ngoại trỏ đến đối tượng Land.*/
        [ForeignKey("LandCode")]
        public virtual Land Land { get; set; }
    }
}
