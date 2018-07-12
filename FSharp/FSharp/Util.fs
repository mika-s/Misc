module Util

open System
open System.Collections.Generic
open System.Reflection

let convertPlainObjectToDictionary (obj: obj) =
    let bindingFlags = BindingFlags.DeclaredOnly ||| BindingFlags.Public ||| BindingFlags.Instance
    let propertyInfoArray = obj.GetType().GetProperties(bindingFlags)

    let mapper (x: PropertyInfo)  = x.Name, x.GetValue(obj, null)
    let folder (acc: Dictionary<string, obj>) (y: string * obj) = acc.Add(fst y, snd y); acc

    propertyInfoArray |> Array.map mapper |> Array.fold folder (Dictionary<string, obj>())

let convertDictToMap (dictionary : IDictionary<_,_>) = 
    dictionary |> Seq.map (|KeyValue|) |> Map.ofSeq

let mergeMaps (a: Map<'a,'b>) (b: Map<'a,'b>) = 
    Map.fold (fun acc key value -> Map.add key value acc) a b

let mergeDictsIntoMap (a: IDictionary<'a, 'b>) (b: IDictionary<'a, 'b>) =
    let aMap = convertDictToMap a
    let bMap = convertDictToMap b

    mergeMaps aMap bMap

let isOdd  (x: int) = x % 2 <> 0
let isEven (x: int) = x % 2 =  0

let intFromChar (x: char) = int(Char.GetNumericValue x)

let randomIntBetween (min: int) (max: int) = Random().Next(min, max)
let randomFloatBetween (min: float) (max: float)= Random().NextDouble()* (max - min) + min 
