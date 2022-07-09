namespace BlazorServerCrud.Data
{
    public interface IGameService
    {
        //1: Initialize which database i'm gonna use
        //2:Import all the functions on which i'm gonna work
        public List<Game> Games { get; set; }
        Task LoadGames();
        Task<Game> GetSingleGame(int id);
        Task UpdateGame(Game game , int id);
        Task DeleteGame(int id);    
        Task CreateGame(Game game);
    }
}


