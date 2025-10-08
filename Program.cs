using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
namespace demo_goi_do_uong
{
    // Tạo các model đồ uống
    public abstract class Drink //Dùng lớp trừu tượng để làm lớp cơ sở cho các loại đồ uống
    {
        public string Name { get; protected set; } // Tên đồ uống
        public double BasePrice { get; protected set; } // Giá cơ bản
        public string Size { get; set; } = "S"; // Size: S, M, L
        public List<string> Toppings { get; set; } = new List<string>(); // Danh sách topping

        public abstract Drink Clone(); // Prototype -> shallow clone: sao chép đối tượng hiện tại, thay đổi cái mới ảnh hưởng đến cái cũ
        public virtual double GetPrice() // Tính giá dựa trên size và topping
        {
            double price = BasePrice;

            // Size
            if (Size == "M") price += 10;
            if (Size == "L") price += 20;

            // Topping: đường/đá free, các loại khác +5k
            foreach (var topping in Toppings)
            {
                if (topping != "Đường" && topping != "Đá")//Đá và đường miễn phí
                {
                    price += 5;//Các loại topping khác tính phí
                }
            }

            return price;
        }

        public override string ToString()// Hiển thị thông tin đồ uống
                                         // ToString() là phương thức được sử dụng để trả về một chuỗi đại diện cho đối tượng hiện tại.
        {
            string toppings = Toppings.Count > 0 ? string.Join(", ", Toppings) : "None";
            return $"{Name} (Size {Size}, Toppings: {toppings}) - {GetPrice()}k";
        }
    }
    // Cà phê 
    public class Coffee : Drink 
    {
        public Coffee()
        {
            Name = "Coffee";
            BasePrice = 30;
        }

        public override Drink Clone() // Ghi đè phương thức Clone để tạo bản sao của đối tượng hiện tại
        {
            return (Drink)this.MemberwiseClone();//MemberwiseClone() tạo một bản sao nông (shallow copy) của đối tượng hiện tại
        }
    }
    // Trà
    public class Tea : Drink
    {
        public Tea()
        {
            Name = "Tea";
            BasePrice = 25;
        }

        public override Drink Clone()
        {
            return (Drink)this.MemberwiseClone();
        }
    }
    // Nước trái cây 
    public class Juice : Drink
    {
        public Juice()
        {
            Name = "Juice";
            BasePrice = 35;
        }

        public override Drink Clone()
        {
            return (Drink)this.MemberwiseClone();
        }
    }
}