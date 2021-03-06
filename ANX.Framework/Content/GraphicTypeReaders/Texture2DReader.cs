﻿using System;
using ANX.Framework.Graphics;
using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content
{
    [PercentageComplete(100)]
    [Developer("GinieDP, AstrorEnales")]
    [TestState(TestStateAttribute.TestState.Untested)]
    internal class Texture2DReader : ContentTypeReader<Texture2D>
    {
        protected internal override Texture2D Read(ContentReader input, Texture2D existingInstance)
        {
			SurfaceFormat surfaceFormat = (SurfaceFormat)input.ReadInt32();
            int width = input.ReadInt32();
            int height = input.ReadInt32();
            int mipCount = input.ReadInt32();

			var texture2D = new Texture2D(input.ResolveGraphicsDevice(), width, height, mipCount, surfaceFormat);
			for (int level = 0; level < mipCount; level++)
			{
                int size = input.ReadInt32();
				byte[] data = input.ReadBytes(size);
				texture2D.SetData(level, null, data, 0, size);
			}
			return texture2D;
        }
    }
}
