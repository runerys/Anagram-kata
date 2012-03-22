

let printSeq seq1 = 
    Seq.iter (fun (a) -> Seq.iter (fun (s) -> printf "%s " s) a) seq1

let sortWord (word:string) = 
    word.Trim().ToLower().ToCharArray()
    |> Array.sort 
    |> System.String.Concat;

let findAnagrams input = 
    input 
    |> Seq.groupBy sortWord 
    |> Seq.filter (fun (_, values) -> Seq.length values > 1)
    |> Seq.map (fun(_, values) -> values)    

let FindAnagramsInFile filename = 
    System.IO.File.ReadAllLines (filename)
    |> findAnagrams

["word"; "drow"; "sword"; "words"; "ggg"]
   |> findAnagrams
   |> printSeq
