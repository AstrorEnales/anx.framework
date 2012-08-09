using System;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Net
{
	public sealed class QualityOfService
	{
		public bool IsAvailable
		{
			get;
			internal set;
		}

		public int BytesPerSecondUpstream
		{
			get;
			internal set;
		}

		public int BytesPerSecondDownstream
		{
			get;
			internal set;
		}

		public TimeSpan AverageRoundtripTime
		{
			get;
			internal set;
		}

		public TimeSpan MinimumRoundtripTime
		{
			get;
			internal set;
		}
	}
}
