open Microsoft.Data.Sqlite
open Donald

[<EntryPoint>]
let main args =
    // fsharplint:disable-next-line RedundantNewKeyword
    let conn = new SqliteConnection("Filename=" + "./foo.db" + ";foreign keys=true")

    let sql = "INSERT INTO Test (foo) VALUES (@foo);"

    let sqlParams = [ ("foo", SqlType.String "bar") ]

    let sqlToExec = conn |> Db.newCommand sql |> Db.setParams sqlParams

    task {
        try
            let! dbResult = Db.Async.exec sqlToExec
            printfn "dbResult %A" dbResult
            ()
        with err ->
            printfn "DB Error: %A" err
    }
    |> ignore

    let sql1 = "INSERT INTO Asd (foo) VALUES (@foo);"

    let sqlParams1 = [ ("foo", SqlType.String "bar") ]

    let sqlToExec1 = conn |> Db.newCommand sql1 |> Db.setParams sqlParams1


    task {
        try
            let! dbResult = Db.Async.exec sqlToExec1
            printfn "dbResult %A" dbResult
            ()
        with err ->
            printfn "DB Error: %A" err
    }
    |> ignore

    0
