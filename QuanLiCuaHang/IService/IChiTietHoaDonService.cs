using QuanLiCuaHang.Dto.ChiTietHoaDon;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.IService;

public interface IChiTietHoaDonService
{
    GenaricResponse Save(AddChiTietHoaDonForm addChiTietHoaDonForm);

    GenaricResponse Update(ChiTietHoaDon chiTietHoaDon);

    GenaricResponse Delete(int id);

    ChiTietHoaDon? FindById(int id);

    IEnumerable<ChiTietHoaDonView> GetAll();

    IEnumerable<ChiTietHoaDonView> GetAllByHoaDonId(int hdId);
    
    
}