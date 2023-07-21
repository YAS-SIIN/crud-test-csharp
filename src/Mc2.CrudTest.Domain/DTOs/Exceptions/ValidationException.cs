using System;

namespace Mc2.CrudTest.Domain.DTOs.Exceptions;

public class ValidationException : Exception
{
    public int ErrorCode { get; set; }
     
    public string ErrorDescription { get; set; }               

    public ValidationException(int errorCode, string errorDescription)
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
    }
}
