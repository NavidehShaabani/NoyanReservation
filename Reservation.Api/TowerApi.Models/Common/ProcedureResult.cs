namespace TowerApi.Models.Common
{
    public class ProcedureResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public bool IsSuccess => ResultCode >= 200 && ResultCode < 300;
    }
}
