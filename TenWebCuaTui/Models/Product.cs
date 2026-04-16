using System.ComponentModel.DataAnnotations;

namespace TenWebCuaTui.Models
{
    public class Product
    {
        [Key] // Đánh dấu đây là khóa chính (ID tự tăng)
        public int Id { get; set; }

        [Required] // Bắt buộc phải nhập tên
        public string Name { get; set; }

        public string? Description { get; set; } // Dấu ? nghĩa là không nhập cũng được

        public decimal Price { get; set; }
    }
}