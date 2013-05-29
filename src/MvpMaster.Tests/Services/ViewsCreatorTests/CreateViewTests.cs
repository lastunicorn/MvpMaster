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
using NUnit.Framework;

namespace DustInTheWind.MvpMaster.Services.ViewsCreatorTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="ViewsCreator.CreateView{T}"/> method.
    /// </summary>
    [TestFixture]
    public class CreateViewTests
    {
        private ViewsCreator viewsCreator;
        private Mock<IServiceLocator> serviceLocator;
        private Mock<IUiDispatcher> uiDispatcher;

        [SetUp]
        public void SetUp()
        {
            serviceLocator = new Mock<IServiceLocator>();
            uiDispatcher = new Mock<IUiDispatcher>();
            viewsCreator = new ViewsCreator(serviceLocator.Object, uiDispatcher.Object);
        }

        [Test]
        public void call_is_dispatched_to_uiDispatcher()
        {
            viewsCreator.CreateView<IView>();

            uiDispatcher.Verify(x => x.Dispatch(It.IsAny<Action>()), Times.Once());
        }
    }
}
