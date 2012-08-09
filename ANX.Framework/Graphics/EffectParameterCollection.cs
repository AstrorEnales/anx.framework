#region Using Statements
using System;
using System.Collections.Generic;
using ANX.Framework.NonXNA;
using System.Collections;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
    public sealed class EffectParameterCollection : IEnumerable<EffectParameter>
    {
        private Effect parentEffect;
        private INativeEffect nativeEffect;
        private List<EffectParameter> parameters;

        internal EffectParameterCollection(Effect parentEffect, INativeEffect nativeEffect)
        {
            this.parentEffect = parentEffect;
            this.nativeEffect = nativeEffect;
            this.parameters = new List<EffectParameter>();

            foreach (EffectParameter p in nativeEffect.Parameters)
            {
                this.parameters.Add(p);
            }
        }

        public EffectParameter this[int index]
        {
            get
            {
                if (index >= parameters.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return parameters[index];
            }
        }

        public EffectParameter this[string name]
        {
            get
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (parameters[i].Name == name)
                    {
                        return parameters[i];
                    }
                }

                return null;
            }
        }

        public EffectParameter GetParameterBySemantic(string semantic)
        {
            throw new NotImplementedException();
        }

				IEnumerator<EffectParameter> IEnumerable<EffectParameter>.GetEnumerator()
				{
					return parameters.GetEnumerator();
				}

				IEnumerator IEnumerable.GetEnumerator()
				{
					return parameters.GetEnumerator();
				}

				public List<EffectParameter>.Enumerator GetEnumerator()
				{
					return parameters.GetEnumerator();
				}

        public int Count
        {
            get
            {
                return this.parameters.Count;
            }
        }
		}
}
