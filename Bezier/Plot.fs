module Plot

open Vector
open Picture

let random = System.Random()

let line (Vector(x, y)) delta color = 
//    let delta = max -100.0 (min 100.0 delta)
    let delta = delta + (random.NextDouble() - 0.5)
    let right = float (float Display.width - x) * delta + y
    let left = float (0.0 - x) * delta + y
    let inv = 1.0 / delta
    let top = float (float Display.height - y) * inv + x
    let bottom = float (0.0 - y) * inv + x
    
    let e = 
        if float Display.height < right then Vector(top, float Display.height)
        else if 0.0 < right then Vector(float Display.width, right)
        else Vector(bottom, 0.0)
    let s = 
        if float Display.height < left then Vector(top, float Display.height)
        else if 0.0 < left then Vector(0.0, left)
        else Vector(bottom, 0.0)
    Line(s, e, color)
