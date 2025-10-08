using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_goi_do_uong
{

    public class MenuSingleton
    {
        private static MenuSingleton _instance;// Biến tĩnh giữ thể hiện duy nhất của MenuSingleton
        public List<Drink> Drinks { get; private set; }// Danh sách đồ uống có sẵn

        private MenuSingleton() // Constructor riêng tư để ngăn chặn việc tạo thể hiện từ bên ngoài
        {
            Drinks = new List<Drink> // Khởi tạo danh sách đồ uống
            {
                new Coffee(), // Thêm các loại đồ uống vào menu
                new Tea(),
                new Juice()
            };
        }

        public static MenuSingleton Instance // Thuộc tính tĩnh để truy cập thể hiện duy nhất của MenuSingleton
        {
            get
            {
                if (_instance == null)
                    _instance = new MenuSingleton();
                return _instance;
            }
        }

        public void ShowMenu()// Hiển thị menu đồ uống
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║         MENU ĐỒ UỐNG         ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("║ 1. Cà phê                    ║");
            Console.WriteLine("║ 2. Trà                       ║");
            Console.WriteLine("║ 3. Nước ép                   ║");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();
        }

        public void ShowToppings() //Hiển thị danh sách topping
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  ╔═════════════════════════════╗");
            Console.WriteLine("  ║         CHỌN TOPPING        ║");
            Console.WriteLine("  ╠═════════════════════════════╣");
            Console.ResetColor();

            Console.WriteLine("  ║ 1. Đường (Miễn phí)         ║");
            Console.WriteLine("  ║ 2. Đá (Miễn phí)            ║");
            Console.WriteLine("  ║ 3. Trân châu (+5k)          ║");
            Console.WriteLine("  ║ 4. Thạch (+5k)              ║");
            Console.WriteLine("  ║ 5. Kem Cheese (+5k)         ║");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ╚═════════════════════════════╝");
            Console.ResetColor();
        }
    }
}
