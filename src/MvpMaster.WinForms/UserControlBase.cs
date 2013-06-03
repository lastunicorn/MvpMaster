using System.Windows.Forms;

namespace DustInTheWind.MvpMaster
{
    public class UserControlBase<TPresenter> : UserControl, IView<TPresenter>
        where TPresenter : class, IPresenter
    {
        /// <summary>
        /// Gets or sets the Presenter that contains the logic of the <see cref="UserControl"/>.
        /// </summary>
        public TPresenter Presenter { get; set; }

        /// <summary>
        /// Gets or sets the Presenter that contains the logic of the <see cref="UserControl"/>.
        /// </summary>
        IPresenter IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as TPresenter; }
        }
    }
}
