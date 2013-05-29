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
using System.Reflection;
using DustInTheWind.MvpMaster.Window;

namespace DustInTheWind.MvpMaster.Services
{
	/// <summary>
	/// Creates Views, Presenters, Controllers and binds them together.
	/// </summary>
	public class MvpInitializer : IMvpInitializer
	{
		/// <summary>
		/// Creates new instances of different forms and returns their View interfaces.
		/// </summary>
		private readonly IViewsCreator viewsCreator;

		/// <summary>
		/// Creates new instances of presenters.
		/// </summary>
		private readonly IPresentersCreator presentersCreator;

		/// <summary>
		/// Initialize a new instance of the <see cref="MvpInitializer"/> class.
		/// </summary>
		/// <param name="viewsCreator">Creates new instances of different forms and returns their View interfaces.</param>
		/// <param name="presentersCreator">Creates new instances of presenters.</param>
		/// <exception cref="ArgumentNullException">Thrown if one of the arguments is null.</exception>
		public MvpInitializer (IViewsCreator viewsCreator, IPresentersCreator presentersCreator)
		{
			if (viewsCreator == null)
				throw new ArgumentNullException ("viewsCreator");

			if (presentersCreator == null)
				throw new ArgumentNullException ("presentersCreator");

			this.viewsCreator = viewsCreator;
			this.presentersCreator = presentersCreator;
		}

		/// <summary>
		/// Creates a new MVP triad for a window.
		/// </summary>
		/// <typeparam name="TView">The type of the window's View.</typeparam>
		/// <typeparam name="TController">The type of the Controller.</typeparam>
		/// <returns>The Controller of the new window.</returns>
		public TController CreateWindow<TView, TController> ()
            where TView : IWindowView
		{
			return CreateWindowInternal<TView, TController> (null);
		}

		/// <summary>
		/// Creates a new MVP triad for a window.
		/// </summary>
		/// <typeparam name="TView">The type of the window's View.</typeparam>
		/// <typeparam name="TController">The type of the Controller.</typeparam>
		/// <param name="parentWindow">The window to be set as parent of the new window.</param>
		/// <returns>The Controller of the new window.</returns>
		public TController CreateWindow<TView, TController> (IWindowView parentWindow)
            where TView : IWindowView
		{
			return CreateWindowInternal<TView, TController> (parentWindow);
		}

		private TController CreateWindowInternal<TView, TController> (IWindowView parentWindow)
            where TView : IWindowView
		{
			TView view = viewsCreator.CreateView<TView> ();
			IPresenter presenter = CreatePresenterForView (view);
			presenter.View = view;

			if (parentWindow != null)
				view.SetParent (parentWindow);

			return presenter is TController ? (TController)presenter : default(TController);
		}

		/// <summary>
		/// Creates the necessary Presenter and binds it to the specified view.
		/// </summary>
		/// <param name="view">The view for which to create the Presenter.</param>
		public void SetupMvpFor (IView view)
		{
			IPresenter presenter = CreatePresenterForView (view);
			presenter.View = view;
		}

		/// <summary>
		/// Creates the necessary Presenter, binds it to the specified view and returns the Controller.
		/// </summary>
		/// <typeparam name="TController">The type of the controller. The Presenter has to inherit this type.</typeparam>
		/// <param name="view">The view for which to create the Presenter.</param>
		/// <returns>The Controller.</returns>
		public TController SetupMvpFor<TController> (IView view)
		{
			Type presenterType = FindPresenterType (view);
			object presenter = presentersCreator.CreatePresenter (presenterType);

			return presenter is TController ? (TController)presenter : default(TController);
		}

		private IPresenter CreatePresenterForView (IView view)
		{
			Type presenterType = FindPresenterType (view);
			return presentersCreator.CreatePresenter (presenterType) as IPresenter;
		}

		private static Type FindPresenterType (IView view)
		{
			Type type = view.GetType ();

			while (true)
			{
				if (type == null)
					return null;

				PropertyInfo presenterPropertyInfo = type.GetProperty ("Presenter");

				if (presenterPropertyInfo != null)
					return presenterPropertyInfo.PropertyType;

				type = type.BaseType;
			}
		}
	}
}