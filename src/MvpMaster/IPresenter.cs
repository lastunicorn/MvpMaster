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

namespace DustInTheWind.MvpMaster
{
    /// <summary>
    /// Contains the UI logic for a view.
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// Gets or sets the view that represents the GUI.
        /// Once the view is set it cannot be changed.
        /// </summary>
        /// <exception cref="ViewAlreadySetException">Thrown if the view is already set.</exception>
        IView View { get; set; }
    }
}
