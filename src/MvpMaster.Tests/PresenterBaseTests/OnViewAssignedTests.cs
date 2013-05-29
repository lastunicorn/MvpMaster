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
using NUnit.Framework;

namespace DustInTheWind.MvpMaster.PresenterBaseTests
{
    /// <summary>
    /// Contains unit thest for the protected method <see cref="PresenterBase{TView}.OnViewAssigned"/>.
    /// </summary>
    [TestFixture]
    public class OnViewAssignedTests
    {
        private MyPresenterBase presenter;

        [SetUp]
        public void SetUp()
        {
            presenter = new MyPresenterBase();
        }

        [Test]
        public void calls_event_handler_if_somebody_subscribed_to_OnViewAssigned_event()
        {
            bool eventWasRaised = false;
            presenter.ViewAssigned += (sender, args) => eventWasRaised = true;

            presenter.CallOnViewAssigned(EventArgs.Empty);

            Assert.That(eventWasRaised, Is.True);
        }

        [Test]
        public void nothing_happens_if_nobody_subscribed_to_OnViewAssigned_event()
        {
            presenter.CallOnViewAssigned(EventArgs.Empty);
        }

        private class MyPresenterBase : PresenterBase<IView>
        {
            public void CallOnViewAssigned(EventArgs e)
            {
                OnViewAssigned(e);
            }
        }
    }
}
