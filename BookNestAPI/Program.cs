using Microsoft.EntityFrameworkCore;
using BookNestAPI.Models;
using BookNestAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core with InMemory database
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("BookDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/books", async (Book book, AppDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapGet("/books", async (string? author, bool? isRead, AppDbContext db) =>
{
    var query = db.Books.AsQueryable();

    if (!string.IsNullOrEmpty(author))
        query = query.Where(b => b.Author.Contains(author));

    if (isRead.HasValue)
        query = query.Where(b => b.IsRead == isRead.Value);

    return await query.ToListAsync();
});

app.MapPut("/books/{id}", async (int id, Book updatedBook, AppDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();

    book.Title = updatedBook.Title;
    book.Author = updatedBook.Author;
    book.YearPublished = updatedBook.YearPublished;
    book.IsRead = updatedBook.IsRead;

    await db.SaveChangesAsync();
    return Results.Ok(book);
});

app.MapDelete("/books/{id}", async (int id, AppDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
