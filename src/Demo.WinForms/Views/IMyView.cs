using Demo.WinForms.Presenters;
using DustInTheWind.MvpMaster.Window;

namespace Demo.WinForms.Views
{
    interface IMyView : IWindowView<MyPresenter>
    {
        string TextBoxText { get; }

        string LabelText { set; }
    }
}