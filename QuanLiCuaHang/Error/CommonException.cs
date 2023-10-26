using System.Runtime.Serialization;

namespace QuanLiCuaHang.entity;

[Serializable]
public class CommonException : Exception
{
    public string Code { get; set; }
    public string MessageError { get; set; }
    
    public CommonException()
    {
    }

    public CommonException(string code)
    {
        Code = code;
    }
    
    protected CommonException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public CommonException(string? message,string code) : base(message)
    {
        MessageError = message;
        Code = code;

    }

    public CommonException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}