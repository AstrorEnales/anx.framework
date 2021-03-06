using System;
using System.Collections;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

#if WINDOWSMETRO
namespace ANX.Framework
{
	public struct DictionaryEntry
	{
		private Object key;
		private Object value;

		public DictionaryEntry(Object key, Object value)
		{
			this.key = key;
			this.value = value;
		}

		public Object Key
		{
			get { return this.key; }
			set { this.key = value; }
		}

		public Object Value
		{
			get { return this.value; }
			set { this.value = value; }
		}
	}
}
#endif