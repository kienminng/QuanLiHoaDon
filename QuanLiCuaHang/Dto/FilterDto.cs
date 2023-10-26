namespace QuanLiCuaHang.Dto;

public class FilterDto
{
    public DateTime Star { get; set; }
    public DateTime End { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    
    public string Code { get; set; }
}