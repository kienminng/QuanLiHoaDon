using QuanLiCuaHang.Dto.ChiTietHoaDon;
using QuanLiCuaHang.Dto.HoaDon;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.Convert.ConvertChiTietHoaDon;

public class ConvertChiTietHoaDon
{
    public static ChiTietHoaDon ConvertAddChiTietFromToChiTiet(AddChiTietHoaDonForm addChiTietHoaDonForm)
    {
        ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
        chiTietHoaDon.HoaDonId = addChiTietHoaDonForm.HoaDonId;
        chiTietHoaDon.SanPhamId = addChiTietHoaDonForm.SanPhamId;
        chiTietHoaDon.SoLuong = addChiTietHoaDonForm.SoLuong;
        chiTietHoaDon.DVT = addChiTietHoaDonForm.DVT;
        return chiTietHoaDon;
    }

    public static IEnumerable<ChiTietHoaDonView> ConvertChiTietHoaDonToViews(IEnumerable<ChiTietHoaDon> chiTietHoaDons)
    {
        IEnumerable<ChiTietHoaDonView> views = chiTietHoaDons
            .Select(p 
                => new ChiTietHoaDonView()
            {
                 ChiTietHoaDonId = p.ChiTietHoaDonId,
                 SanPhamId = p.SanPhamId,
                 SoLuong = p.SoLuong,
                 DVT = p.DVT,
                 ThanhTien = p.ThanhTien,
                 
            }).ToList();

        return views;
    }
    
}