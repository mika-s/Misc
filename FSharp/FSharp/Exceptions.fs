﻿module Exceptions

let throwsException () =
    failwith "This throws an ordinary Exception"

let throwsInvalidOperationException () =
    invalidOp "This throws an InvalidOperationException"

let throwsArgumentException () =
    invalidArg "arg1" "This throws an ArgumentException"

