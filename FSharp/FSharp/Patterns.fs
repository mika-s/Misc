module Patterns

open System

let (|Int|_|) str =
    match Int32.TryParse(str) with
    | (true, int) -> Some(int)
    | _           -> None

let (|Float|_|) str =
    match Single.TryParse(str) with
    | (true, float) -> Some(float)
    | _             -> None 

let (|Double|_|) str =
    match Double.TryParse(str) with
    | (true, double) -> Some(double)
    | _              -> None 

let (|Equals|_|) arg x = if (arg = x) then Some() else None
