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
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace DustInTheWind.MvpMaster.PresenterBaseTests
{
    /// <summary>
    /// Contains unit thest for the property <see cref="PresenterBase{TView}.View"/>.
    /// </summary>
    [TestFixture]
    public class ViewTests
    {
        private Mock<PresenterBase<IView>> presenter;
        private Mock<IView> view;

        [SetUp]
        public void SetUp()
        {
            presenter = new Mock<PresenterBase<IView>>();
            view = new Mock<IView>();
        }

        [Test]
        public void Presenter_injects_itself_into_view_when_view_is_assigned()
        {
            presenter.Object.View = view.Object;

            view.VerifySet(x => x.Presenter = presenter.Object, Times.Once());
        }

        [Test]
        [ExpectedException(typeof(ViewAlreadySetException))]
        public void throws_if_View_is_set_twice()
        {
            presenter.Object.View = view.Object;
            presenter.Object.View = view.Object;
        }

        [Test]
        [ExpectedException(typeof(ViewAlreadySetException))]
        public void throws_if_another_View_is_already_set()
        {
            Mock<IView> anotherView = new Mock<IView>();

            presenter.Object.View = view.Object;
            presenter.Object.View = anotherView.Object;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void throws_if_view_is_null()
        {
            try
            {
                presenter.Object.View = null;
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("value"));
                throw;
            }
        }

        [Test]
        public void calls_protected_method_OnViewAssigned()
        {
            presenter.Object.View = view.Object;

            presenter.Protected().Verify("OnViewAssigned", Times.Once(), EventArgs.Empty);
        }
    }
}
