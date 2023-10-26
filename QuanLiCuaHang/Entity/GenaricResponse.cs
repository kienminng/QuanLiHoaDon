namespace QuanLiCuaHang.entity;

public class GenaricResponse
{
    public Status Status { get; set; }
    public string Message { get; set; }

    public GenaricResponse()
    {
    }

    public GenaricResponse(Status status, string message)
    {
        Status = status;
        Message = message;
    }
    
    
}