#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework
{
    public abstract class GameHost
    {
        //private EventHandler<EventArgs> Activated;
        //private EventHandler<EventArgs> Deactivated;
        //private EventHandler<EventArgs> Exiting;
        //private EventHandler<EventArgs> Idle;
        //private EventHandler<EventArgs> Resume;
        //private EventHandler<EventArgs> Suspend;

        // Events
        internal event EventHandler<EventArgs> Activated;
        internal event EventHandler<EventArgs> Deactivated;
        internal event EventHandler<EventArgs> Exiting;
        internal event EventHandler<EventArgs> Idle;
        internal event EventHandler<EventArgs> Resume;
        internal event EventHandler<EventArgs> Suspend;

        public GameHost(Game game)
        {

        }

        public abstract void Run();

        public abstract GameWindow Window { get; }

        public abstract void Exit();

        protected void OnActivated()
        {
            if (this.Activated != null)
            {
                this.Activated(this, EventArgs.Empty);
            }
        }

        protected void OnDeactivated()
        {
            if (this.Deactivated != null)
            {
                this.Deactivated(this, EventArgs.Empty);
            }
        }

        protected void OnIdle()
        {
            if (this.Idle != null)
            {
                this.Idle(this, EventArgs.Empty);
            }
        }

    }
}
