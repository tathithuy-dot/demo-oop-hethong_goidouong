using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static demo_goi_do_uong.FactoryMethod;

namespace demo_goi_do_uong
{

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; 
            // Khởi tạo menu và đơn hàng
            var menu = MenuSingleton.Instance;// Sử dụng Singleton để lấy thể hiện menu
            var order = new Order(); // Tạo đơn hàng mới

            Console.WriteLine("Bạn muốn đặt hàng qua đâu?");
            Console.WriteLine("1. App (giảm giá 10%)");
            Console.WriteLine("2. Tại quầy (không giảm)");
            Console.Write("Chọn: ");
            int channel = int.Parse(Console.ReadLine());
            // Sử dụng Abstract Factory để tạo đối tượng giảm giá và thanh toán dựa trên kênh đặt hàng
            IOrderFactory orderFactory = channel == 1 ? new OnlineOrderFactory() : new OfflineOrderFactory();

            while (true)
            {
                menu.ShowMenu();// Hiển thị menu đồ uống
                Console.Write("Chọn đồ uống (0 để kết thúc): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) break;

                Drink drink = null;
                switch (choice)
                {
                    case 1:
                        drink = new CoffeeFactory().CreateDrink(); ; // Sử dụng Factory Method để tạo đối tượng Coffee
                        break;
                    case 2:
                        drink = new TeaFactory().CreateDrink(); // Sử dụng Factory Method để tạo đối tượng Tea
                        break;
                    case 3:
                        drink = new JuiceFactory().CreateDrink();// Sử dụng Factory Method để tạo đối tượng Juice
                        break;
                        ;
                }
                if (drink == null) continue;
                // Chọn size và topping
                Console.Write("Chọn size (S/M/L): ");
                string size = Console.ReadLine()?.ToUpper() ?? "S"; // Mặc định size S

                List<string> toppings = new List<string>();
                while (true)
                {
                    menu.ShowToppings();
                    Console.Write("Chọn topping: ");
                    int topChoice = int.Parse(Console.ReadLine() ?? "0");// Mặc định kết thúc chọn topping
                    if (topChoice == 0) break;

                    switch (topChoice) // Thêm topping
                    {
                        case 1: toppings.Add("Đường"); break;
                        case 2: toppings.Add("Đá"); break;
                        case 3: toppings.Add("Trân châu"); break;
                        case 4: toppings.Add("Thạch"); break;
                        case 5: toppings.Add("Kem Cheese"); break;
                    }
                }
                // Sử dụng Builder để cấu hình đồ uống
                drink = new OrderBuilder(drink)
                    .WithSize(size)
                    .WithToppings(toppings)
                    .Build();

                order.AddDrink(drink);// Thêm đồ uống vào đơn hàng
                // Hỏi có muốn nhân đôi ly vừa chọn không (Prototype)
                Console.Write("Bạn có muốn nhân đôi ly vừa chọn không? (y/n): ");
                string cloneChoice = Console.ReadLine()?.ToLower() ?? "n"; // Mặc định không nhân đôi
                if (cloneChoice == "y")
                {
                    Drink cloned = drink.Clone();
                    order.AddDrink(cloned);
                    Console.WriteLine("Đã thêm 1 ly y hệt bằng Prototype!");
                }
                // Hỏi có muốn thêm đồ uống nữa không
                Console.Write("Bạn có muốn thêm đồ uống nữa không? (y/n): ");
                string more = Console.ReadLine()?.ToLower() ?? "n";
                if (more != "y") break;
            }
            order.PrintBill(orderFactory);
            Console.WriteLine("Cảm ơn bạn đã mua hàng!");
        }
    }
}
