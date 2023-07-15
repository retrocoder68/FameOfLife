// FameOfLife : Copyright (C) 2023 Skywalker<j.karlsson@retrocoder.se>
module WorldControl

open System.Drawing
open System.Windows.Forms

open World

type WorldControl(world:World) as this =
    inherit Control()

    let world:World = world

    let drawGrid(g:Graphics, w:World) =
        let cellWidth = this.Width / w.width
        let cellHeight = this.Height / w.height
        let pen = new Pen(Color.FromArgb(255, 63, 63, 80), 1.0f)
        List.map (fun (x,y) ->
            let rect = new Rectangle(cellWidth*x, cellHeight*y, cellWidth, cellHeight)
            g.DrawRectangle(pen, rect)
        ) [ for x in 0..w.width-1 do for y in 0..w.height-1 -> (x,y)] |> ignore

    let drawWorld(g:Graphics, w:World) =
        let cellWidth = this.Width / w.width
        let cellHeight = this.Height / w.height
        let brush = new SolidBrush(Color.White)
        List.map (fun (x,y) ->
            if w.cells.[x, y] then
                let rect = new Rectangle(cellWidth*x, cellHeight*y, cellWidth, cellHeight)
                g.FillRectangle(brush, rect)
        ) [ for x in 0..w.width-1 do for y in 0..w.height-1 -> (x,y)] |> ignore

    do
        this.Name <- "WorldControl"
        this.BackColor <- Color.Black

    override this.OnPaint(e:PaintEventArgs) =
        drawGrid(e.Graphics, world)
        drawWorld(e.Graphics, world)
        base.OnPaint(e)


// License
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 2 as
// published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.
// If not, see <http://www.gnu.org/licenses/> or write to the
// Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor,
// Boston, MA 02110-1301
// USA
