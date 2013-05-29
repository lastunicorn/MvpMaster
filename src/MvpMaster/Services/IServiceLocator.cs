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
using System.Collections.Generic;

namespace DustInTheWind.MvpMaster.Services
{
    public interface IServiceLocator : IServiceProvider
    {
        /// <summary>
        /// Returns an instance of the specified service.
        /// </summary>
        /// <param name="serviceType">The type of service to resolve.</param>
        /// <returns>An instance of the specified service.</returns>
        object GetInstance(Type serviceType);

        /// <summary>
        /// Returns an instance of the specified service by using the first binding with the specified key.
        /// </summary>
        /// <param name="serviceType">The type of service to resolve.</param>
        /// <param name="key">The key of the instance to return.</param>
        /// <returns>An instance of the requested service.</returns>
        object GetInstance(Type serviceType, string key);

        IEnumerable<object> GetAllInstances(Type serviceType);

        TService GetInstance<TService>();

        TService GetInstance<TService>(string key);

        IEnumerable<TService> GetAllInstances<TService>();
    }
}
