using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrud.Data
{
    public class GameService : IGameService
    {

        //1:Import DbContext here to work with database
        //2:Add navigationManager to navigate with razor files
        //3:Readonly functions are used becz i just want to assign these files in constructors
        //4:Impliment all the crud operations here that comes from interface
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;
        public GameService(DataContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Game> Games { get; set; } = new List<Game>();
        public NavigationManager NavigationManager { get; }

        public async Task CreateGame(Game game)
        {
           _context.Games.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task DeleteGame(int id)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame == null)
                throw new Exception("There is nothing to go for");
            _context.Games.Remove(dbGame);
           await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)

                throw new Exception("There's no game");
            
            return game;
        }

        public async Task LoadGames()
        {
            ((IGameService)this).Games = await _context.Games.ToListAsync();

        }

        public async Task UpdateGame(Game game, int id)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame == null)
                throw new Exception("There is nothing to go for");
            dbGame.Name = game.Name;
            dbGame.Developer = game.Developer;
            dbGame.Release = game.Release;
        //    await _context.Entry(dbGame).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }
    }
}
