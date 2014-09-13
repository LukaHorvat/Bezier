module Display

open System.Windows.Forms
open System.Drawing
open System.Drawing.Drawing2D

let width = 4096  
let height = 2160 

let pictureBox = new PictureBox(Size = new Size(width, height), Location = new Point(0, 0), Image = new Bitmap(width, height))

let form = 
    let form = new Form(ClientSize = new Size(width, height))
    form.Controls.Add(pictureBox)
    form

let gfx = 
    let gfx = Graphics.FromImage(pictureBox.Image)
    gfx.SmoothingMode <- SmoothingMode.HighQuality 
    gfx.InterpolationMode <- InterpolationMode.HighQualityBicubic
    gfx.PixelOffsetMode <- PixelOffsetMode.HighQuality
    gfx

let drawPicture pic =
    let lines = Picture.allLines pic
    gfx.Clear(Color.Black)
    List.iter (fun (s, e, c) -> gfx.DrawLine(new Pen(c : Color), Vector.toPoint s, Vector.toPoint e)) lines

let showPicture pic = 
    drawPicture pic
    form.ShowDialog() |> ignore

let savePicture path pic =
    drawPicture pic
    pictureBox.Image.Save(path)