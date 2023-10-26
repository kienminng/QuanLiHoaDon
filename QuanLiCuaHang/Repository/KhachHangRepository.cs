using HelloWebApi.Context;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.Repository;

public class KhachHangRepository
{
    private readonly AppDbContext _dbContext;

    public KhachHangRepository()
    {
        _dbContext = new AppDbContext();
    }

    public KhachHang? FindById(int id)
    {
        try
        {
            return
                _dbContext.KhachHangs.Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}