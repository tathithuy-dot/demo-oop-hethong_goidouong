using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_goi_do_uong
{
    public class Order
    {
        private readonly List<Drink> _items = new List<Drink>(); // Danh sách đồ uống trong đơn hàng, sử dụng readonly để đảm bảo không bị thay đổi sau khi khởi tạo

        public void AddDrink(Drink drink)// Phương thức để thêm đồ uống vào đơn hàng
        {
            _items.Add(drink);
        }
        // Phương thức để in hoá đơn
        public void PrintBill(IOrderFactory factory)// Sử dụng Abstract Factory để tạo đối tượng giảm giá và thanh toán
        {
            Console.WriteLine("\n=== HOÁ ĐƠN ===");
            double total = 0;
            foreach (var d in _items)
            {
                Console.WriteLine(d.ToString());// Gọi phương thức ToString() của đối tượng đồ uống để hiển thị thông tin
                total += d.GetPrice();
            }

            var discount = factory.CreateDiscount();// Tạo đối tượng giảm giá từ factory
            total = discount.Apply(total);// Áp dụng giảm giá

            var payment = factory.CreatePayment();// Tạo đối tượng thanh toán từ factory
            Console.WriteLine($"Tổng cộng: {total}k");
            Console.WriteLine(payment.Pay(total));// Thực hiện thanh toán và hiển thị thông báo
            Console.WriteLine("=================\n");
        }
    }
}
