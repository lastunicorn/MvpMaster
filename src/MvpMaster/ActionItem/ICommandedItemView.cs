// Azzul
// Copyright (C) 2009-2011 Dust in the Wind
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

using DustInTheWind.Azzul.UI.Commands;
using DustInTheWind.MvpMaster;

namespace DustInTheWind.Azzul.UI.Mvp.CommandedItem
{
    /// <summary>
    /// Represents a menu item that uses uses a <see cref="ICommand"/> object to handle its action.
    /// </summary>
    public interface ICommandedItemView : IView
    {
        /// <summary>
        /// Sets the text to be displayed by the menu item.
        /// </summary>
        string Text { set; }

        /// <summary>
        /// Seta a value indcating whether the menu item is enabled or not.
        /// </summary>
        bool IsEnabled { set; }
    }
}
