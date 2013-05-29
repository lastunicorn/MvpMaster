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

using DustInTheWind.Azzul.UI.Mvp.CommandedItem;

namespace DustInTheWind.Azzul.UI.Mvp.ChildrenItem
{
    /// <summary>
    /// The view of a menu item that contains a list of children created dinamically.
    /// </summary>
    /// <typeparam name="TPresenter">The type of the presenter associated with the menu item.</typeparam>
    public interface IChildrenMenuItemView<TPresenter> : ICommandedItemView<TPresenter>, IChildrenMenuItemView
        where TPresenter : class, ICommandedItemPresenter
    {
    }
}
