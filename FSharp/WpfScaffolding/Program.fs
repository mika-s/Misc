(* 
    - Change "Output type" in the project's properties to Windows application.
    - Add reference to PresentationCore, PresentationFramework, System.Xaml and WindowsBase.
*)

open System
open System.Windows
open MainViewModel

[<STAThread>]
[<EntryPoint>]
let main argv = 
    let mainWindow = Application.LoadComponent(new System.Uri("/WpfScaffolding;component/MainWindow.xaml", UriKind.Relative)) :?> Window
    mainWindow.DataContext <- new MainViewModel() :> obj
 
    let application = new Application()
    application.Run(mainWindow)
