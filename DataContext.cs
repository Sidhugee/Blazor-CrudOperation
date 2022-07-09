using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrud.Data
{
    //1: Create DBCOntext to work as a bridge between database and Code
    //2: Make a constructor that calls automatically
    //3: Then make a dbSet class that gets all the information related to database
    //4:Then add the data for check and balance using modelebuilder 
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions <DataContext> options)
            : base(options) { }
        //Base is used to get the instance of base class while this is for current class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
               new Game {Id = 1, Name = "World War", Developer = "Sallal", Release = new DateTime(2004,11,16) },
               new Game { Id = 2, Name = "Love And Fight", Developer = "Sallal1", Release = new DateTime(2005, 12, 17) });     
        }
        public DbSet <Game> Games =>  Set<Game>(); 
        //DbSet correspondes to the Data in database.

    }
}
