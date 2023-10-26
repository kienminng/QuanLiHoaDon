using System.ComponentModel.DataAnnotations;

namespace QuanLiCuaHang.entity;

public class KhachHang
{
    public int KhachHangId { get; private set; }
    [Required]
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string Sdt { get; set; }
    
    public List<HoaDon> DanhSachHoaDon { get; set; }

    public KhachHang(int khachHangId, string hoTen, DateTime ngaySinh, int sdt)
    {
        KhachHangId = khachHangId;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        Sdt = sdt.ToString();
    }

    public KhachHang( string hoTen, DateTime ngaySinh, string sdt)
    {
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        Sdt = sdt;
    }
}