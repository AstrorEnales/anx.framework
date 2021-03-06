﻿using System;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Serialization.Compiler.PrimitiveTypeWriters
{
	[ContentTypeWriter]
	internal class ByteWriter : BuiltinTypeWriter<byte>
	{
		protected internal override void Write(ContentWriter output, byte value)
		{
			output.Write(value);
		}
	}

	[ContentTypeWriter]
	internal class SByteWriter : BuiltinTypeWriter<sbyte>
	{
		protected internal override void Write(ContentWriter output, sbyte value)
		{
			output.Write(value);
		}
	}
}
