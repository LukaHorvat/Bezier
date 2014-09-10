module Extensions

open System.Drawing

type Point with
    static member Subtract(p1 : Point, p2 : Point) = Point(p2.X - p1.X, p2.Y - p1.Y)
    static member Add(p1 : Point, p2 : Point) = Point(p1.X + p2.X, p1.Y + p2.Y)