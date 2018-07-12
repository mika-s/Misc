module ViewModel

open System
open System.ComponentModel
open System.Windows.Input
open Microsoft.FSharp.Quotations.Patterns

type ViewModelBase () =
    let propertyChanged = 
        Event<PropertyChangedEventHandler, PropertyChangedEventArgs>()

    let getPropertyName = function
        | PropertyGet(_, pi, _) -> pi.Name
        | _ -> invalidOp "Expecting property getter expression"

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = propertyChanged.Publish

    member private this.NotifyPropertyChanged propertyName = 
        propertyChanged.Trigger(this, PropertyChangedEventArgs(propertyName))

    member this.NotifyPropertyChanged quotation = 
        quotation |> getPropertyName |> this.NotifyPropertyChanged

    // Type for making commands.
    type FuncCommand (canExec:(obj -> bool),doExec:(obj -> unit)) =
        let cecEvent = new DelegateEvent<EventHandler>()

        interface ICommand with
            [<CLIEvent>]
            member this.CanExecuteChanged = cecEvent.Publish
            member this.CanExecute arg = canExec(arg)
            member this.Execute arg = doExec(arg)
