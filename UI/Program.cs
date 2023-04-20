using Microsoft.EntityFrameworkCore; 
//using Microsoft.EntityFrameworkCore;: Dòng mã này đưa vào phạm vi sử dụng namespace Microsoft.EntityFrameworkCore, chứa các lớp và phương thức để làm việc với Entity Framework Core.
using Model.Entities; 
//Dòng mã này đưa vào phạm vi sử dụng namespace Model.Entities, chứa các định nghĩa của các đối tượng thực thể (entities) trong mô hình dữ liệu.

using var context = new EFCoreTestContext();
/* Dòng mã này khởi tạo một đối tượng của lớp EFCoreTestContext, 
 đây là lớp kế thừa từ DbContext trong Entity Framework Core và đại diện cho 
đối tượng kết nối và làm việc với cơ sở dữ liệu. */
var query = from land in context.Landen
            orderby land.Naam
            select land;
/*
Dòng mã này tạo một truy vấn lấy ra danh sách các đối tượng Landen (quốc gia) 
từ đối tượng context (đối tượng DbContext). 
Sau đó, danh sách này được sắp xếp theo thuộc tính Naam của đối tượng Landen.
 */
Console.WriteLine("Landen");
Console.WriteLine("------");
foreach (var land in query) // duyệt qua từng đối tượng Landen trong danh sách được trả về từ truy vấn query và
                            // thực hiện các thao tác in ra màn hình thông tin về quốc gia, bao gồm mã quốc gia và tên quốc gia.
{
    Console.WriteLine($"{land.LandCode}: {land.Naam}");
}
Console.WriteLine("Geef een landcode in");//in ra màn hình chuỗi "Geef een landcode in", yêu cầu người dùng nhập mã quốc gia.
var landcode = Console.ReadLine(); //Dòng mã này đọc đầu vào từ người dùng là mã quốc gia được nhập từ bàn phím và gán giá trị này cho biến landcode.
var landNaam = context.Landen.Find(landcode);//Dòng mã này tìm kiếm đối tượng Landen (quốc gia) có mã quốc gia trùng khớp với giá trị của biến
                                             //landcode từ đối tượng context (đối tượng DbContext) và gán đối tượng này cho biến landNaam.
if (landNaam == null) //Dòng mã này kiểm tra nếu đối tượng Landen không được tìm thấy
                      //(landNaam == null) thì in ra màn hình chuỗi "Geef een correcte landcode in" (yêu cầu nhập lại mã quốc gia đúng).
{
    Console.WriteLine("Geef een correcte landcode in");
}
else
{
    /* Tạo một câu truy vấn queryLand dựa trên đối tượng context của lớp EFCoreTestContext.
        Câu truy vấn này sẽ lấy dữ liệu của đất nước có landcode tương ứng,
        bao gồm cả thông tin về các ngôn ngữ (Talen) và các thành phố (Steden) trong đất nước đó.
        Câu truy vấn được xây dựng bằng cách sử dụng từ khóa from, where và select của ngôn ngữ truy vấn LINQ. */
    var queryLand = from land in context.Landen.Include("Talen").Include("Steden")
                    where land == landNaam
                    select land;
    foreach (var land in queryLand)
    {   /*Sử dụng một vòng lặp foreach để duyệt qua các đối tượng land trong kết quả của câu truy vấn queryLand. 
         Đối tượng land này đại diện cho đất nước có landcode tương ứng, 
        bao gồm cả thông tin về các thành phố và ngôn ngữ trong đất nước đó.*/
        Console.WriteLine("Steden");
        foreach (var stad in land.Steden)
        {
            /*Trong vòng lặp đầu tiên, chương trình sẽ in ra màn hình thông tin về các thành phố (Steden) trong đất nước đó, 
             bằng cách duyệt qua danh sách thành phố và in ra tên của từng thành phố*/
            Console.WriteLine($"\t{stad.Naam}");//Sau khi hoàn thành vòng lặp, chương trình sẽ in ra màn hình dòng thông báo "Geef een nieuwe stad in" (Nhập tên thành phố mới).
        }
        Console.WriteLine("Talen");
        foreach (var taal in land.Talen)
        {   /* trong vòng lặp thứ hai, chương trình sẽ in ra màn hình thông tin về các ngôn ngữ (Talen) trong đất nước đó, 
             tương tự như với các thành phố.*/
            Console.WriteLine($"\t{taal.Naam}");
        }
    }
    Console.WriteLine("Geef een nieuwe stad in");
    context.Steden.Add(new Stad { Naam = Console.ReadLine(), Land = landNaam });//Chương trình sẽ đọc dữ liệu đầu vào từ người dùng bằng cách sử dụng phương thức Console.ReadLine(), và sau đó thêm một đối tượng thành phố mới vào đối tượng context.Steden. Thành phố mới này được khởi tạo với tên được nhập từ người dùng và đất nước (landNaam) tương ứng đã được lấy từ câu truy vấn trước đó.
    context.SaveChanges();//chương trình gọi phương thức context.SaveChanges() để lưu thay đổi vào cơ sở dữ liệu.
}