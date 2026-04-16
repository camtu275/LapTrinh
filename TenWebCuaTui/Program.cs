using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TenWebCuaTui.Models; 

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm dịch vụ cho MVC (Controllers & Views) và Razor Pages (cho Identity)
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 

// 2. Cấu hình kết nối Database SQLite (Dùng cho GitHub Codespaces)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Cấu hình Identity (Đăng nhập, Đăng ký)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// --- Tạm khóa các Repository khi chưa có file ---
// builder.Services.AddScoped<IProductRepository, EFProductRepository>();
// builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

var app = builder.Build();

// 4. Cấu hình Pipeline (Xử lý yêu cầu)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 5. Xác thực và Phân quyền (Thứ tự này rất quan trọng)
app.UseAuthentication();
app.UseAuthorization();

// 6. Khai báo các Route (Định tuyến)
app.MapRazorPages(); // Phải có dòng này để các trang Identity hoạt động
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();