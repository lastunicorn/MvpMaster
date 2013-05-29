using System;
using System.Threading;
using Gtk;

namespace MvpMaster.Gtk.Services
{
    public class GtkSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Application.Invoke((sender, e)=>{
                d(state);
            });

            base.Post(d, state);
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            Application.Invoke((sender, e)=>{
                d(state);
            });

            base.Send(d, state);
        }
    }
}

