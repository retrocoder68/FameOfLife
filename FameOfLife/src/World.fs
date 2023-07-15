// FameOfLife : Copyright (C) 2023 Skywalker<j.karlsson@retrocoder.se>
module World

type World(width:int, height:int) =
    let mutable _cells:List<bool> = [for x in 0..width-1 do for y in 0..height-1 -> System.Random().Next(2) = 1]

    member val width:int = width
    member val height:int = height
    member this.cells with get() = _cells and set(value) = _cells <- value

    member this.update() =
        let newCells = List.map (fun (x,y) ->
            let neighborCount = (List.filter (fun b ->
                b = true) (List.map (fun (xn,yn) ->
                    if xn >= 0 && xn < width && yn >= 0 && yn < height && (xn <> x || yn <> y) then
                        this.cells.[xn + yn*width]
                    else
                        false) [for x in x-1..x+1 do for y in y-1..y+1 -> (x,y)])).Length
            if this.cells.[x + y*width] then neighborCount = 2 || neighborCount = 3
            else neighborCount = 3) [for y in 0..height-1 do for x in 0..width-1 -> (x,y)]
        this.cells <- newCells


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
