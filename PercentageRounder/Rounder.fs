module Rounder

let rec assignRemainder target remainders res =
    let sum = res |> Seq.sumBy snd
    match sum = target with
    | true -> res
    | false ->
        let (maxKey, _) = remainders |> Seq.maxBy snd
        let notMaxKey (K, _) = K <> maxKey
        let pre = res |> Seq.takeWhile notMaxKey
        let post = res |> Seq.skipWhile notMaxKey |> Seq.skip 1
        let (_, currVal) = res |> Seq.find (fun (k, _) -> k = maxKey)
        let newItem = [(maxKey, currVal + 1)] |> Seq.ofList
        assignRemainder target (remainders |> Seq.filter notMaxKey)  (Seq.concat [|pre; newItem; post|])

let round items =
    let targetSum = items |> Seq.sumBy snd |> int
    let roundedDown = items |> Seq.map (fun (k, v) -> (k, (v |> int)))
    let remainders = items |> Seq.map (fun (k, v) -> (k, (v % 1m )))
    assignRemainder targetSum remainders roundedDown
