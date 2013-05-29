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
    public interface ICommandedItemPresenter : IPresenter
    {
        /// <summary>
        /// Gets or sets the command that is executed when the user clicks the menu item.
        /// </summary>
        ICommand Command { get; set; }

        /// <summary>
        /// TestMe called when the user clicked the menu item.
        /// </summary>
        void Clicked();

        /// <summary>
        /// TestMe called when the mouse entered over the menu item.
        /// </summary>
        void MouseEntered();

        /// <summary>
        /// TestMe called when the mouse leaves the menu item.
        /// </summary>
        void MouseLeaved();
    }
}
