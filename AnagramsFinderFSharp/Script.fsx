

let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""

let sortWord (word:string) = 
    word.Trim().ToLower().ToCharArray()
    |> Array.sort 
    |> System.String.Concat;

let printAnagrams input = 
    input 
    |> Seq.groupBy sortWord 
    |> Seq.filter (fun (_, values) -> Seq.length values > 1)
    |> Seq.iter (fun (_, values) -> printSeq values) // hvordan kan jeg få verdiene ut som en seq<seq<string>>?

["word"; "drow"; "sword"; "words"; "ggg"]
   |> printAnagrams 

// Real words
System.IO.File.ReadAllLines @"C:\Users\rune.rystad\Downloads\wordlist.txt"
 |> printAnagrams