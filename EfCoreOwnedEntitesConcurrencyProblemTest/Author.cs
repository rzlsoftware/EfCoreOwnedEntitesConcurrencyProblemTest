namespace EfCoreOwnedEntitesConcurrencyProblemTest
{
    public class Author
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Description { get; set; }
        public byte[] Rowversion { get; set; }
    }
}
