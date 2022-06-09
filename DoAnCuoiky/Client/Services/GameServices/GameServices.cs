using Microsoft.AspNetCore.Components;

namespace DoAnCuoiky.Client.Services.GameServices
{
    public class GameServices : IGameServices
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public GameServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<GameModel> gameModels { get; set; } = new List<GameModel>();

        public async Task GetGameDetail()
        {
            var resutl = await _http.GetFromJsonAsync<List<GameModel>>("api/games");
            if (resutl != null)
            {
                gameModels = resutl;
            }
        }
    }
}
