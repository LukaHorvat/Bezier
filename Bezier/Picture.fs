module Picture

open System.Drawing
open Vector

type Picture =
    | Line of Vector * Vector * Color
    | Pictures of Picture list

let rec allLines picture =
    match picture with
    | Line(s, e, c) -> [ (s, e, c) ]
    | Pictures list -> List.collect allLines list
    
let rec flipHorizontal axisX picture =
    match picture with
    | Line(s, e, c) -> 
        let flipVec (Vector(x, y)) = Vector(2.0 * axisX - x, y)
        Line(flipVec s, flipVec e, c)
    | Pictures list -> Pictures (List.map (flipHorizontal axisX) list)

let rec flipVertical axisY picture =
    match picture with
    | Line(s, e, c) -> 
        let flipVec (Vector(x, y)) = Vector(x, 2.0 * axisY - y)
        Line(flipVec s, flipVec e, c)
    | Pictures list -> Pictures (List.map (flipVertical axisY) list)

let rec shift delta pic =
    match pic with
    | Line(s, e, c) -> Line(s + delta, e + delta, c)
    | Pictures list -> Pictures (List.map (shift delta) list) 