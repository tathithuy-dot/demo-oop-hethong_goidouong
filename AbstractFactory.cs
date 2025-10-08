using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_goi_do_uong
{
    //Tạo interface cho sản phẩm (Abstract Product) //Sản phẩm ở đây là các phương thức thanh toán khác nhau và giảm giá.
    public interface IDiscount // Giao diện giảm giá
    {
        double Apply(double total); // Áp dụng giảm giá và trả về tổng sau khi giảm
    }

    public interface IPayment // Giao diện thanh toán
    {
        string Pay(double amount); // Thanh toán và trả về thông báo
    }

    public class OnlineDiscount : IDiscount
    {
        public double Apply(double total) => total * 0.9; // giảm 10%
    }

    public class NoDiscount : IDiscount
    {
        public double Apply(double total) => total; // không giảm
    }

    public class AppPayment : IPayment
    {
        public string Pay(double amount) => $"Thanh toán {amount}k qua App";
    }

    public class CashPayment : IPayment
    {
        public string Pay(double amount) => $"Thanh toán {amount}k bằng Tiền mặt";
    }

    // ===== Abstract Factory =====
    // IOrderFactory định nghĩa một "family of products" (Discount + Payment)
    // đảm bảo các sản phẩm tạo ra luôn đi theo cặp logic (Online → OnlineDiscount + AppPayment, Offline → NoDiscount + CashPayment)
    // Đây là sự khác biệt với Factory Method (chỉ tạo ra 1 sản phẩm duy nhất).

    public interface IOrderFactory
    {
        IDiscount CreateDiscount(); // Bắt buộc phải có phương thức tạo đối tượng giảm giá
        IPayment CreatePayment(); // Bắt buộc phải có phương thức tạo đối tượng thanh toán
    }
    //Tạo Concrete Factory 
    //Nếu có thêm tình huống khác xảy ra thì chỉ cần tạo thêm Concrete Factory
    public class OnlineOrderFactory : IOrderFactory // Đặt hàng online
    {
        public IDiscount CreateDiscount() => new OnlineDiscount();
        public IPayment CreatePayment() => new AppPayment();
    }

    public class OfflineOrderFactory : IOrderFactory // Đặt hàng tại quầy
    {
        public IDiscount CreateDiscount() => new NoDiscount();
        public IPayment CreatePayment() => new CashPayment();
    }
}