module Patterns

open System

let (|Int|_|) str =
    match Int32.TryParse(str) with
    | (true, int) -> Some(int)
    | _           -> None 

let (|Equals|_|) arg x = if (arg = x) then Some() else None
