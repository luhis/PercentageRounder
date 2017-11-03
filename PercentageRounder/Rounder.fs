module Rounder

open System

let rec assignRemainder resolution target remainders res sumFunc =
    let sum = res |> sumFunc
    match sum = target with
    | true -> res
    | false ->
        let (maxKey, _) = remainders |> Seq.maxBy snd
        let notMaxKey (K, _) = K <> maxKey
        let pre = res |> Seq.takeWhile notMaxKey
        let post = res |> Seq.skipWhile notMaxKey |> Seq.skip 1
        let (_, currVal) = res |> Seq.find (fun (k, _) -> k = maxKey)
        let newItem = [(maxKey, currVal + resolution)] |> Seq.ofList
        assignRemainder resolution target (remainders |> Seq.filter notMaxKey)  (Seq.concat [|pre; newItem; post|]) sumFunc

let round items =
    let targetSum = items |> Seq.sumBy snd |> int
    let roundedDown = items |> Seq.map (fun (k, v) -> (k, (v |> int)))
    let remainders = items |> Seq.map (fun (k, v) -> (k, (v % 1m)))
    assignRemainder 1 targetSum remainders roundedDown (Seq.sumBy snd)
