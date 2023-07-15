// FameOfLife : Copyright (C) 2023 Skywalker<j.karlsson@retrocoder.se>
namespace Win32Native

open System.Runtime.InteropServices

module User32 =

    type NativeMessage =
        struct
            val mutable handle  : System.IntPtr
            val mutable msg     : uint32
            val mutable wParam  : uint32
            val mutable lParam  : uint32
            val mutable time    : uint32
            val mutable pt_x    : int32
            val mutable pt_y    : int32
            val mutable lPrivate : uint32
        end

    [<DllImport(@"User32.dll")>]
    extern int PeekMessage(NativeMessage message, System.IntPtr window, uint filterMin, uint filterMax, uint remove);


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
