using EFTest;
using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        using var db = new BloggingContext();

// // Note: This sample requires the database to be created before running.
//         Console.WriteLine($"Database path: {db.DbPath}.");
//
// Create
        // Console.WriteLine("Inserting a new blog");
        // db.Add(new Blog { Url = "http://test1.com" });
        // db.Add(new Tag{TagId = "test1"});
        // db.SaveChanges();

       
// Read
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .OrderBy(b => b.BlogId)
            .Include(x => x.Posts)
            .First();
        Console.WriteLine("blog: "+blog);
        var post = blog.Posts.First();
        Console.WriteLine(post.PostId);
      //  Console.WriteLine(db.Posts.First());
        
//
// Update
        // Console.WriteLine("Updating the blog and adding a post");
        // blog.Url = "https://devblogs.microsoft.com/dotnet";
        // blog.Posts.Add(
        //     new Post { Title = "Hello Test", Content = "I wrote an app using EF Core!" });
        // db.SaveChanges();
        var tag = db.Tags.First();
        Console.WriteLine(tag.TagId);
        post.Tags=new List<Tag>();
        post.Tags.Add(tag);
        db.SaveChanges();

        /*Console.WriteLine("Delete the blog");
        db.Remove(blog);
        db.SaveChanges();*/
    }
}