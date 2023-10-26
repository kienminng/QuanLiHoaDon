namespace QuanLiCuaHang.Dto.Controller;

public class SearchMoney
{
    public double Star { get; set; }
    public double End { get; set; }

    public SearchMoney()
    {
    }

    public SearchMoney(double star, double end)
    {
        Star = star;
        End = end;
    }
}