using System.Text.Json.Serialization;

namespace NTierArchitecture.DTO.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCodes { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T>() { Data = data, StatusCodes = statusCode, Errors = null };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T>() { StatusCodes = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<String> errors)
        {
            return new CustomResponseDto<T>() { StatusCodes = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T>() { StatusCodes = statusCode, Errors = new List<string>() { error } };
        }

    }
}
