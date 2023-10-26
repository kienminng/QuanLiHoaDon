using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLiCuaHang.entity;

public class HoaDon
{
    public int HoaDonId { get; set; }
    [Required] 
    [MinLength(2)]
    public string TenHoaDon { get; set; }
    [Required] 
    public string? MaGiaoDich { get; set; }
    [Required]
    public DateTime ThoiGianTao { get; set; }
    public DateTime ThoiGianCapNhap { get; set; }
    public string GhiChu { get; set; }
    [Required]
    [DefaultValue(0)]
    public double TongTien { get; set; }
    public int KhachHangId { get; set; }
    public KhachHang KhachHang { get; set; }
    public List<ChiTietHoaDon> DanhSachChiTietHoaDons { get; set; }

    public HoaDon(int hoaDonId, string tenHoaDon, string maGiaoDich, DateTime thoiGianTao, DateTime thoiGianCapNhap, string ghiChu, double tongTien, int khachHangId)
    {
        HoaDonId = hoaDonId;
        TenHoaDon = tenHoaDon;
        MaGiaoDich = maGiaoDich;
        ThoiGianTao = thoiGianTao;
        ThoiGianCapNhap = thoiGianCapNhap;
        GhiChu = ghiChu;
        TongTien = tongTien;
        KhachHangId = khachHangId;
    }
    
    public HoaDon( string tenHoaDon, string maGiaoDich, DateTime thoiGianTao, DateTime thoiGianCapNhap, string ghiChu, double tongTien, int khachHangId)
    {
        TenHoaDon = tenHoaDon;
        MaGiaoDich = maGiaoDich;
        ThoiGianTao = thoiGianTao;
        ThoiGianCapNhap = thoiGianCapNhap;
        GhiChu = ghiChu;
        TongTien = tongTien;
        KhachHangId = khachHangId;
    }

    public HoaDon()
    {
    }
}