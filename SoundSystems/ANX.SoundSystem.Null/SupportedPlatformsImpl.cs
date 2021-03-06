﻿#region Using Statements
using System;
using ANX.Framework.NonXNA;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.SoundSystem.Windows.XAudio
{
	public class SupportedPlatformsImpl : ISupportedPlatforms
	{
		public PlatformName[] Names
		{
			get
			{
				return new PlatformName[]
				{
                    PlatformName.Android,
                    PlatformName.IOS,
                    PlatformName.Linux,
                    PlatformName.MacOSX,
                    PlatformName.PSVita,
					PlatformName.Windows7,
					PlatformName.WindowsXP,
					PlatformName.WindowsVista,
					PlatformName.Windows8,
                    PlatformName.Windows8ModernUI,
				};
			}
		}
	}
}
