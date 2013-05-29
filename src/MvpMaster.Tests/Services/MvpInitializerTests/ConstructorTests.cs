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

namespace DustInTheWind.MvpMaster.Services.MvpInitializerTests
{
    /// <summary>
    /// Contains unit tests for the constructor if the <see cref="MvpInitializer"/> class.
    /// </summary>
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void throws_if_viewsCreator_is_null()
        {
            try
            {
                Mock<IPresentersCreator> presentersCreator = new Mock<IPresentersCreator>();

                new MvpInitializer(null, presentersCreator.Object);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("viewsCreator"));
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void throws_if_presentersCreator_is_null()
        {
            try
            {
                Mock<IViewsCreator> viewsCreator = new Mock<IViewsCreator>();

                new MvpInitializer(viewsCreator.Object, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("presentersCreator"));
                throw;
            }
        }

        [Test]
        public void successfully_instantiated()
        {
            Mock<IViewsCreator> viewsCreator = new Mock<IViewsCreator>();
            Mock<IPresentersCreator> presentersCreator = new Mock<IPresentersCreator>();

            new MvpInitializer(viewsCreator.Object, presentersCreator.Object);
        }
    }
}

