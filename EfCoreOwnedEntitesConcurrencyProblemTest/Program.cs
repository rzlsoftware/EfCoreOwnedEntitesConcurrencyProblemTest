namespace EfCoreOwnedEntitesConcurrencyProblemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BookDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Authors.AddRange(
                    new Author { Name = new Name { First = "Peter", Last = "Lustig" } },
                    new Author { Name = new Name { First = "Franz Xaver", Last = "Gruber" } });
                context.SaveChanges();
            }
        }
    }
}
