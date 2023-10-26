using Microsoft.AspNetCore.Mvc;
using QuanLiCuaHang.Dto;
using QuanLiCuaHang.Dto.Controller;
using QuanLiCuaHang.Dto.HoaDon;
using QuanLiCuaHang.entity;
using QuanLiCuaHang.IService;
using QuanLiCuaHang.Service;

namespace QuanLiCuaHang.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class HoaDonController : ControllerBase
{
    private readonly IHoaDonService _hoaDonService;

    public HoaDonController()
    {
        _hoaDonService = new HoaDonService();
    }

    [HttpPost( "addHoaDon")]
    public IActionResult SaveHoaDon([FromBody]AddHoaDonForm addHoaDonForm)
    {
        var addHoaDon = _hoaDonService.Save(addHoaDonForm);
        return Ok(addHoaDon);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteHoaDon(int id)
    {
        return Ok(_hoaDonService.Delete(id));
    }

    [HttpGet("searchByStr")]
    public IActionResult FindByString([FromBody] string str)
    {
        return Ok(_hoaDonService.FindWithNameOrCode(str));
    }

    [HttpGet("searchByTime")]
    public IActionResult FindByTime([FromBody] DateTime star, DateTime end)
    {
        return Ok(_hoaDonService.FindByTime(star, end));
    }

    [HttpGet("searchByMoney")]
    public IActionResult FindByMoney([FromBody] SearchMoney searchMoney,[FromQuery] int page)
    {
        var views = _hoaDonService.FindByMoney(searchMoney.Star, searchMoney.End);
    
        
        int pageSize = 20;
        int pageNumber = page;
        var paginatedResults = views.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return Ok(paginatedResults);
    }

    [HttpPost("PayMoney/{id}")]
    public IActionResult Pay(int id)
    {
        return Ok(_hoaDonService.PayMoney(id));
    }

    [HttpGet("filter")]
    public IActionResult Filter([FromBody] FilterDto dto,[FromQuery] int page)
    {
        IEnumerable<HoaDonView> hoaDonViews = _hoaDonService.Filter(dto);
        int Size = 2;
        var result = hoaDonViews.Skip((page - 1) * Size).Take(Size).ToList();
        return Ok(result);
    }
    
}