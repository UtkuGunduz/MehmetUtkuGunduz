namespace MehmetUtkuGunduz.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Estate> Estates { get; set; }
    }
}