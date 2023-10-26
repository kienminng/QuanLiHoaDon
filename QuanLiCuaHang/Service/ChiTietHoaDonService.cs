using System.Collections;
using HelloWebApi.Context;
using QuanLiCuaHang.Convert.ConvertChiTietHoaDon;
using QuanLiCuaHang.Dto.ChiTietHoaDon;
using QuanLiCuaHang.entity;
using QuanLiCuaHang.IService;
using QuanLiCuaHang.Repository;

namespace QuanLiCuaHang.Service;

public class ChiTietHoaDonService : IChiTietHoaDonService
{
    private readonly ChiTietHoaDonRepository _donRepository;
    private readonly SanPhamRepository _sanPhamRepository;
    private readonly HoaDonRepository _hoaDonRepository;

    public ChiTietHoaDonService()
    {
        _donRepository = new ChiTietHoaDonRepository();
        _sanPhamRepository = new SanPhamRepository();
        _hoaDonRepository = new HoaDonRepository();
    }

    public  GenaricResponse Save(AddChiTietHoaDonForm addChiTietHoaDonForm)
    {
        var hoadon = _hoaDonRepository.FindById(addChiTietHoaDonForm.HoaDonId);
        if (hoadon == null)
        {
            return new GenaricResponse()
            {
                Message = "Sản phẩm không tồn tại",
                Status = Status.ServeInvalid
            };
        }
        ChiTietHoaDon chiTietHoaDon = ConvertChiTietHoaDon.ConvertAddChiTietFromToChiTiet(addChiTietHoaDonForm);
        chiTietHoaDon.ThanhTien = chiTietHoaDon.SoLuong * GetGiaSP(chiTietHoaDon.SanPhamId);
        var res = _donRepository.Save(chiTietHoaDon);
        if (res)
        {
            return new GenaricResponse()
            {
                Message = "Thêm sản phẩm thành công",
                Status = Status.Ok
            };
        }

        return new GenaricResponse()
        {
            Message = "Thêm sản phẩm thất bại",
            Status = Status.BadRequest
        };

    }

    public GenaricResponse Update(ChiTietHoaDon chiTietHoaDon)
    {
        var check = _donRepository.Update(chiTietHoaDon);
        if (check)
        {
            return new GenaricResponse()
            {
                Message = "sửa thành công",
                Status = Status.Ok
            };

        }

        return new GenaricResponse()
        {
            Message = "sửa thất bại",
            Status = Status.BadRequest
        };
    }

    public GenaricResponse Delete(int id)
    {
        var obj = _donRepository.FindById(id);
        var check = _donRepository.Delete(obj);
        if (check)
        {
            return new GenaricResponse()
            {
                Message = "delete success",
                Status = Status.Ok
            };
        }

        return new GenaricResponse()
        {
            Message = "Chi tiết hoá đơn không tồn tại",
            Status = Status.Ok
        };
    }

    public ChiTietHoaDon? FindById(int id)
    {
        return _donRepository.FindById(id);
    }

    public IEnumerable<ChiTietHoaDonView> GetAll()
    {
        return ConvertChiTietHoaDon
            .ConvertChiTietHoaDonToViews(
                _donRepository.GetAll()
                );
    }

    public IEnumerable<ChiTietHoaDonView> GetAllByHoaDonId(int hdId)
    {
        IEnumerable<ChiTietHoaDon> chiTietHoaDon =  _donRepository.GetAllByHoaDonId(hdId);
        IEnumerable<ChiTietHoaDonView> chiTietHoaDonView =
            ConvertChiTietHoaDon.ConvertChiTietHoaDonToViews(
                chiTietHoaDon
                );
        return chiTietHoaDonView;
    }

    private double GetGiaSP(int spId)
    {
        SanPham sanPham = _sanPhamRepository.FindById(spId);
        if (sanPham == null)
        {
            throw new CommonException("SP.IsNotExist");
        }
        return sanPham.GiaThanh;
    }

    public double GetTotalMoneyByHoaDonId(int id)
    {
        IEnumerable<ChiTietHoaDon> chiTietHoaDons = _donRepository.GetAllByHoaDonId(id);
        double Money = 0;
        foreach (var tietHoaDon in chiTietHoaDons)
        {
            Money += tietHoaDon.ThanhTien;
        }
        return Money;
    }
    
}