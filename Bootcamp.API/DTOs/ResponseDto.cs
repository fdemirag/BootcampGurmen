﻿using System.Text.Json.Serialization;

namespace Bootcamp.API.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<String> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        //static factory method 
        public static ResponseDto<T> Success(T Data, int statusCode=0)
        {
            return new ResponseDto<T> { Data = Data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(int statusCode=0)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode };
        }

        public static ResponseDto<T> Fail(List<string> errors,int statusCode=0) 
        {
            return new ResponseDto<T> {Data = default(T), Errors = errors, StatusCode=statusCode};
        }

        public static ResponseDto<T> Fail(string error, int statusCode=0)
        {
            return new ResponseDto<T> { Data = default(T), Errors = new List<string>() { error},StatusCode = statusCode};
        }

    } 
}
