namespace TowerApi.Models.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public int Code { get; set; }

        public string MessageKey { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }

        public int Code { get; set; }

        public string MessageKey { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
