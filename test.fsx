#r "nuget: FsHttp"
#r "nuget: OpenAI"
open System
open FsHttp
open OpenAI_API
// opening open ai
open OpenAI
open OpenAI.Client
open OpenAI.Models
// giving chatgpt a promt, which will be transforming a vtt file into remnote friendly format
let result =
    client
    |> completions
    |> Completions.create
        { Model = "text-davinci-003"
          Prompt = "What is the meaning of living?"
          Temperature = 0.5
          Stop = "." }


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
    

