﻿using System;
using System.Diagnostics;
using ANX.Framework.NonXNA.PlatformSystem;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.PlatformSystem.Metro
{
	public class MetroGameTimer : INativeGameTimer
	{
		public long Frequency
		{
			get
			{
				return Stopwatch.Frequency;
			}
		}

		public long Timestamp
		{
			get
			{
				return Stopwatch.GetTimestamp();
			}
		}
	}
}
