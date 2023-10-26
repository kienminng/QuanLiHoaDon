using QuanLiCuaHang.Dto.HoaDon;

namespace QuanLiCuaHang.Convert.HoaDon;

public class ConvertHoaDon
{
    public static entity.HoaDon ConvertAddHoaDonFormToHoaDon(AddHoaDonForm addHoaDonForm)
    {
        entity.HoaDon hoaDon = new entity.HoaDon();

        hoaDon.KhachHangId = addHoaDonForm.KhachHangId;

        hoaDon.TenHoaDon = addHoaDonForm.TenHoaDon;
        hoaDon.GhiChu = addHoaDonForm.GhiChu;
        return hoaDon;
    }

    public static entity.HoaDon ConvertUpdateHoaDonToHoaDon(UpdateHoaDon updateHoaDon)
    {
        entity.HoaDon hoaDon = new entity.HoaDon();
        hoaDon.HoaDonId = updateHoaDon.HoaDonId;
        hoaDon.TenHoaDon = updateHoaDon.TenHoaDon;
        hoaDon.ThoiGianCapNhap = updateHoaDon.ThoiGianCapNhap;
        hoaDon.KhachHangId = updateHoaDon.KhachHangId;
        hoaDon.GhiChu = updateHoaDon.GhiChu;

        return hoaDon;
    }

    public static HoaDonView ConverHoaDonToHoaDonView(entity.HoaDon hoaDon)
    {
        HoaDonView hoaDonView = new HoaDonView();
        hoaDonView.HoaDonId = hoaDon.HoaDonId;
        hoaDonView.TenHoaDon = hoaDon.TenHoaDon;
        hoaDonView.GhiChu = hoaDon.GhiChu;
        hoaDonView.ThoiGianTao = hoaDon.ThoiGianTao;
        hoaDonView.ThoiGianCapNhap = hoaDon.ThoiGianCapNhap;
        hoaDonView.TongTien = hoaDon.TongTien;
        hoaDonView.KhachHangId = hoaDon.KhachHangId;
        hoaDonView.MaGiaoDich = hoaDon.MaGiaoDich;
        return hoaDonView;
    }

    public static IEnumerable<HoaDonView> ConvertHoaDonToHoaDonViews(IEnumerable<entity.HoaDon> hoaDon)
    {
        IEnumerable<HoaDonView> dtos = hoaDon.Select(hoaDon => new HoaDonView()
        {
            HoaDonId = hoaDon.HoaDonId,
            TenHoaDon = hoaDon.TenHoaDon,
            GhiChu = hoaDon.GhiChu,
            ThoiGianTao = hoaDon.ThoiGianTao,
            ThoiGianCapNhap = hoaDon.ThoiGianCapNhap,
            TongTien = hoaDon.TongTien,
            KhachHangId = hoaDon.KhachHangId,
            MaGiaoDich = hoaDon.MaGiaoDich
        });
        return dtos;
    }
}