// BioCalc
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
using System.Threading;

namespace DustInTheWind.MvpMaster.Services
{
    /// <summary>
    /// A service that runs the specified peace of code on the UI thread.
    /// </summary>
    public class UiDispatcher : IUiDispatcher
    {
        public SynchronizationContext SynchronizationContext { get; set; }

        public void Dispatch(Action action)
        {
            if (SynchronizationContext != null)
            {
                SynchronizationContext.Send(x => action(), null);
            }
            else
            {
                action();
            }
        }

        public void Dispatch(Action<object> action, object param)
        {
            if (SynchronizationContext != null)
            {
                SynchronizationContext.Send(x => action(x), param);
            }
            else
            {
                action(param);
            }
        }
    }
}
