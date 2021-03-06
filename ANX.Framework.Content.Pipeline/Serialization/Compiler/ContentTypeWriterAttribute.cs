﻿#region Using Statements
using System;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Serialization.Compiler
{
		[AttributeUsage(AttributeTargets.Class)]
    public class ContentTypeWriterAttribute : Attribute
    {
        public ContentTypeWriterAttribute()
            : base()
        {
        }
    }
}
