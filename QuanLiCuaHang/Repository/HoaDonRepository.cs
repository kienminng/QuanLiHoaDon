using HelloWebApi.Context;
using Microsoft.EntityFrameworkCore;
using QuanLiCuaHang.Dto;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.Repository;

public class HoaDonRepository
{
    private readonly AppDbContext _dbContext;

    public HoaDonRepository()
    {
        _dbContext = new AppDbContext();
    }

    public bool Save(HoaDon hoaDon)
    {
        try
        {
            _dbContext.HoaDons.Add(hoaDon);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(HoaDon hoaDon)
    {
        try
        {
            _dbContext.HoaDons.Update(hoaDon);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }


    public HoaDon? FindById(int id)
    {
        return _dbContext.HoaDons
            .FirstOrDefault(x => x.HoaDonId == id);
    }

    public bool Delete(HoaDon hoaDon)
    {
        try
        {
            _dbContext.HoaDons.Remove(hoaDon);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IEnumerable<HoaDon> GetAll()
    {
        return _dbContext.HoaDons.ToList();
    }

    public IEnumerable<HoaDon> FindAllByUserId(int id)
    {
        return 
            _dbContext.HoaDons
                .Where(x => x.KhachHangId == id)
                .ToList();
    }

    public IEnumerable<HoaDon> FindAll()
    {
        return
            _dbContext.HoaDons.ToList();
    }

    public IEnumerable<HoaDon> GetAllToday()
    {
        DateTime currentDate = DateTime.Now.Date;
        return 
            _dbContext.HoaDons
                .Where(e => e.ThoiGianTao.Date == currentDate).ToList();
    }

    private string GenaricString()
    {
        DateTime currentTime = DateTime.Now.Date;
        
        string datePart = currentTime.ToString("yyyyMMdd");

        string str = "";

        int length = GetAllToday().ToList().Count+1;
        string l = length.ToString();

        str = datePart + "_" + l;
        return str;
    }

    public IEnumerable<HoaDon> FindWithDoubleTime(DateTime starTime , DateTime endTime)
    {
        try
        {
            return
                _dbContext.HoaDons
                    .Where(e => e.ThoiGianTao >= starTime && e.ThoiGianTao < endTime)
                    .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public IEnumerable<HoaDon> FilterAllByTimeMoney(FilterDto dto)
    {
        return
            _dbContext.HoaDons
                .Where(e => (e.ThoiGianTao >= dto.Star && e.ThoiGianTao <= dto.End)
                            && (e.TongTien >= dto.Min && e.TongTien <= dto.Max)
                            && (e.MaGiaoDich.Contains(dto.Code))
                            )
                .ToList();
    }

    public IEnumerable<HoaDon> FindWithMoney(double start, double end)
    {
        try
        {
            return
                _dbContext.HoaDons
                    .Where(e => e.TongTien >= start && e.TongTien <= end)
                    .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public IEnumerable<HoaDon> FindByNameOrCode(string str)
    {
        try
        {
            return
                _dbContext.HoaDons
                    .Where(e => e.TenHoaDon.Contains(str) || e.MaGiaoDich.Contains(str))
                    .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public IEnumerable<HoaDon> FindWithStartDate(DateTime startDate)
    {
        try
        {
            return
                _dbContext.HoaDons
                    .Where(e => e.ThoiGianTao >= startDate)
                    .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}