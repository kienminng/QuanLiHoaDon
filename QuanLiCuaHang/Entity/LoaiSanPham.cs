using System.ComponentModel.DataAnnotations;

namespace QuanLiCuaHang.entity;

public class LoaiSanPham
{
    public int LoaiSanPhamId { get; private set; }
    [Required]
    public string TenLoaiSanPham { get; set; }
    public List<SanPham> DanhSachSanPhams { get; set; }

    public LoaiSanPham(int loaiSanPhamId, string tenLoaiSanPham)
    {
        LoaiSanPhamId = loaiSanPhamId;
        TenLoaiSanPham = tenLoaiSanPham;
    }

    public LoaiSanPham(string tenLoaiSanPham)
    {
        TenLoaiSanPham = tenLoaiSanPham;
    }
}