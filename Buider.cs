using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_goi_do_uong
{
    public class OrderBuilder
    {
        private readonly Drink _drink;// Đối tượng đồ uống đang được xây dựng, sử dụng readonly để đảm bảo không bị thay đổi sau khi khởi tạo

        public OrderBuilder(Drink drink) // Constructor nhận vào một đối tượng đồ uống
        {
            _drink = drink;
        }
        // OrderBuilder đóng vai trò Concrete Builder (và đồng thời đảm nhiệm luôn Builder interface)
        public OrderBuilder WithSize(string size) // Phương thức để thiết lập kích thước đồ uống
        {
            _drink.Size = size;
            return this; // Đây là cách viết ngắn gọn (cốt lõi của Fluent API - giúp code đọc tự nhiên)
        }

        public OrderBuilder WithToppings(List<string> toppings) // Phương thức để thiết lập danh sách topping cho đồ uống
        {
            _drink.Toppings = toppings;
            return this;
        }
        //Product
        public Drink Build() // Phương thức để hoàn tất việc xây dựng và trả về đối tượng đồ uống đã được cấu hình
        {
            return _drink;
        }
    }
}