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
    let color1 = Color.FromArgb(1, 255, 0, 0)
    let color2 = Color.FromArgb(1, 255, 255, 0)
    let color3 = Color.FromArgb(1, 0, 255, 255)
    let color = Color.FromArgb(1, 255, 255, 255)
    let rightSide = [ Slope.curve (Vector(250.0 + float Display.width / 2.0 - 250.0, 200.0 + float Display.height / 2.0 - 250.0)) (Vector(250.0 + float Display.width / 2.0 - 250.0, 100.0 + float Display.height / 2.0 - 250.0)) (Vector(400.0 + float Display.width / 2.0 - 250.0, 100.0 + float Display.height / 2.0 - 250.0)) (Vector(400.0 + float Display.width / 2.0 - 250.0, 200.0 + float Display.height / 2.0 - 250.0)) 4000 color color
                      Slope.curve (Vector(400.0 + float Display.width / 2.0 - 250.0, 200.0 + float Display.height / 2.0 - 250.0)) (Vector(400.0 + float Display.width / 2.0 - 250.0, 300.0 + float Display.height / 2.0 - 250.0)) (Vector(250.0 + float Display.width / 2.0 - 250.0, 400.0 + float Display.height / 2.0 - 250.0)) (Vector(250.0 + float Display.width / 2.0 - 250.0, 400.0 + float Display.height / 2.0 - 250.0)) 2000 color color ]
                    |> Pictures
    let leftSide = Picture.flipHorizontal (float Display.width / 2.0) rightSide
    [leftSide; rightSide]
    |> Pictures
    |> Display.savePicture @"C:\Users\Luka\Pictures\heart.png"
//    |> Display.showPicture
//    [ Line(Vector(100.0, 0.0), Vector(100.0, 1050.0), Color.FromArgb(255, 255, 0, 0))
//      Line(Vector(200.0, 0.0), Vector(200.0, 1050.0), Color.FromArgb(255, 255, 125, 0))
//      Line(Vector(300.0, 0.0), Vector(300.0, 1050.0), Color.FromArgb(255, 255, 255, 0)) ]
//    |> Pictures
//    |> Display.showPicture
    0 // return an integer exit code
