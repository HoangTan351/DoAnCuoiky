namespace DoAnCuoiky.Client.Services.GameServices
{
    public interface IGameServices
    {
        List<GameModel> gameModels { get; set; }
        Task GetGameDetail();
    }
}
