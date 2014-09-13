module Slope

open Vector
open Picture
open System.Drawing

let curve anchor1 control1 control2 anchor2 steps (color1 : Color) (color2 : Color) = 
    let times = List.map (fun i -> 1.0 / float steps * float i) [ 0..steps - 1 ]
    let point time = Bezier.point anchor1 control1 control2 anchor2 time
    
    let derivative time = 
        let (Vector(x, y)) = point (time + 0.001) - point time
        y / x
    
    let points = List.map point times
    let derivatives = List.map derivative times
    let colorToList (color : Color) = [ float color.A; float color.R; float color.G; float color.B ]
    let listToColor [ a; r; g; b ] = Color.FromArgb(int a, int r, int g, int b)
    let colors = 
        List.map 
            (fun t -> 
            List.map2 (+) (List.map ((*) (1.0 - t)) (colorToList color1)) (List.map ((*) t) (colorToList color2)) 
            |> listToColor) times
    List.map3 Plot.line points derivatives colors |> Pictures
