#region Using Statements
using System;
using ANX.Framework.NonXNA.Development;
using ANX.Framework.NonXNA;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.GamerServices
{
    [PercentageComplete(10)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.Untested)]
    public static class GamerServicesDispatcher
    {
        public static bool IsInitialized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static WindowHandle WindowHandle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public static event EventHandler<EventArgs> InstallingTitleUpdate;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        public static void Update()
        {
            throw new NotImplementedException();
        }
    }
}
