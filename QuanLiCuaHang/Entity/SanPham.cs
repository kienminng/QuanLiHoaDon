using System.ComponentModel.DataAnnotations;

namespace QuanLiCuaHang.entity;

public class SanPham
{
    public int SanPhamId { get; private set; }
    [Required]
    [MinLength(1)]
    public string TenSanPham { get; set; }
    [Required]
    [MinLength(1)]
    public double GiaThanh { get; set; }
    public string Mota { get; set; }
    [Required]
    public DateTime? NgayHetHan { get; set; }
    public string KyHieuSanPham { get; set; }
    [Required]
    public int LoaiSanPhamId { get; set; }
    public LoaiSanPham LoaiSanPham { get; set; }

    public SanPham(int sanPhamId, string tenSanPham, double giaThanh, string mota, DateTime? ngayHetHan, string kyHieuSanPham, int loaiSanPhamId)
    {
        SanPhamId = sanPhamId;
        TenSanPham = tenSanPham;
        GiaThanh = giaThanh;
        Mota = mota;
        NgayHetHan = ngayHetHan;
        KyHieuSanPham = kyHieuSanPham;
        LoaiSanPhamId = loaiSanPhamId;
    }

    public SanPham(string tenSanPham, double giaThanh, string mota, DateTime? ngayHetHan, string kyHieuSanPham, int loaiSanPhamId)
    {
        TenSanPham = tenSanPham;
        GiaThanh = giaThanh;
        Mota = mota;
        NgayHetHan = ngayHetHan;
        KyHieuSanPham = kyHieuSanPham;
        LoaiSanPhamId = loaiSanPhamId;
    }
}