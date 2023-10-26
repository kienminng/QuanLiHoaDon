using System.Diagnostics.CodeAnalysis;
using System.Text;
using QuanLiCuaHang.Convert.HoaDon;
using QuanLiCuaHang.Dto;
using QuanLiCuaHang.Dto.HoaDon;
using QuanLiCuaHang.entity;
using QuanLiCuaHang.IService;
using QuanLiCuaHang.Repository;

namespace QuanLiCuaHang.Service;

public class HoaDonService : IHoaDonService
{
    private readonly HoaDonRepository _hoaDonRepository;
    private readonly ChiTietHoaDonRepository _chiTietHoaDonRepository;
    private readonly KhachHangRepository _khachHangRepository;

    public HoaDonService()
    {
        _khachHangRepository = new KhachHangRepository();
        _hoaDonRepository = new HoaDonRepository();
        _chiTietHoaDonRepository = new ChiTietHoaDonRepository();
    }

    public GenaricResponse Update([NotNull] UpdateHoaDon updateHoaDon)
    {
        try
        {
            HoaDon hoaDon = ConvertHoaDon.ConvertUpdateHoaDonToHoaDon(updateHoaDon);
            _hoaDonRepository.Update(hoaDon);
            return new GenaricResponse()
            {
                Message = "Update success",
                Status = Status.Ok
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new GenaricResponse()
            {
                Message = "Update false",
                Status = Status.BadRequest
            };
        }
    }

    public IEnumerable<HoaDon> ViewsByUserId(int id)
    {
        return 
            _hoaDonRepository.FindAllByUserId(id);
    }

    public IEnumerable<HoaDon> GetAll()
    {
        return
            _hoaDonRepository.FindAll();
    }

    public HoaDonView? FindById(int id)
    {
        try
        {
            var hoaDons = _hoaDonRepository.FindById(id);
            HoaDonView hoaDonView = ConvertHoaDon.ConverHoaDonToHoaDonView(hoaDons);
            return hoaDonView;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public GenaricResponse Save(AddHoaDonForm addHoaDonForm)
    {
        if (_khachHangRepository.FindById(addHoaDonForm.KhachHangId) == null)
        {
            return new GenaricResponse()
            {
                Message = "khách hàng chưa xác định",
                Status = Status.ServeInvalid
            };
        }
        HoaDon hoaDon = ConvertHoaDon.ConvertAddHoaDonFormToHoaDon(addHoaDonForm);
        hoaDon.ThoiGianTao = DateTime.Now;
        hoaDon.MaGiaoDich = GenerateTransactionCode();
        hoaDon.ThoiGianCapNhap = DateTime.Now;
        bool check = _hoaDonRepository.Save(hoaDon);
        if (check)
        {
            return new GenaricResponse()
            {
                Message = "Add success",
                Status = Status.Ok
            };
        }

        return new GenaricResponse()
        {
            Message = "Add False",
            Status = Status.BadRequest
        };
    }

    public IEnumerable<HoaDonView> Filter(FilterDto dto)
    {
        if (dto.End == null)
        {
            dto.End = DateTime.Now;
        }

        if (dto.Star == null)
        {
            dto.Star = DateTime.MinValue;
        }

        if (dto.Max == 0)
        {
            dto.Max = double.MaxValue;
        }

        IEnumerable<HoaDon> hoaDons = _hoaDonRepository.FilterAllByTimeMoney(dto);
        IEnumerable<HoaDonView> hoaDonViews = ConvertHoaDon.ConvertHoaDonToHoaDonViews(hoaDons);
        return hoaDonViews;
    }


    public string GenerateTransactionCode()
    {
        DateTime now = DateTime.Now;
        string year = now.Year.ToString();
        string month = now.Month.ToString("00");
        string day = now.Day.ToString("00");
        int count = _hoaDonRepository.GetAllToday().ToList().Count;
        count = count + 1;
        string ToStr = count.ToString();

        string transactionCode = $"{year}{month}{day}" + "_" + ToStr;
        return transactionCode;
    }
    
    

    private void ValidateHoaDon(HoaDon hoaDon)
    {
        if (hoaDon.ThoiGianTao > hoaDon.ThoiGianCapNhap)
        {
            throw new Exception(
                "Thời gian tạo phải nhỏ hơn hoặc bằng thời gian cập nhập"
            );
        }
    }

    private double GetTotalMoneyByHoaDonId(int id)
    {
        IEnumerable<ChiTietHoaDon> chiTietHoaDons = _chiTietHoaDonRepository.GetAllByHoaDonId(id);
        double Money = 0;
        foreach (var tietHoaDon in chiTietHoaDons)
        {
            Money += tietHoaDon.ThanhTien;
        }

        return Money;
    }

    public IEnumerable<HoaDonView> FindByTime(DateTime start, DateTime end)
    {
        IEnumerable<HoaDon> hoaDons = _hoaDonRepository.FindWithDoubleTime(start, end);
        IEnumerable<HoaDonView> hoaDonViews = ConvertHoaDon.ConvertHoaDonToHoaDonViews(hoaDons);
        return hoaDonViews;
    }

    public IEnumerable<HoaDonView> FindByMoney(double start, double end)
    {
        IEnumerable<HoaDon> hoaDons = _hoaDonRepository.FindWithMoney(start, end);
        IEnumerable<HoaDonView> hoaDonViews = ConvertHoaDon.ConvertHoaDonToHoaDonViews(hoaDons);
        return hoaDonViews;
    }

    public IEnumerable<HoaDonView> FindWithNameOrCode(string str)
    {
        IEnumerable<HoaDon> hoaDons = _hoaDonRepository.FindByNameOrCode(str);
        IEnumerable<HoaDonView> hoaDonViews = ConvertHoaDon.ConvertHoaDonToHoaDonViews(hoaDons);
        return hoaDonViews;
    }

    public double PayMoney(int id)
    {
        try
        {
            HoaDon hoaDon = _hoaDonRepository.FindById(id);
            double moneyByHoaDonId = GetTotalMoneyByHoaDonId(id);
            hoaDon.ThoiGianCapNhap = DateTime.Now;
            hoaDon.TongTien = moneyByHoaDonId;
            _hoaDonRepository.Update(hoaDon);
            return moneyByHoaDonId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ErrorMessage Delete(int id)
    {
        try
        {
            HoaDon hoaDon = IsExist(id);
            IEnumerable<ChiTietHoaDon> chiTietHoaDons = _chiTietHoaDonRepository.GetAllByHoaDonId(id);
            foreach (var n in chiTietHoaDons)
            {
                _chiTietHoaDonRepository.Delete(n);
            }

            _hoaDonRepository.Delete(hoaDon);

            return ErrorMessage.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private HoaDon IsExist(int id)
    {
        HoaDon hoaDon = _hoaDonRepository.FindById(id);
        if (hoaDon == null)
        {
            throw new CommonException("HoaDon.IsExist");
        }

        return hoaDon;
    }
}