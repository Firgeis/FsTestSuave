module Injector

type Injector<'dependency, 'implementation>  = 'dependency -> 'implementation

let run (dependency:'dependency) (injector: Injector<'dependency, 'implementation>) = injector dependency

let ask (s : 'c) : Injector<_, 'c> = fun _ -> s

let map f injector = injector >> f

let bind injector f = fun dependency -> f (run dependency injector) |> run dependency

type InjectorBuilder() =
    member this.Return a =
        ask a
    member this.Bind (m, f) =
        bind m f           
        
    member this.ReturnFrom v =
        v    
let Injector = new InjectorBuilder()

let addDependency1 f = fun a dependency -> f dependency a


