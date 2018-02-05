open System

let rnd = new Random()

// Функция обмена элементов
let swap (x : 'a byref) (y : 'a byref) =
    let temp = x
    x <- y
    y <- temp   

module Hello = 

    let helloWorld = "Hello world!"
    printfn "%s\n" helloWorld

    printf "Pls enter your name: "
    let name = Console.ReadLine()
    printfn "Hello %s!\n" name

module Calculation =

    printf "Enter n: "
    let n = Convert.ToInt32(Console.ReadLine())
    printf "Enter power: "
    let pow = Convert.ToInt32(Console.ReadLine())
    

    let mutable result = 1
    for i = 1 to pow do
        result <- result * n
    printfn "%d in power %d = %d\n" n pow result   

module ArrayConvert =

    let N = 20
    let a = [| for i in 1..N -> rnd.Next(1000) |]

    printfn "Array converiton:  "
    for i in a do
        printf " %d" i
    printfn ""

    // Изменение элементов
    let mutable j = 0
    for i = 0 to N - 1 do
        if a.[i] % 7 = 0 then
            a.[i] <- 7
        elif a.[i] % 5 = 0 then
            a.[i] <- 5
        elif a.[i] % 3 = 0 then
            a.[i] <- 3
        elif a.[i] % 2 = 0 then
            a.[i] <- 2
        else
            j <- j + 1

    for i in a do
        printf " %d" i
    printfn "\n unchanged numbers: %d\n" j

module SortFloatingBubble = 

    // Инициализауия массива случайными значениями
    let N = 10
    let a = [| for i in 1 .. N -> rnd.Next(100) |]

    printfn "Floating Bubble sorting: "
    for i in a do
        printf " %d" i
    printfn ""
        
    for i = 0 to N - 2 do  // Сортировка

        if a.[i] > a.[i + 1] then
            swap &a.[i] &a.[i + 1]

            let mutable j = i
            let mutable fl = true
            while (j > 0) && fl do
                if a.[j - 1] > a.[j] then
                    swap &a.[j - 1] &a.[j]
                    j <- j - 1
                else
                    fl <- false
    
    for i in a do
        printf " %d" i
    printfn "\n"       

module SortBinaryInsertion =

    // Инициализация массива случайными значениями
    let N = 10
    let a = [| for i in 1 .. N -> rnd.Next(100) |]
        
    printfn "Binary insertion sorting: "
    for i in a do
        printf " %d" i
    printfn ""

    for i = 1 to N - 1 do  // Сортировка

        let x = a.[i]
        let mutable left = 0
        let mutable right = i
            
        while left < right do
            let middle = (left + right) / 2
            if a.[middle] <= x then
                left <- middle + 1
            else
                right <- middle

        for j = i downto right + 1 do
            a.[j] <- a.[j - 1]

        a.[right] <- x

    for i in a do
        printf " %d" i
    printfn "\n"

module SortBinaryInsertion2D =  

    // Инициализауия массива случайными значениями
    let N = 5
    let a2D = Array2D.init N N (fun i j -> rnd.Next(10))

    // Вывод двумерного массива
    printfn "2D array Binary insertion sorting: "
    for i = 0 to N - 1 do
        for j = 0 to N - 1 do
            printf " %d" a2D.[i,j]
        printfn ""
    printfn ""

    for i = 0 to N - 1 do  // Сортировка
        for j = 1 to N - 1 do

            let x = a2D.[i, j]
            let mutable left = 0
            let mutable right = j
            
            while left < right do
                let middle = (left + right) / 2
                if a2D.[i, middle] <= x then
                    left <- middle + 1
                else
                    right <- middle

            for k = j downto right + 1 do
                a2D.[i, k] <- a2D.[i, k - 1]

            a2D.[i, right] <- x

    for i = 0 to N - 1 do
        for j = 0 to N - 1 do
            printf " %d" a2D.[i,j]
        printfn ""
    printfn ""

module SortFloatingBubble2D =

    // Инициализауия массива случайными значениями
    let N = 10
    let a2D = Array2D.init N N (fun i j -> rnd.Next(100))
        
    // Коректировка значений
    for i = 0 to N - 1 do
        if a2D.[i, 0] % 2 = 0 then          
            for j = 0 to N - 1 do
                match a2D.[i, j] with
                | 0 | 1 -> a2D.[i, j] <- 10
                | _ when a2D.[i, j] > 2 && a2D.[i, j] < 8 -> a2D.[i, j] <- 45
                | 8 | 9 -> a2D.[i, j] <- 88
                | _ -> a2D.[i, j] <- a2D.[i, j]
        else
            a2D.[i, 0] <- 99

    // Вывод двумерного массива
    printfn "2D array Floating Bubble sorting: "
    for i = 0 to N - 1 do
        for j = 0 to N - 1 do
            printf " %d" a2D.[i,j]
        printfn ""
    printfn ""
    
    for i = 0 to N - 1 do  // Сортировка

        for j = 0 to N - 2 do  

            if a2D.[i, j] > a2D.[i, j + 1] then
                swap &a2D.[i, j] &a2D.[i, j + 1]

                let mutable k = j
                let mutable fl = true
                while (k > 0) && fl do
                    if a2D.[i, k - 1] > a2D.[i, k] then
                        swap &a2D.[i, k - 1] &a2D.[i, k]
                        k <- k - 1
                    else
                        fl <- false

    // Вывод отсортированного двумерного массива
    for i = 0 to N - 1 do
        for j = 0 to N - 1 do
            printf " %d" a2D.[i,j]
        printfn ""
    printfn ""

Console.Read() |> ignore


