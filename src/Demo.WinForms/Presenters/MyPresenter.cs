using Demo.WinForms.Views;
using DustInTheWind.MvpMaster.Window;

namespace Demo.WinForms.Presenters
{
    internal class MyPresenter : WindowPresenterBase<IMyView>
    {
        public void ButtonWasClicked()
        {
            View.LabelText = View.TextBoxText;
        }
    }
}
