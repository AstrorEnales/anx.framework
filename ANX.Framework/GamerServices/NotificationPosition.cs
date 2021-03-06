#region Using Statements
using System;
using ANX.Framework.NonXNA.Development;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.GamerServices
{
    [PercentageComplete(100)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.Tested)]
    public enum NotificationPosition
    {
        BottomCenter = 7,
        BottomLeft = 6,
        BottomRight = 8,
        Center = 4,
        CenterLeft = 3,
        CenterRight = 5,
        TopCenter = 1,
        TopLeft = 0,
        TopRight = 2,
    }
}
