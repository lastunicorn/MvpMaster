// MvpMaster
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

namespace DustInTheWind.MvpMaster.Services
{
    /// <summary>
    /// Creates new instances of different forms and returns their interfaces.
    /// </summary>
    public class ViewsCreator : IViewsCreator
    {
        /// <summary>
        /// The dependency resolver container used for creating new instances.
        /// </summary>
        private readonly IServiceLocator serviceLocator;

        /// <summary>
        /// Used to run code on the UI thread.
        /// </summary>
        private readonly IUiDispatcher uiDispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewsCreator"/> class.
        /// </summary>
        /// <param name="serviceLocator">The dependency resolver container used for creating new instances.</param>
        /// <param name="uiDispatcher">Used to run code on the UI thread.</param>
        /// <exception cref="ArgumentNullException">Thrown if one of the arguments is null.</exception>
        public ViewsCreator(IServiceLocator serviceLocator, IUiDispatcher uiDispatcher)
        {
            if (serviceLocator == null)
                throw new ArgumentNullException("serviceLocator");

            if (uiDispatcher == null)
                throw new ArgumentNullException("uiDispatcher");

            this.serviceLocator = serviceLocator;
            this.uiDispatcher = uiDispatcher;
        }

        /// <summary>
        /// Creates a new instance of the specified <see cref="IView"/> type.
        /// </summary>
        /// <typeparam name="T">The type of the view to be created.</typeparam>
        /// <returns>The newly created instance.</returns>
        public T CreateView<T>()
            where T : IView
        {
            T view = default(T);
            uiDispatcher.Dispatch(() => view = serviceLocator.GetInstance<T>());

            return view;
        }
    }
}

