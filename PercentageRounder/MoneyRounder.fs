module MoneyRounder

open System

let rec assignRemainder resolution target remainders res =
    let sum = res |> Seq.sumBy snd
    match sum = target with
    | true -> res
    | false ->
        let (maxKey, _) = remainders |> Seq.maxBy snd
        let notMaxKey (K, _) = K <> maxKey
        let pre = res |> Seq.takeWhile notMaxKey
        let post = res |> Seq.skipWhile notMaxKey |> Seq.skip 1
        let (_, currVal) = res |> Seq.find (fun (k, _) -> k = maxKey)
        let newItem = [(maxKey, currVal + resolution)] |> Seq.ofList
        assignRemainder resolution target (remainders |> Seq.filter notMaxKey)  (Seq.concat [|pre; newItem; post|])

let roundDown (number: decimal) (decimalPlaces:int) =
    Math.Floor(number * (pown 10 decimalPlaces |> decimal)) / (pown 10 decimalPlaces |> decimal);

let round (items: seq<(string * decimal)>) =
    let targetSum = items |> Seq.map snd |> Seq.sum
    let roundedDown = items |> Seq.map (fun (k, v) -> (k, (roundDown v 2)))
    let remainders = items |> Seq.map (fun (k, v) -> (k, (v % 0.01m)))
    assignRemainder 0.01m targetSum remainders roundedDown