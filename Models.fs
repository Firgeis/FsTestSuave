namespace Models   

type public Post() =
    member val PostId = 0 with get, set
    member val Title = "" with get, set
    member val Content = "" with get, set
    member val BlogId = 0 with get, set
    member val Blog = Blog() with get, set

and public Blog() =
    member val BlogId = 0 with get, set
    member val Url = "" with get, set

    member val Posts = new System.Collections.Generic.List<Post>()



   
