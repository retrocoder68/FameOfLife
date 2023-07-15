// FameOfLife : Copyright (C) 2023 Skywalker<j.karlsson@retrocoder.se>
module MainForm

open System.Drawing
open System.Windows.Forms

open World
open WorldControl

open Win32Native

type MainForm(world:World) as this =
    inherit Form()

    let worldControl = new WorldControl(world)

    let whenIdle(e:System.EventArgs) =
        while this.appIsIdle do
            world.update()
            this.Refresh()

            // Slow down by waiting 100 ms
            System.Threading.Thread.Sleep(100) |> ignore
        ()

    do
        this.Name <- "MainForm"
        this.Text <- "FameOfLife"
        this.FormBorderStyle <- FormBorderStyle.FixedDialog
        this.MaximizeBox <- false
        this.MinimizeBox <- false
        this.StartPosition <- FormStartPosition.CenterScreen
        this.ClientSize <- new Size(800, 600)

        // worldControl
        worldControl.Location <- new Point(0,0)
        worldControl.Size <- new Size(800, 600)
        this.Controls.Add(worldControl)

        Application.Idle.Add(whenIdle);

    member this.appIsIdle =
        let result = new User32.NativeMessage()
        User32.PeekMessage(result, System.IntPtr.Zero, (uint)0, (uint)0, (uint)0) = 0;


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

