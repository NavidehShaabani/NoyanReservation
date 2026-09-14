namespace TowerApi.Models.User
{
    public class PermissionInfo
    {
        public int Code { get; set; }

        public string Fa { get; set; } = string.Empty;

        public string En { get; set; } = string.Empty;

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public bool CanDelete { get; set; }
    }
}
