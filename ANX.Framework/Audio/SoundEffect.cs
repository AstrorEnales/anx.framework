﻿using System;
using System.IO;
using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.SoundSystem;

#region License

//
// This file is part of the ANX.Framework created by the "ANX.Framework developer group".
//
// This file is released under the Ms-PL license.
//
//
//
// Microsoft Public License (Ms-PL)
//
// This license governs use of the accompanying software. If you use the software, you accept this license. 
// If you do not accept the license, do not use the software.
//
// 1.Definitions
//   The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning 
//   here as under U.S. copyright law.
//   A "contribution" is the original software, or any additions or changes to the software.
//   A "contributor" is any person that distributes its contribution under this license.
//   "Licensed patents" are a contributor's patent claims that read directly on its contribution.
//
// 2.Grant of Rights
//   (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations 
//       in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to 
//       reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution
//       or any derivative works that you create.
//   (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in 
//       section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed
//       patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution 
//       in the software or derivative works of the contribution in the software.
//
// 3.Conditions and Limitations
//   (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
//   (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your 
//       patent license from such contributor to the software ends automatically.
//   (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution 
//       notices that are present in the software.
//   (D) If you distribute any portion of the software in source code form, you may do so only under this license by including
//       a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or 
//       object code form, you may only do so under a license that complies with this license.
//   (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees,
//       or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the
//       extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a 
//       particular purpose and non-infringement.

#endregion // License

namespace ANX.Framework.Audio
{
	public sealed class SoundEffect : IDisposable
	{
		#region Static
		#region DistanceScale (TODO)
		public static float DistanceScale
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
		#endregion

		#region DopplerScale (TODO)
		public static float DopplerScale
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
		#endregion

		#region MasterVolume (TODO)
		public static float MasterVolume
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
		#endregion

		#region SpeedOfSound (TODO)
		public static float SpeedOfSound
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
		#endregion
		#endregion

		#region Private
		private ISoundEffect nativeSoundEffect;
		#endregion

		#region Public
		public TimeSpan Duration
		{
			get
			{
				return nativeSoundEffect.Duration;
			}
		}

		public bool IsDisposed
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			set;
		}
		#endregion

		#region Constructor
		private SoundEffect(Stream stream)
		{
			nativeSoundEffect =
				AddInSystemFactory.Instance.GetDefaultCreator<ISoundSystemCreator>()
				.CreateSoundEffect(stream);
		}

		public SoundEffect(byte[] buffer, int sampleRate, AudioChannels channels)
			 : this(buffer, 0, buffer.Length, sampleRate, channels, 0, 0)
		{
		}

		public SoundEffect(byte[] buffer, int offset, int count, int sampleRate,
			AudioChannels channels, int loopStart, int loopLength)
		{
			nativeSoundEffect =
				AddInSystemFactory.Instance.GetDefaultCreator<ISoundSystemCreator>()
				.CreateSoundEffect(buffer, offset, count, sampleRate, channels,
				loopStart, loopLength);
		}

		~SoundEffect()
		{
			Dispose();
		}
		#endregion

		#region CreateInstance
		public SoundEffectInstance CreateInstance()
		{
			return new SoundEffectInstance(this);
		}
		#endregion

		#region FromStream
		public static SoundEffect FromStream(Stream stream)
		{
			return new SoundEffect(stream);
		}
		#endregion

		#region GetSampleDuration
		public static TimeSpan GetSampleDuration(int sizeInBytes, int sampleRate,
			AudioChannels channels)
		{
			float sizeMulBlockAlign = sizeInBytes / ((int)channels * 2);
			return TimeSpan.FromMilliseconds((double)(sizeMulBlockAlign * 1000f /
				(float)sampleRate));
		}
		#endregion

		#region GetSampleSizeInBytes
		public static int GetSampleSizeInBytes(TimeSpan duration, int sampleRate,
			AudioChannels channels)
		{
			int timeMulSamples = (int)(duration.TotalMilliseconds *
				(double)((float)sampleRate / 1000f));
			return (timeMulSamples + timeMulSamples % (int)channels) *
				((int)channels * 2);
		}
		#endregion

		#region Play (TODO)
		public bool Play()
		{
			return Play(1f, 0f, 0f);
		}

		public bool Play(float volume, float pitch, float pan)
		{
			// TODO: fire and forget play
			throw new NotImplementedException();
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			if (IsDisposed == false)
			{
				IsDisposed = true;
				nativeSoundEffect.Dispose();
				nativeSoundEffect = null;
			}
		}
		#endregion
	}
}
