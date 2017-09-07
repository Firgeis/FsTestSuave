module XmlService

open System.Xml.Linq
open Models
open Services

let xn name = XName.Get(name)

let getBlogs =
    let document = XDocument.Load("blogging.xml")

    document.Element(xn "Blogs").Descendants(xn "Blog")
    |> Seq.map (fun blog ->
        let b = new Blog()
        b.BlogId <- blog.Descendants(xn "BlogId") |> Seq.head |> fun element -> element.Value |> int  
        b.Url <- blog.Descendants(xn "Url") |> Seq.head |> fun element -> element.Value
        b
    )
    |> List.ofSeq

let xmlService = 
    {
        new IBlogService with
            member this.GetBlogs () = getBlogs
    }