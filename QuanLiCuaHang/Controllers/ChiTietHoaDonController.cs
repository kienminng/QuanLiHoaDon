using Microsoft.AspNetCore.Mvc;
using QuanLiCuaHang.Dto.ChiTietHoaDon;
using QuanLiCuaHang.entity;
using QuanLiCuaHang.IService;
using QuanLiCuaHang.Service;

namespace QuanLiCuaHang.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ChiTietHoaDonController : Controller
{
    private readonly IChiTietHoaDonService _chiTietHoaDonService;

    public ChiTietHoaDonController()
    {
        _chiTietHoaDonService = new ChiTietHoaDonService();
    }

    [HttpPost("Add")]
    public IActionResult Save([FromBody] AddChiTietHoaDonForm addChiTietHoaDonForm)
    {
        return Ok(_chiTietHoaDonService.Save(addChiTietHoaDonForm));
    }

    [HttpGet("getByUserId/{id}")]
    public IActionResult GetAllByUserId( int id,[FromQuery] int page)
    {
        IEnumerable<ChiTietHoaDonView> chiTietHoaDons = _chiTietHoaDonService.GetAllByHoaDonId(id);
        int pageSize = 2;
        int pageNumber = page;
        var paginatedResults = chiTietHoaDons.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return Ok(paginatedResults);
    }
    
    
    
}