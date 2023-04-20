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
        /*Ham khoi tao - Construction
        Hàm tạo của lớp Land được định nghĩa để khởi tạo các thuộc tính Steden và Talen 
        là các danh sách rỗng (new List<Stad>() và new List<Taal>()). 
        Điều này đảm bảo rằng khi một đối tượng Land mới được tạo, 
        danh sách Steden và Talen của nó sẽ không bị null, 
        mà sẽ là các danh sách trống sẵn sàng để thêm các phần tử vào.
         */
        public Land()
        {
            Steden = new List<Stad>();
            Talen = new List<Taal>();
        }
        /*Thuộc tính LandCode là một chuỗi và được đánh dấu là khóa chính ([Key]) 
         và không được sinh tự động ([DatabaseGenerated(DatabaseGeneratedOption.None)]).*/
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LandCode { get; set; }

        //Thuộc tính Naam là một chuỗi và bắt buộc phải có ([Required]).
        [Required]
        public string Naam { get; set; }

        /*thuộc tính Steden và Talen đều là danh sách (ICollection) các đối tượng của lớp Stad và Taal tương ứng. 
        Chúng được định nghĩa là các thuộc tính ảo (virtual) để Entity Framework 
        có thể thực hiện tải lười biếng (lazy-loading) dữ liệu.*/
        public virtual ICollection<Stad> Steden { get; set; }
        public virtual ICollection<Taal> Talen { get; set; }
    }
}
