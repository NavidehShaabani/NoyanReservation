us
namespace TowerApi.Models.Spaces
{
    public sealed class SpaceOperationResult<T>
    {
        public int ResultCode { get; init; }
        public string ResultMessage { get; init; } = string.Empty;
        public T? Data { get; init; }

        public bool IsSuccess => ResultCode == 200;
    }
}
