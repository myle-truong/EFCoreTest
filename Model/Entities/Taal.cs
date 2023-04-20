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
        /*Dòng code public Taal() là constructor (hàm khởi tạo) của lớp Taal. 
         Nó được gọi khi một đối tượng mới của lớp Taal được tạo ra.
        Trong constructor này, một danh sách rỗng được khởi tạo cho thuộc tính Landen của đối tượng Taal. 
        Điều này đảm bảo rằng một đối tượng Taal mới luôn có một danh sách rỗng cho thuộc tính Landen, 
        tránh trường hợp lỗi khi chưa có bất kỳ phần tử nào trong danh sách này.
         */
        public Taal()
        {
            Landen = new List<Land>();
        }

        /* TaalCode: đây là mã định danh cho ngôn ngữ. 
        Thuộc tính này được đánh dấu là [Key], nghĩa là nó là khóa chính của đối tượng Taal, 
        và [DatabaseGenerated(DatabaseGeneratedOption.None)] để chỉ định rằng giá trị của nó sẽ không được tự động tạo ra 
        và phải được cung cấp bởi người dùng.*/
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TaalCode { get; set; }

        // tên của ngôn ngữ. Thuộc tính này được đánh dấu là [Required], nghĩa là giá trị của nó không được để trống.
        [Required]
        public string Naam { get; set; }
        /* Landen: một ICollection của đối tượng Land tương ứng với các quốc gia nó được sử dụng. 
         Đây là một quan hệ nhiều-nhiều giữa Taal và Land, một ngôn ngữ có thể được sử dụng trong nhiều quốc gia 
        và một quốc gia cũng có thể sử dụng nhiều ngôn ngữ.
         */
        public virtual ICollection<Land> Landen { get; set; }
    }
}
