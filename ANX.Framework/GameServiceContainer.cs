#region Using Statements
using System;
using System.Collections.Generic;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework
{
		[ANX.Framework.NonXNA.Development.PercentageComplete(100)]
    public class GameServiceContainer : IServiceProvider
    {
        private Dictionary<Type, Object> services;

        public GameServiceContainer()
        {
            this.services = new Dictionary<Type, object>();
        }

        public void AddService(Type type, Object provider)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            this.services.Add(type, provider);
        }

        public Object GetService(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            Object obj = null;
            this.services.TryGetValue(type, out obj);
            return obj;
        }

        public void RemoveService(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            this.services.Remove(type);
        }
    }
}
