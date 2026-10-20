namespace TowerApi.Models.Building
{
    public class BuildingBulkServiceResult<T>
    {
        public int Code { get; set; }
        public string MessageKey { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
