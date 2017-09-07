module ServiceConfig

open DbService
open Services
let blogconfig = DbService.dbService

let getBlogs = Injector.addDependency1 (fun (res:IBlogService) -> res.GetBlogs) ()