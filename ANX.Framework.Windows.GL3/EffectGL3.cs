﻿using System;
using System.Collections.Generic;
using System.IO;
using ANX.Framework.Graphics;
using ANX.Framework.NonXNA;
using OpenTK.Graphics.OpenGL;

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

namespace ANX.Framework.Windows.GL3
{
	/// <summary>
	/// Native OpenGL Effect implementation.
	/// </summary>
	public class EffectGL3 : INativeEffect
	{
		#region Private
		/// <summary>
		/// The native shader handle.
		/// </summary>
		private int programHandle;
		#endregion

		#region Constructor (TODO)
		/// <summary>
		/// Create a new effect instance of separate streams.
		/// </summary>
		/// <param name="vertexShaderByteCode">The vertex shader code.</param>
		/// <param name="pixelShaderByteCode">The fragment shader code.</param>
		public EffectGL3(Stream vertexShaderByteCode,
			Stream pixelShaderByteCode)
		{
			CreateShader("", "");
		}

		/// <summary>
		/// Create a new effect instance of one streams.
		/// </summary>
		/// <param name="byteCode">The byte code of the shader.</param>
		public EffectGL3(Stream byteCode)
		{
			CreateShader("", "");
		}
		#endregion

		#region CreateShader
		private void CreateShader(string vertexSource, string fragmentSource)
		{
			int vertexShader = GL.CreateShader(ShaderType.VertexShader);
			string vertexError = CompileShader(vertexShader, vertexSource);
			if (String.IsNullOrEmpty(vertexError) == false)
			{
				throw new InvalidDataException("Failed to compile the vertex " +
					"shader because of: " + vertexError);
			}

			int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
			string fragmentError = CompileShader(fragmentShader, fragmentSource);
			if (String.IsNullOrEmpty(fragmentError) == false)
			{
				throw new InvalidDataException("Failed to compile the fragment " +
					"shader because of: " + fragmentError);
			}

			programHandle = GL.CreateProgram();
			GL.AttachShader(programHandle, vertexShader);
			GL.AttachShader(programHandle, fragmentShader);
			GL.LinkProgram(programHandle);

			int result;
			GL.GetProgram(programHandle, ProgramParameter.LinkStatus, out result);
			if (result == 0)
			{
				string programError;
				GL.GetProgramInfoLog(programHandle, out programError);
				throw new InvalidDataException("Failed to link the shader program " +
					"because of: " + programError);
			}
		}
		#endregion

		#region CompileShader
		private string CompileShader(int shader, string source)
		{
			GL.ShaderSource(shader, source);
			GL.CompileShader(shader);
			
			int result;
			GL.GetShader(shader, ShaderParameter.CompileStatus, out result);
			if (result == 0)
			{
				string error = "";
				GL.GetShaderInfoLog(shader, out error);

				GL.DeleteShader(shader);

				return error;
			}

			return null;
		}
		#endregion

		#region INativeEffect Member

		public void Apply(GraphicsDevice graphicsDevice)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EffectTechnique> Techniques
		{
			get
			{
				List<EffectTechnique> techniques = new List<EffectTechnique>();

				// TODO: dummy, fill with actual data.
				techniques.Add(new EffectTechnique());

				return techniques;
			}
		}

		public IEnumerable<EffectParameter> Parameters
		{
			get
			{
				List<EffectParameter> parameters = new List<EffectParameter>();

				// TODO: dummy, fill with actual data.
				parameters.Add(new EffectParameter());

				return parameters;
			}
		}

		#endregion

		#region Dispose
		/// <summary>
		/// Dispose the native shader data.
		/// </summary>
		public void Dispose()
		{
			GL.DeleteProgram(programHandle);

			int result;
			GL.GetProgram(programHandle, ProgramParameter.DeleteStatus, out result);
			if (result == 0)
			{
				string deleteError;
				GL.GetProgramInfoLog(programHandle, out deleteError);
				throw new Exception("Failed to delete the shader program because of: " +
					deleteError);
			}
		}
		#endregion
	}
}
