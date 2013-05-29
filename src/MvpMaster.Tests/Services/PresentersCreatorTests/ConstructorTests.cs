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

namespace DustInTheWind.MvpMaster.Services.PresentersCreatorTests
{
    /// <summary>
    /// Contains unit tests for the constructor if the <see cref="PresentersCreator"/> class.
    /// </summary>
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void throws_if_serviceLocator_is_null()
        {
            try
            {
                new PresentersCreator(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("serviceLocator"));
                throw;
            }
        }

        [Test]
        public void successfully_instantiated()
        {
            Mock<IServiceLocator> serviceLocator = new Mock<IServiceLocator>();

            new PresentersCreator(serviceLocator.Object);
        }
    }
}

