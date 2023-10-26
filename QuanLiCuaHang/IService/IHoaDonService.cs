using QuanLiCuaHang.Dto;
using QuanLiCuaHang.Dto.HoaDon;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.IService;

public interface IHoaDonService
{
    GenaricResponse Save(AddHoaDonForm addHoaDonForm);

    GenaricResponse Update(UpdateHoaDon updateHoaDon);

    IEnumerable<HoaDon> ViewsByUserId(int id);

    IEnumerable<HoaDon> GetAll();

    HoaDonView? FindById(int id);

    ErrorMessage Delete(int id);

    IEnumerable<HoaDonView> FindByTime(DateTime start, DateTime end);

    IEnumerable<HoaDonView> FindByMoney(double start, double end);

    public IEnumerable<HoaDonView> FindWithNameOrCode(string str);

    public double PayMoney(int id);

    public IEnumerable<HoaDonView> Filter(FilterDto filterDto);

}