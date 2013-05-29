﻿// MvpMaster
// Copyright (C) 2013 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace DustInTheWind.MvpMaster.Window
{
    /// <summary>
    /// Specifies the methods that can be used from the rest of the application to interact with the window.
    /// </summary>
    public interface IWindowController
    {
        /// <summary>
        /// Event raised after the view is closed.
        /// </summary>
        event EventHandler ViewClosed;

        /// <summary>
        /// Displays the view.
        /// </summary>
        void ShowWindow();

        /// <summary>
        /// Puts the focus on the view.
        /// </summary>
        void FocusWindow();
    }
}
