module Xml

open System.Runtime.Serialization
open System.Xml

let writeDataToXmlFile<'T> (filename: string) (objToWrite: obj) (xmlSerializerSettings: XmlWriterSettings) = 
    let serializer = DataContractSerializer(typedefof<'T>)

    use xw = XmlWriter.Create(filename, xmlSerializerSettings)

    serializer.WriteObject(xw, objToWrite)
