# F# style

## Operators

### |> (pipe)

* Do use `|>`.

### <|

* Don't use `<|` in beginner code.
* Don't put `|>` and `<|` on the same line.

### ||> (pipe tuple)

Use `||>` with fold and mapFold.

```fsharp
let newList = (initState, myList) ||> List.fold (fun state x => state + x) 

```

### <|| and <|||

* Don't use these operators.

### >> (function composition)

* Do use `>>`.
* Don't go bananas with function composition.

## Functions

### fold

Consider using these before fold:

* List/Seq/Array.sumBy
* List/Seq/Array.maxBy
* List/Seq/Array.choose
* List/Seq/Array.tryPick
* List/Seq/Array.mapFold
* List/Seq/Array.reduce


## Objects

### Dos and don'ts

* Object programming rather than object-oriented programming.
* Use expression-oriented objects.

Good (embrace):

* dot notation
* instance members
* type-directed name resolution
* implicit constructors
* static members
* indexer notation
* named arguments
* optional arguments
* interface types and implementations

Tolerate:

* mutable data
* operator on types
* auto properties
* IDisposable, IEnumerable
* type extensions
* events
* structs
* delegates
* enums
* type casting

Avoid:

* large type hierarchies
* implementation inheritance
* nulls and Unchecked.defaultof<>
* method overloading

Don't use (not supported):

* curried method overloads
* protected members
* self types
* wildcard types
* aspect oriented programming

### Mutability

* Don't use `ref`. Use `let mutable` instead.
* Don't use `null`.

### F# functions before C# methods

* Use printf rather than Console.WriteLine.
* Use bprintf rather than StringBuilder.

