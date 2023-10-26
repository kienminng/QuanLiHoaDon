using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiCuaHang.entity;

public class ChiTietHoaDon
{
    public int ChiTietHoaDonId { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(99)]
    [DefaultValue(1)]
    public int SoLuong { get; set; }
    [Required]
    public string DVT { get; set; }
    [MinLength(1)]
    public double ThanhTien { get; set; }
    [Required]
    public int SanPhamId { get; set; }
    public SanPham SanPham { get; set; }
    [Required]
    public int HoaDonId { get; set; }
    public HoaDon HoaDon { get; set; }
}