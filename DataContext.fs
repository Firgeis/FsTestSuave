module DataContext

open Microsoft.EntityFrameworkCore
open Models

type public BloggingContext() =
    inherit DbContext()

    [<DefaultValueAttribute>] val mutable blogs: DbSet<Blog>
    member this.Blogs with get() = this.blogs and set v = this.blogs <- v

    [<DefaultValueAttribute>] val mutable posts: DbSet<Post>
    member this.Posts with get() = this.posts and set v = this.posts <- v

    override this.OnConfiguring(optionsBuilder:DbContextOptionsBuilder) =
        optionsBuilder.UseSqlite("Data Source=blogging.db") |> ignore