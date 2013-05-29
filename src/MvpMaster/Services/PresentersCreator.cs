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

using System;

namespace DustInTheWind.MvpMaster.Services
{
	/// <summary>
	/// Creates new instances of presenters.
	/// </summary>
	public class PresentersCreator : IPresentersCreator
	{
		/// <summary>
		/// The dependency resolver container used for creating new instances.
		/// </summary>
		private readonly IServiceLocator serviceLocator;

		/// <summary>
		/// Initializes a new instance of the <see cref="PresentersCreator"/> class.
		/// </summary>
		/// <param name="serviceLocator">The dependency resolver container used for creating new instances.</param>
		/// <exception cref="ArgumentNullException">Thrown if the serviceLocator is null.</exception>
		public PresentersCreator (IServiceLocator serviceLocator)
		{
			if (serviceLocator == null)
				throw new ArgumentNullException ("serviceLocator");

			this.serviceLocator = serviceLocator;
		}

		/// <summary>
		/// Creates a new instance of the specified <see cref="IPresenter"/> type.
		/// </summary>
		/// <typeparam name="T">The type of the presenter to be created.</typeparam>
		/// <returns>The newly created instance.</returns>
		public T CreatePresenter<T> ()
            where T : IPresenter
		{
			return serviceLocator.GetInstance<T> ();
		}

		/// <summary>
		/// Creates a new instance of the specified type.
		/// </summary>
		/// <returns>The newly created instance.</returns>
		public object CreatePresenter (Type presenterType)
		{
			if (!typeof(IPresenter).IsAssignableFrom (presenterType))
				throw new TypeDoesNotRepresentPresenterException ();

			return serviceLocator.GetInstance (presenterType);
		}

		private bool OnFilter (Type type, object criteria)
		{
			return type.FullName == (string)criteria;
		}
	}
}
