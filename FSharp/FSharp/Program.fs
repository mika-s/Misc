open CommandLineArgumentParsing
open System

let handleException (ex: Exception) =
    printfn "%s" ex.Message
    Environment.Exit 1

[<EntryPoint>]
let main argv =
    try
        let args = argv |> Array.toList
        let options = parseArgs args defaultOptions

        printfn "Read from the command line:"
        printfn "testString: %s"  options.testString
        printfn "testInteger: %d" options.testInteger
        printfn "testFloat %f"    options.testFloat
        printfn "testDouble: %f"  options.testDouble
    
        0
    with
    | _ as ex -> handleException ex; 1