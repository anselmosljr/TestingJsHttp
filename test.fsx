#r "nuget: FsHttp"
open System
open FsHttp


open System.IO

let printSourceLocation() =
    printfn "Line: %s" __LINE__
    printfn "Source Directory: %s" __SOURCE_DIRECTORY__
    printfn "Source File: %s" __SOURCE_FILE__
printSourceLocation()

let path = Path.Join(__SOURCE_DIRECTORY__, "/obj/vttt.txt")
let readLines (filePath:string) = seq {
    use sr = new StreamReader (path)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

Console.WriteLine(path)

let logradouro = 
    http {
        GET "viacep.com.br/ws/65074860/json/"
        CacheControl "no-cache"
    }
    |> Request.send
    |> Response.toJson
    |> fun json -> json?logradouro.GetString()
    

