﻿using System;
using ANX.Framework;
using ANX.Framework.Graphics;

namespace DualTextureSample
{
	public struct VertexDualTexture : IVertexType
	{
		public Vector3 Position;
		public Vector2 TextureCoordinate;
		public Vector2 TextureCoordinate2;

		public static readonly VertexDeclaration VertexDeclaration;

		VertexDeclaration IVertexType.VertexDeclaration
		{
			get { return VertexDeclaration; }
		}

		public VertexDualTexture(Vector3 position, Vector2 textureCoordinate, Vector2 textureCoordinate2)
		{
			Position = position;
			TextureCoordinate = textureCoordinate;
			TextureCoordinate2 = textureCoordinate2;
		}

		static VertexDualTexture()
		{
			var elements = new VertexElement[]
			{
				new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
				new VertexElement(12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
				new VertexElement(20, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 1),
			};
			VertexDeclaration = new VertexDeclaration(28, elements);
			VertexDeclaration.Name = "VertexDualTexture.VertexDeclaration";
		}
	}
}