open System.Drawing
// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Vector
open Picture

[<EntryPoint>]
let main argv = 
    //    Bezier.cubic (Vector(100.0, 250.0)) (Vector(200.0, 150.0)) (Vector(300.0, 150.0)) (Vector(400.0, 250.0)) 10 (Color.FromArgb(100, 255, 255, 255))
    //        |> Display.showPicture
    //        |> ignore
    //    Plot.line (Vector(250.0, 250.0)) 2.0 Color.White |> Display.showPicture |> ignore
    //    Slope.curve (Vector(100.0, 250.0)) (Vector(200.0, 150.0)) (Vector(300.0, 150.0)) (Vector(400.0, 250.0)) 30 (Color.FromArgb(100, 255, 255, 255))
    //        |> Display.showPicture
    //        |> ignore
    let color = Color.FromArgb(100, 255, 255, 255)
    let rightSide = [ Slope.curve (Vector(250.0, 200.0)) (Vector(250.0, 100.0)) (Vector(400.0, 100.0)) (Vector(400.0, 200.0)) 20 color
                      Slope.curve (Vector(400.0, 200.0)) (Vector(400.0, 300.0)) (Vector(250.0, 400.0)) (Vector(250.0, 400.0)) 10 color ]
                    |> Pictures
    let leftSide = Picture.flipHorizontal (float Display.width / 2.0) rightSide
    [leftSide; rightSide]
    |> Pictures
    |> Display.showPicture
    |> ignore
    0 // return an integer exit code
