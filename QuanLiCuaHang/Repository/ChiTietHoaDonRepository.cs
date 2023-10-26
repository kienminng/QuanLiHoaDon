using HelloWebApi.Context;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.Repository;

public class ChiTietHoaDonRepository
{
    private readonly AppDbContext _dbContext;

    public ChiTietHoaDonRepository()
    {
        _dbContext = new AppDbContext();
    }

    public bool Save(ChiTietHoaDon chiTietHoaDon)
    {
        try
        {
            _dbContext.ChiTietHoaDons.Add(chiTietHoaDon);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

    public bool Update(ChiTietHoaDon chiTietHoaDon)
    {
        try
        {
            _dbContext.ChiTietHoaDons.Update(chiTietHoaDon);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IEnumerable<ChiTietHoaDon> GetAll()
    {
        return _dbContext.ChiTietHoaDons.ToList();
    }

    public ChiTietHoaDon? FindById(int id)
    {
        return _dbContext.ChiTietHoaDons.Find(id);
    }

    public bool Delete(ChiTietHoaDon chiTietHoaDon)
    {
        try
        {
            _dbContext.ChiTietHoaDons.Remove(chiTietHoaDon);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IEnumerable<ChiTietHoaDon> GetAllByHoaDonId(int id)
    {
        return _dbContext.ChiTietHoaDons
            .Where(x => x.HoaDonId == id)
            .ToList();
    }
    
    
}