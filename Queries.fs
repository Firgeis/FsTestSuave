module Queries

open DataContext
open System
open ServiceConfig
open Injector

let getBlogs =
    let blogs = Injector {
        return! getBlogs ServiceConfig.blogconfig
    }

    let blogsInDbString = "These are the blogs <br>"
    let blogsString = blogs |> Seq.fold (fun acc blog -> blog.Url::acc ) List<string>.Empty

    blogsString
    |> fun x -> blogsInDbString::x    
    |> List.fold (fun acc blogstring -> acc + "<br>" + blogstring) ""
  
