using System;
using DustInTheWind.MvpMaster.Window;
using Gtk;
using System.Collections.Generic;
using System.Text;
using DustInTheWind.MvpMaster.Services;

namespace DustInTheWind.WebPageFall.Gtk.Services
{
    public class MessagesService : IMessagesService
    {
        private IUiDispatcher uiDispatcher;

        public MessagesService(IUiDispatcher uiDispatcher)
        {
            if (uiDispatcher == null)
                throw new ArgumentNullException("uiDispatcher");

            this.uiDispatcher = uiDispatcher;
        }

        public void DisplayError(Exception ex)
        {
            uiDispatcher.Dispatch(o => {
                using (MessageDialog dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, ex.Message))
                {
                    dialog.Run();
                    dialog.Destroy();
                }
                
                Console.WriteLine(ex.Message);
            }, ex);
        }
        
        /// <summary>
        /// Displays the exception in a friendly way for the user.
        /// </summary>
        /// <param name="ex">The <see cref="Exception"/> instance containing data about the error.</param>
        /// <param name="message">The message text to be displayed along with the error message.</param>
        public void DisplayError(Exception ex, string message)
        {
            string text = string.IsNullOrEmpty(message) ? ex.Message : message + "\n" + ex.Message;

            using (MessageDialog dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, text))
            {
                dialog.Run();
                dialog.Destroy();
            }
        }

        public void DisplayErrorMessage(string message)
        {
            using (MessageDialog dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, message))
            {
                dialog.Run();
                dialog.Destroy();
            }
        }

        public void DisplayMessage(string message)
        {
            using (MessageDialog dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, message))
            {
                dialog.Run();
                dialog.Destroy();
            }
        }

        public void DisplayWarnings(Exception[] warnings)
        {
            string message = BuildMessage(warnings);
            using (MessageDialog dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, message))
            {
                dialog.Run();
                dialog.Destroy();
            }
        }
        
        private static string BuildMessage(IEnumerable<Exception> warnings)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Exception warning in warnings)
                sb.AppendLine(warning.Message);
            
            return sb.ToString();
        }

        public bool YesNoQuestion(string text)
        {
            return true;
        }

        public bool YesNoWarning(string text)
        {
            return true;
        }

        public bool? YesNoCancelQuestion(string text)
        {
            return true;
        }
    }
}

