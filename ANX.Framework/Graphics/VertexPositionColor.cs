using System;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
	public struct VertexPositionColor : IVertexType
	{
		public Vector3 Position;
		public Color Color;

		public static readonly VertexDeclaration VertexDeclaration;

		VertexDeclaration IVertexType.VertexDeclaration
		{
			get
			{
				return VertexDeclaration;
			}
		}

		public VertexPositionColor(Vector3 position, Color color)
		{
			this.Position = position;
			this.Color = color;
		}

		static VertexPositionColor()
		{
			VertexElement[] elements =
			{
				new VertexElement(0, VertexElementFormat.Vector3,
					VertexElementUsage.Position, 0),
				new VertexElement(12, VertexElementFormat.Color,
					VertexElementUsage.Color, 0),
			};

			VertexDeclaration declaration = new VertexDeclaration(16, elements);
			declaration.Name = "VertexPositionColor.VertexDeclaration";
			VertexDeclaration = declaration;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return string.Format("{{Position:{0} Color:{1}}}",
				this.Position, this.Color);
		}

		public override bool Equals(object obj)
		{
			if (obj != null && obj.GetType() == this.GetType())
			{
				return this == (VertexPositionColor)obj;
			}

			return false;
		}

		public static bool operator ==(VertexPositionColor lhs, VertexPositionColor rhs)
		{
			return lhs.Color.Equals(rhs.Color) && lhs.Position.Equals(rhs.Position);
		}

		public static bool operator !=(VertexPositionColor lhs, VertexPositionColor rhs)
		{
			return lhs.Color.Equals(rhs.Color) == false ||
					lhs.Position.Equals(rhs.Position) == false;
		}
	}
}
