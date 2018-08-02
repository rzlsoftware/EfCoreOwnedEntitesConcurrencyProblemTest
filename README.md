# EfCoreOwnedEntitesConcurrencyProblemTest

Sample Project for EFCore [EF Core Issue ####]()
When changing a value of an [Owned Properties](https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities) property and than save twice, EF throws `DbUpdateConcurrencyException`.

```csharp
var author = context.Authors.First();
author.Name.First = "Lukas";
context.SaveChanges();

author.Description = "Some very important information";
context.SaveChanges();    // -> DbUpdateConcurrencyException
```
