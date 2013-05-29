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

using DustInTheWind.Azzul.Services;
using DustInTheWind.Azzul.UI.Mvp.CommandedItem;

namespace DustInTheWind.Azzul.UI.Mvp.ChildrenItem
{
    /// <summary>
    /// Contains the presentation logic for a menu item that contains a list of children created dinamically.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public class ChildrenMenuItemPresenter<TView> : CommandedItemPresenter<TView>, IChildrenMenuItemPresenter<TView>
        where TView : class, ICommandedItemView
    {
        /// <summary>
        /// Initializes a new instnace of the <see cref="ChildrenMenuItemPresenter{TView}"/> class.
        /// </summary>
        /// <param name="messagesService"></param>
        /// <param name="statusService"></param>
        public ChildrenMenuItemPresenter(IMessagesService messagesService, IStatusService statusService)
            : base(messagesService, statusService)
        {
        }

        /// <summary>
        /// TestMe called when the user clicked one of the child menu items.
        /// </summary>
        public virtual void ChildClicked(MenuItemModel item)
        {
        }
    }
}
