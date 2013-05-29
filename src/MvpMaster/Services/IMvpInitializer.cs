// BioCalc
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

using DustInTheWind.MvpMaster.Window;

namespace DustInTheWind.MvpMaster.Services
{
    /// <summary>
    /// Creates Views, Presenters, Controllers and binds them together.
    /// </summary>
    public interface IMvpInitializer
    {
        /// <summary>
        /// Creates a new MVP triad for a window.
        /// </summary>
        /// <typeparam name="TView">The type of the window's View.</typeparam>
        /// <typeparam name="TController">The type of the Controller.</typeparam>
        /// <returns>The Controller of the new window.</returns>
        TController CreateWindow<TView, TController>()
            where TView : IWindowView;

        /// <summary>
        /// Creates a new MVP triad for a window.
        /// </summary>
        /// <typeparam name="TView">The type of the window's View.</typeparam>
        /// <typeparam name="TController">The type of the Controller.</typeparam>
        /// <param name="parentWindow">The window to be set as parent of the new window.</param>
        /// <returns>The Controller of the new window.</returns>
        TController CreateWindow<TView, TController>(IWindowView parentWindow)
            where TView : IWindowView;

        /// <summary>
        /// Creates the necessary Presenter and binds it to the specified view.
        /// </summary>
        /// <param name="view">The view for which to create the Presenter.</param>
        void SetupMvpFor(IView view);

        /// <summary>
        /// Creates the necessary Presenter, binds it to the specified view and returns the Controller.
        /// </summary>
        /// <typeparam name="TController">The type of the controller. The Presenter has to inherit this type.</typeparam>
        /// <param name="view">The view for which to create the Presenter.</param>
        /// <returns>The Controller.</returns>
        TController SetupMvpFor<TController>(IView view);
    }
}