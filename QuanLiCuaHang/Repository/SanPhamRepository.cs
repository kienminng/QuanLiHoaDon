using HelloWebApi.Context;
using QuanLiCuaHang.entity;

namespace QuanLiCuaHang.Repository;

public class SanPhamRepository
{
    private readonly AppDbContext _dbContext;

    public SanPhamRepository()
    {
        _dbContext = new AppDbContext();
    }

    public SanPham? FindById(int id)
    {
        return _dbContext.SanPhams
            .FirstOrDefault(x=> x.SanPhamId == id);
    }
}