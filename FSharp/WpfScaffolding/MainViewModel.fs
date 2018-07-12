module MainViewModel

open ViewModel

type MainViewModel () =
    inherit ViewModelBase ()
    let mutable testProperty = "before"
 
    // Property
    member this.TestProperty
        with get() = testProperty 
        and set(value) =
            testProperty <- value
            base.NotifyPropertyChanged(<@ this.TestProperty @>)

    // Command
    member this.ExampleCommand = 
        new FuncCommand
            (
                (fun d -> true), 
                (fun e -> this.ExampleCommandExecuteMethod) 
            )

    member public this.ExampleCommandExecuteMethod = 
        this.TestProperty <- "after"
        ()  