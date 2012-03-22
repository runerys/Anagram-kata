module AnagramsFinderFSharp


let sortWord (word:string) = 
    word.Trim().ToLower().ToCharArray()
    |> Array.sort 
    |> System.String.Concat

let findAnagrams words  = 
    words 
    |> Seq.groupBy sortWord 
    |> Seq.filter (fun (_, values) -> Seq.length values > 1)
    |> Seq.map (fun(_, values) -> String.concat " " values)    

let findAnagramsInFile filename = 
    System.IO.File.ReadAllLines (filename)
    |> findAnagrams