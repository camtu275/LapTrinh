using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TenWebCuaTui.Models; 

namespace TenWebCuaTui.Models
{
    // IdentityDbContext giúp tự động tạo các bảng Login/Register
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // MỞ KHÓA dòng này vì bạn đã có file Product.cs
        public DbSet<Product> Products { get; set; }

        // VẪN KHÓA dòng này vì bạn chưa tạo file Category.cs
        // public DbSet<Category> Categories { get; set; }
    }
}