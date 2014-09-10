module Vector

type Vector = 
    | Vector of float * float
    static member (+) (Vector(x1, y1), Vector(x2, y2)) = Vector(x1 + x2, y1 + y2)
    static member (-) (Vector(x1, y1), Vector(x2, y2)) = Vector(x1 - x2, y1 - y2)
    static member (*) (Vector(x, y), s) = Vector(x * s, y * s)

let toPoint (Vector(x, y)) = System.Drawing.PointF(float32 x, float32 y)