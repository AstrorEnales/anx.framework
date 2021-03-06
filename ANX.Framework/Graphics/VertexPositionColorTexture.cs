#region Using Statements
using System;
using ANX.Framework.NonXNA.Development;
using ANX.Framework.NonXNA;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
#if !WINDOWSMETRO      //TODO: search replacement for Win8
    [Serializable]
#endif
    [PercentageComplete(100)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.InProgress)]
	public struct VertexPositionColorTexture : IVertexType
    {
        public Vector3 Position;
		public Color Color;
		public Vector2 TextureCoordinate;

        public static readonly VertexDeclaration VertexDeclaration;

		VertexDeclaration IVertexType.VertexDeclaration
		{
			get 
            { 
                return VertexDeclaration; 
            }
		}

		public VertexPositionColorTexture(Vector3 position, Color color, Vector2 textureCoordinate)
		{
			this.Position = position;
			this.Color = color;
			this.TextureCoordinate = textureCoordinate;
		}

		static VertexPositionColorTexture()
		{
			VertexElement[] elements =
			{
				new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
				new VertexElement(12, VertexElementFormat.Color, VertexElementUsage.Color, 0),
				new VertexElement(16, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
			};

		    VertexDeclaration = new VertexDeclaration(24, elements)
		    {
		        Name = "VertexPositionColorTexture.VertexDeclaration"
		    };
		}

		public override int GetHashCode()
		{
            return HashHelper.GetGCHandleHashCode(this);
		}

		public override string ToString()
		{
			return String.Format("{{Position:{0} Color:{1} TextureCoordinate:{2}}}", Position, Color, TextureCoordinate);
		}

		public override bool Equals(object obj)
		{
		    return obj is VertexPositionColorTexture && this == (VertexPositionColorTexture)obj;
		}

        public static bool operator ==(VertexPositionColorTexture lhs, VertexPositionColorTexture rhs)
		{
			return lhs.Color.Equals(rhs.Color) && 
                   lhs.Position.Equals(rhs.Position) &&
				   lhs.TextureCoordinate.Equals(rhs.TextureCoordinate);
		}

		public static bool operator !=(VertexPositionColorTexture lhs, VertexPositionColorTexture rhs)
		{
			return lhs.Color.Equals(rhs.Color) == false || 
                   lhs.Position.Equals(rhs.Position) == false ||
				   lhs.TextureCoordinate.Equals(rhs.TextureCoordinate) == false;
		}
	}
}
