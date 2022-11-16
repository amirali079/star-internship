namespace EFTest;


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public string DbPath { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts);
        
        modelBuilder.Entity<Blog>()
            .Navigation(b => b.Posts)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
        
        modelBuilder
            .Entity<Post>()
            .HasMany(p => p.Tags)
            .WithMany(p => p.Posts)
            .UsingEntity(j => j.ToTable("PostTags"));
       
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.
            UseNpgsql("Host=localhost;Database=blogging3;Username=postgres;Password=root");

}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public ICollection<Post> Posts { get; set; }
    
    public override string ToString()
    {
        return "Blog: " + BlogId + " " + Url+ " " + Posts.Count;
    }
    
}
public class Tag
 {
     public string TagId { get; set; }
 
     public ICollection<Post> Posts { get; set; }
 }
public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public ICollection<Tag> Tags { get; set; }
    
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}


