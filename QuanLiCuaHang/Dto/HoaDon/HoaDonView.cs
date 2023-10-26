namespace QuanLiCuaHang.Dto.HoaDon;

public class HoaDonView
{
    public int HoaDonId { get; set; }
    
    public string TenHoaDon { get; set; }
    
    public string? MaGiaoDich { get; set; }
   
    public DateTime? ThoiGianTao { get; set; }
    public DateTime? ThoiGianCapNhap { get; set; }
    public string GhiChu { get; set; }
    
    public double TongTien { get; set; }
    public int KhachHangId { get; set; }

    public HoaDonView(int hoaDonId, string tenHoaDon, string? maGiaoDich, DateTime? thoiGianTao, DateTime? thoiGianCapNhap, string ghiChu, double tongTien, int khachHangId)
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

    public HoaDonView()
    {
    }
}