namespace BlazorServerCrud.Data
{
    //Initialize all the entities there that i want to initialize
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public String Developer { get; set; } = String.Empty;
        public DateTime? Release { get; set; }
    }
}
