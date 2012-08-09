#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANX.Framework.NonXNA;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
    public class EnvironmentMapEffect : Effect, IEffectMatrices, IEffectLights, IEffectFog
    {
        public EnvironmentMapEffect(GraphicsDevice graphics)
            : base(graphics, AddInSystemFactory.Instance.GetDefaultCreator<IRenderSystemCreator>().GetShaderByteCode(NonXNA.PreDefinedShader.EnvironmentMapEffect))
        {
            throw new NotImplementedException();
        }

        protected EnvironmentMapEffect(EnvironmentMapEffect cloneSource)
            : base(cloneSource)
        {
            throw new NotImplementedException();
        }

        public override Effect Clone()
        {
            return new EnvironmentMapEffect(this);
        }

        public Matrix Projection
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

        public Matrix View
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

        public Matrix World
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

        public void EnableDefaultLighting()
        {
            throw new NotImplementedException();
        }

        public Vector3 AmbientLightColor
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

        public DirectionalLight DirectionalLight0
        {
            get { throw new NotImplementedException(); }
        }

        public DirectionalLight DirectionalLight1
        {
            get { throw new NotImplementedException(); }
        }

        public DirectionalLight DirectionalLight2
        {
            get { throw new NotImplementedException(); }
        }

        public bool LightingEnabled
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

        public Vector3 FogColor
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

        public bool FogEnabled
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

        public float FogEnd
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

        public float FogStart
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

        public Texture2D Texture
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

        public TextureCube EnvironmentMap
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

        public float EnvironmentMapAmount
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

        public Vector3 EnvironmentMapSpecular
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

        public float FresnelFactor
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

        public Vector3 DiffuseColor
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

        public Vector3 EmissiveColor
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

        public float Alpha
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
    }
}
