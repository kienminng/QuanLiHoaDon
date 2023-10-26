using System.Runtime.Serialization;

namespace QuanLiCuaHang.entity;

public class CommonError : Exception
{
    public string Message { get; set; }
    public string Code { get; set; }

    public CommonError()
    {
    }
    
    public CommonError(string message, string code)
    {
        Message = message;
        Code = code;
    }
}