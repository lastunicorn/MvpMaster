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

namespace DustInTheWind.MvpMaster.Services
{
    /// <summary>
    /// Creates new instances of different forms and returns their View interfaces.
    /// </summary>
    public interface IViewsCreator
    {
        /// <summary>
        /// Creates a new instance of the specified <see cref="IView"/> type.
        /// </summary>
        /// <typeparam name="T">The type of the view to be created.</typeparam>
        /// <returns>The newly created instance.</returns>
        T CreateView<T>()
            where T : IView;
    }
}
