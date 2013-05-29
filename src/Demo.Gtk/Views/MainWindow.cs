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
using Gtk;
using DustInTheWind.Azzul.UI.Views;

namespace DustInTheWind.MvpMaster.Demo.Gtk
{
	public partial class MainWindow: WindowBase<MainPresenter>, IMainView
	{
		public string LabelText
		{
			set { label1.Text = value; }
		}

		public string InputText
		{
			get { return entry1.Text; }
		}

		public MainWindow()
			: base (WindowType.Toplevel)
		{
			Build();
		}
	
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void OnButton1Clicked(object sender, System.EventArgs e)
		{
			Presenter.Button1Clicked();
		}
	}
}