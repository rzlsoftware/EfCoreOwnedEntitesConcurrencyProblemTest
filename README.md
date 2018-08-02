# EfCoreOwnedEntitesConcurrencyProblemTest

Sample Project for EFCore [EF Core Issue 12865](https://github.com/aspnet/EntityFrameworkCore/issues/12865)
When changing a value of an [Owned Properties](https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities) property and than save twice, EF throws `DbUpdateConcurrencyException`.

```csharp
public class Name
{
    public string First { get; set; }
    public string Last { get; set; }
}
public class Author
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public string Description { get; set; }
    public byte[] Rowversion { get; set; }
}
```
```csharp
var author = context.Authors.First();
author.Name.First = "Lukas";
context.SaveChanges();

author.Description = "Some very important information";
context.SaveChanges();    // -> DbUpdateConcurrencyException
```
