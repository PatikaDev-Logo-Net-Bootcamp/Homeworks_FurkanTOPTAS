namespace ApartmanYonetimOtomasyonu.API.ApiDataResponse
{
    public class ApiDataResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}

