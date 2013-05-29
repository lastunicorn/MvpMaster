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

using Moq;
using NUnit.Framework;

namespace DustInTheWind.MvpMaster.Services.PresentersCreatorTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="PresentersCreator.CreatePresenter{T}"/> method.
    /// </summary>
    [TestFixture]
    public class CreatePresenter1Tests
    {
        private PresentersCreator presentersCreator;
        private Mock<IServiceLocator> serviceLocator;

        [SetUp]
        public void SetUp()
        {
            serviceLocator = new Mock<IServiceLocator>();
            presentersCreator = new PresentersCreator(serviceLocator.Object);
        }

        [Test]
        public void serviceLocator_is_called()
        {
            presentersCreator.CreatePresenter<IPresenter>();

            serviceLocator.Verify(x => x.GetInstance<IPresenter>(), Times.Once());
        }
    }
}
