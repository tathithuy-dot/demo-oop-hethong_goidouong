using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_goi_do_uong
{
     class FactoryMethod 
    {
        //Creator Abstract Class
        public abstract class DrinkFactory // Lớp cơ sở cho các nhà máy đồ uống 
        {
            public abstract Drink CreateDrink();// Phương thức tạo đồ uống 
        }
        //Concrete Creators
        // Mỗi nhà máy sẽ tạo ra một loại đồ uống cụ thể
        public class CoffeeFactory : DrinkFactory
        {
            public override Drink CreateDrink()
            {
                return new Coffee();
            }
        }

        public class TeaFactory : DrinkFactory
        {
            public override Drink CreateDrink()
            {
               return new Tea();
            }
        }

        public class JuiceFactory : DrinkFactory
        {
            public override Drink CreateDrink()
            {
                return new Juice();
            }
        }
    }
}
