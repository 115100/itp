let rng = System.Random()
let coinTosses n results : list<string> =
  [for i in 1 .. n -> if rng.Next(0, 2) = 0 then "H" else "T"] @ results

let proportionHeads tosses : float =
  float(List.sumBy (fun t -> if t = "H" then 1 else 0) tosses) / float(tosses.Length)

let headsMinusHalfTosses tosses : int =
  List.sumBy (fun t -> if t = "H" then 1 else 0) tosses - tosses.Length / 2

let rec runGame (results : list<string>) =
  if results.Length > 0 then
    printfn "n_H/n - 1/2: %G17" (proportionHeads results - 0.5)
    printfn "n_H - n/2:   %d" (headsMinusHalfTosses results)
    System.Threading.Thread.Sleep(250)

  runGame (coinTosses 100 results)

[<EntryPoint>]
let main argv =
  runGame []
  0
