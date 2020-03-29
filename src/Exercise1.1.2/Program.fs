let rng = System.Random()
let coinTosses n : list<string> =
  [for i in 1 .. n -> if rng.Next(0, 2) = 0 then "H" else "T"]

let proportionHeads tosses : float =
  float(List.sumBy (fun t -> if t = "H" then 1 else 0) tosses) / float(tosses.Length)

let rec runGame n repeats (i : int) (inRange : int) =
  if i >= repeats then
    inRange
  else
    let p = proportionHeads (coinTosses n)
    if p >= 0.4 && p <= 0.6 then
      runGame n repeats (i+1) (inRange+1)
    else
      runGame n repeats (i+1) inRange

[<EntryPoint>]
let main argv =
  let n = 100

  printfn "%d results in range 0.4 <= proportion heads <= 0.6" (runGame n 100 0 0)
  0
