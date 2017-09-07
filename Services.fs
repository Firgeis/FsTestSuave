module Services

open Models 
type IBlogService =
    abstract GetBlogs: unit -> Blog list