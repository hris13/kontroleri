namespace Productapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        internal object updateColor(Product product, string id)
        {
            throw new NotImplementedException();
        }
    }
}
