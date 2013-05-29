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

using System;
using DustInTheWind.Azzul.Services;
using DustInTheWind.Azzul.UI.Commands;

namespace DustInTheWind.Azzul.UI.Mvp.CommandedItem
{
    /// <summary>
    /// Contains the presentation logic for a control that is driven by a <see cref="ICommand"/> object.
    /// </summary>
    public class CommandedItemPresenter<TView> : PresenterBase<TView>, ICommandedItemPresenter<TView>
        where TView : class, ICommandedItemView
    {
        /// <summary>
        /// A service that displays messages to the user.
        /// </summary>
        private readonly IMessagesService messagesService;

        /// <summary>
        /// Gets a service that displays messages to the user.
        /// </summary>
        protected IMessagesService MessagesService
        {
            get { return messagesService; }
        }

        /// <summary>
        /// A service that keeps a status information and raises an event when it is changed.
        /// </summary>
        private readonly IStatusService statusService;

        /// <summary>
        /// Gets a service that keeps a status information and raises an event when it is changed.
        /// </summary>
        protected IStatusService StatusService
        {
            get { return statusService; }
        }

        /// <summary>
        /// The command that is executed when the user clicks the menu item.
        /// </summary>
        private ICommand command;

        /// <summary>
        /// Gets or sets the command that is executed when the user clicks the menu item.
        /// </summary>
        public ICommand Command
        {
            get { return command; }
            set
            {
                if (command == value)
                    return;

                if (command != null)
                    command.IsActiveChanged -= HandleIsActiveChanged;

                command = value;

                if (command != null)
                {
                    if (view != null)
                        view.IsEnabled = command.IsActive;

                    command.IsActiveChanged += HandleIsActiveChanged;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandedItemPresenter{TView}"/> class.
        /// </summary>
        /// <param name="messagesService">A service that displays messages to the user.</param>
        /// <param name="statusService">A service that keeps a status information and raises an event when it is changed.</param>
        /// <exception cref="ArgumentNullException">One of the dependiencies is null.</exception>
        public CommandedItemPresenter(IMessagesService messagesService, IStatusService statusService)
        {
            if (messagesService == null)
                throw new ArgumentNullException("messagesService");

            if (statusService == null)
                throw new ArgumentNullException("statusService");

            this.messagesService = messagesService;
            this.statusService = statusService;
        }

        /// <summary>
        /// TestMe called after the view is assigned to the current instance.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnViewAssigned(EventArgs e)
        {
            if (command != null)
                view.IsEnabled = command.IsActive;

            base.OnViewAssigned(e);
        }

        /// <summary>
        /// Call-back method called when the command is active or inactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleIsActiveChanged(object sender, EventArgs e)
        {
            view.IsEnabled = command.IsActive;
        }

        /// <summary>
        /// TestMe called when the user clicked the menu item.
        /// </summary>
        public void Clicked()
        {
            if (command != null)
            {
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    messagesService.DisplayError(ex);
                }
            }
        }

        /// <summary>
        /// TestMe called when the mouse entered over the menu item.
        /// </summary>
        public void MouseEntered()
        {
            if (command != null && !string.IsNullOrWhiteSpace(command.Description))
            {
                try
                {
                    statusService.SetTemporaryStatusText(command.Description);
                }
                catch (Exception ex)
                {
                    messagesService.DisplayError(ex);
                }
            }
        }

        /// <summary>
        /// TestMe called when the mouse leaves the menu item.
        /// </summary>
        public void MouseLeaved()
        {
            if (command != null && !string.IsNullOrWhiteSpace(command.Description))
            {
                try
                {
                    statusService.ResetStatusText();
                }
                catch (Exception ex)
                {
                    messagesService.DisplayError(ex);
                }
            }
        }
    }
}
