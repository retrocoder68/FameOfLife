// FameOfLife : Copyright (C) 2023 Skywalker<j.karlsson@retrocoder.se>
module Main

open System.Windows.Forms

open MainForm
open World

[<EntryPoint>]
let main argv =
    let world = World(10, 10)
    use mainForm = new MainForm(world)
    Application.Run(mainForm)
    0


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
