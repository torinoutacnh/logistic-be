﻿namespace API.Models.Response
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int? ErrorCode { get; set; }

        public ErrorResponse(string message, int? errorCode = null)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
