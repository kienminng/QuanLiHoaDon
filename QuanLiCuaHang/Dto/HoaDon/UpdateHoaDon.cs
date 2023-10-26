namespace QuanLiCuaHang.Dto.HoaDon;

public class UpdateHoaDon
{
    public int HoaDonId { get; set; }
    
    public string TenHoaDon { get; set; }
    
    public DateTime ThoiGianCapNhap { get; set; }
    
    public string GhiChu { get; set; }
    
    public int KhachHangId { get; set; }
}