module DbService

open DataContext
open System
open Services

let getBlogs =
    use db = new BloggingContext()  

    db.Blogs |> List.ofSeq
let dbService = 
    { 
        new IBlogService with
            member this.GetBlogs () = getBlogs
    }



