﻿#region Using Statements
using ANX.Framework.NonXNA.Development;
#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content
{
    [PercentageComplete(100)]
    [Developer("GinieDP")]
    [TestState(TestStateAttribute.TestState.Untested)]
    internal class BoundingBoxReader : ContentTypeReader<BoundingBox>
    {
        protected internal override BoundingBox Read(ContentReader input, BoundingBox existingInstance)
        {
            var result = new BoundingBox();
            result.Min = input.ReadVector3();
            result.Max = input.ReadVector3();
            return result;
        }
    }
}
