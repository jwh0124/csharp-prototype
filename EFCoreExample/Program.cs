// See https://aka.ms/new-console-template for more information
using EFCoreExample.context;
using EFCoreExample.Models;

using var db = new ExampleContext();

Console.WriteLine($"Database path : {db.DbPath}");

// Delete
Console.WriteLine("Clean up database");
db.Users.RemoveRange(db.Users);

// Create
Console.WriteLine("Inserting a new user");
db.Add(new User { Id = 1, Name = "tester" });
db.SaveChanges();


// Read
Console.WriteLine("Querying for a user");
var user = db.Users.First();
Console.WriteLine(user.Id);
Console.WriteLine(user.Name);

// Update
Console.WriteLine("Updating the user");
user.Name = "Test";
db.SaveChanges();
