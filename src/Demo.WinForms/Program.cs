using System;
using System.Windows.Forms;
using Demo.WinForms.Presenters;
using Demo.WinForms.Views;

namespace Demo.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MyForm form = new MyForm();
            MyPresenter presenter = new MyPresenter();
            presenter.View = form;

            Application.Run(form);
        }
    }
}
