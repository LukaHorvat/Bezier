module Slope

open Vector
open Picture

let curve anchor1 control1 control2 anchor2 steps color =
    let times = List.map (fun i -> 1.0 / float steps * float i) [0..steps]
    let point time = Bezier.point anchor1 control1 control2 anchor2 time
    let derivative time =
        let (Vector(x, y)) = point (time + 0.001) - point time
        y / x
    let points = List.map point times
    let derivatives = List.map derivative times
    let line v d = Plot.line v d color
    List.map2 line points derivatives |> Pictures