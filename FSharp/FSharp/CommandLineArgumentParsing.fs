module CommandLineArgumentParsing

open System
open Patterns

type Mode = None | Exceptions | XML | JSON | Patterns | Util

type options = {
    mode: Mode
    testString: string          // Read a string.
    testInteger: int            // Read an integer.
    testFloat: float32          // Read a float.
    testDouble: double          // Read a double.
}

let defaultOptions = {
    mode        = Mode.None;
    testString  = String.Empty;
    testInteger = -1;
    testFloat   = -1.0f;
    testDouble  = -1.0;
}

let printUsage () =
    printfn "Usage:"
    printfn "dotnet Fsharp.dll [-m <Exceptions/XML/JSON/Patterns/Util>] [-s <string>] [-i <int>] [-f <float>] [-d <double>]"

let rec parseArgs (args: list<string>) (options: options) =
    match args with
    | [] -> options
    | "-h"::xs ->
        printUsage ()
        Environment.Exit 1; parseArgs xs options
    | "-m"::xs ->
        match xs with
        | "Exceptions"::xss ->
            let newOptions = { options with mode = Mode.Exceptions }
            parseArgs xss newOptions
        | "XML"::xss ->
            let newOptions = { options with mode = Mode.XML }
            parseArgs xss newOptions
        | "JSON"::xss ->
            let newOptions = { options with mode = Mode.JSON }
            parseArgs xss newOptions
        | "Patterns"::xss ->
            let newOptions = { options with mode = Mode.Patterns }
            parseArgs xss newOptions
        | "Util"::xss ->
            let newOptions = { options with mode = Mode.Util }
            parseArgs xss newOptions
        | _ ->
            invalidArg "-m" "-m flag needs either Exceptions, XML, JSON, Patterns or Util\n"
            parseArgs xs options
    | "-s"::xs ->
        match xs.Length with
        | length when 1 <= length ->
            match xs.[0] with
            | "-s" | "-i" | "-d" | "-f" -> invalidArg "-s" "-s flag needs a string after it\n"
            | _ ->
                let newOptions = { options with testString = xs.[0] }
                let xss = List.skip 1 xs
                parseArgs xss newOptions
        | _ -> invalidArg "-s" "-s flag needs a string after it\n"
    | "-i"::xs ->
        match xs with
        | (Int i)::xss ->
            let newOptions = { options with testInteger = i }
            parseArgs xss newOptions
        | _ -> invalidArg "-i" "-i flag needs an integer after it\n"
    | "-f"::xs ->
        match xs with
        | (Float f)::xss ->
            let newOptions = { options with testFloat = f }
            parseArgs xss newOptions
        | _ -> invalidArg "-f" "-f flag needs a float after it\n"
    | "-d"::xs ->
        match xs with
        | (Double d)::xss ->
            let newOptions = { options with testDouble = d }
            parseArgs xss newOptions
        | _ -> invalidArg "-d" "-d flag needs a double after it\n"
    | x::xs ->
        eprintf "Illegal argument: %s\n" x
        parseArgs xs options 
