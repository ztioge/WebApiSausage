namespace WebApiSausage.Models
{
    public class Sausage
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Stock { get; set; } 
    }
}
