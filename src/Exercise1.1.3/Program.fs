let rng = System.Random()
let tripleDiceSum () : int =
  rng.Next(1, 7) + rng.Next(1, 7) + rng.Next(1, 7)

let rec runGame n i nines tens =
  if i >= n then
    printfn "Number of nines: %d" nines
    printfn "Number of tens:  %d" tens
    ()
  else
    match tripleDiceSum() with
    | 9  -> runGame n (i+1) (nines+1) tens
    | 10 -> runGame n (i+1) nines (tens+1)
    | _  -> runGame n (i+1) nines tens

[<EntryPoint>]
let main argv =
  let n = 100

  runGame n 0 0 0
  0
