﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Processors
{
    public sealed class ModelMeshPartContentCollection : ReadOnlyCollection<ModelMeshPartContent>
    {
        public ModelMeshPartContentCollection(IList<ModelMeshPartContent> content)
            : base(content)
        {
        }
    }
}