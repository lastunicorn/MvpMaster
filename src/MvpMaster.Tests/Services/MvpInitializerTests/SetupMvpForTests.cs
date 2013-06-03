using Moq;
using NUnit.Framework;

namespace DustInTheWind.MvpMaster.Services.MvpInitializerTests
{
    [TestFixture]
    public class SetupMvpForTests
    {
        private Mock<IViewsCreator> viewsCreator;
        private Mock<IPresentersCreator> presentersCreator;
        private MvpInitializer mvpInitializer;
        private Mock<IPresenter> presenter;

        [SetUp]
        public void SetUp()
        {
            viewsCreator = new Mock<IViewsCreator>();
            presentersCreator = new Mock<IPresentersCreator>();
            mvpInitializer = new MvpInitializer(viewsCreator.Object, presentersCreator.Object);

            presenter = new Mock<IPresenter>();
            presentersCreator.Setup((x => x.CreatePresenter(typeof(IPresenter)))).Returns(presenter.Object);
        }

        [Test]
        public void calls_presentersCreator_to_instantiate_the_new_presenter()
        {
            Mock<IView> view = new Mock<IView>();

            mvpInitializer.SetupMvpFor(view.Object);

            presentersCreator.Verify(x => x.CreatePresenter(typeof(IPresenter)), Times.Once());
        }

        [Test]
        public void sets_View_to_Presenter()
        {
            Mock<IView> view = new Mock<IView>();

            mvpInitializer.SetupMvpFor(view.Object);

            presenter.VerifySet(x => x.View = view.Object, Times.Once());
        }
    }
}
