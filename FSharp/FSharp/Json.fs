module Json

open System.IO
open System.Runtime.Serialization.Json
open System.Text
open Newtonsoft.Json

let readDataFromJsonFileWithJsonNet<'T> (filename: string) =
    let readJson = File.ReadAllText(filename)
    JsonConvert.DeserializeObject<'T>(readJson);

let writeDataToJsonFileWithJsonNet<'T> (filename: string) (objToWrite: obj) (jsonSerializerSettings: JsonSerializerSettings) = 
    let output = JsonConvert.SerializeObject(objToWrite, jsonSerializerSettings)
                 |> Encoding.UTF8.GetBytes

    use fs = new FileStream(filename, FileMode.Create, FileAccess.Write)

    fs.Write(output, 0, output.Length)

let deserializeJson<'T> (json: string) =
    use ms = new MemoryStream(Encoding.UTF8.GetBytes(json))

    let jsonSerializer = DataContractJsonSerializer(typedefof<'T>)

    jsonSerializer.ReadObject(ms) :?> 'T

let readDataFromJsonFile<'T> (filename: string) =
    let json = File.ReadAllText(filename)

    deserializeJson<'T> json

let writeDataToJsonFile<'T> (filename: string) (objToWrite: obj) = 
    use fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write)

    let jsonSerializer = DataContractJsonSerializer(typedefof<'T>)

    jsonSerializer.WriteObject(fs, objToWrite) 
