module Bezier

open Picture
open Vector

let point (anchor1 : Vector) (control1 : Vector) (control2 : Vector) (anchor2 : Vector) time =
    let left1 = (control1 - anchor1) * time + anchor1
    let middle1 = (control2 - control1) * time + control1
    let right1 = (anchor2 - control2) * time + control2
    let left2 = (middle1 - left1) * time + left1
    let right2 = (right1 - middle1) * time + middle1
    (right2 - left2) * time + left2

let cubic (anchor1 : Vector) (control1 : Vector) (control2 : Vector) (anchor2 : Vector) steps color =
    let times = List.map (fun i -> 1.0 / float steps * float i) [0..steps]
    let point time = point anchor1 control1 control2 anchor2 time
    let points = List.map point times
    Seq.pairwise points |> Seq.map (fun (s, e) -> Line(s, e, color)) |> Seq.toList |> Pictures