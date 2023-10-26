

using Microsoft.EntityFrameworkCore;
using QuanLiCuaHang.entity;

namespace HelloWebApi.Context;

public class AppDbContext : DbContext
{
    public virtual DbSet<KhachHang> KhachHangs { get; set; }
    public virtual DbSet<HoaDon> HoaDons { get; set; }
    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
    public virtual DbSet<SanPham> SanPhams { get; set; }
    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            $"Data Source=ADMIN-PC;Initial Catalog=QuanLiHoaDon ;Integrated Security=True; TrustServerCertificate=True");
    }
}