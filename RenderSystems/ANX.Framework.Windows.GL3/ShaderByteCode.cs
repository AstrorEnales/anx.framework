#region Using Statements
using System;
#endregion // Using Statements

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
	internal static class ShaderByteCode
	{
		#region SpriteBatchShader
		internal static byte[] SpriteBatchByteCode = new byte[]
		{
			160, 
			003, 117, 110, 105, 102, 111, 114, 109, 032, 109, 097, 116, 052, 032, 077, 097, 116, 114, 105, 120, 
			084, 114, 097, 110, 115, 102, 111, 114, 109, 059, 010, 097, 116, 116, 114, 105, 098, 117, 116, 101, 
			032, 118, 101, 099, 052, 032, 112, 111, 115, 059, 010, 097, 116, 116, 114, 105, 098, 117, 116, 101, 
			032, 118, 101, 099, 052, 032, 099, 111, 108, 059, 010, 097, 116, 116, 114, 105, 098, 117, 116, 101, 
			032, 118, 101, 099, 050, 032, 116, 101, 120, 059, 010, 118, 097, 114, 121, 105, 110, 103, 032, 118, 
			101, 099, 052, 032, 100, 105, 102, 102, 117, 115, 101, 067, 111, 108, 111, 114, 059, 010, 118, 097, 
			114, 121, 105, 110, 103, 032, 118, 101, 099, 050, 032, 100, 105, 102, 102, 117, 115, 101, 084, 101, 
			120, 067, 111, 111, 114, 100, 059, 010, 118, 111, 105, 100, 032, 109, 097, 105, 110, 040, 118, 111, 
			105, 100, 041, 123, 010, 103, 108, 095, 080, 111, 115, 105, 116, 105, 111, 110, 061, 077, 097, 116, 
			114, 105, 120, 084, 114, 097, 110, 115, 102, 111, 114, 109, 042, 112, 111, 115, 059, 010, 100, 105, 
			102, 102, 117, 115, 101, 084, 101, 120, 067, 111, 111, 114, 100, 061, 116, 101, 120, 059, 010, 100, 
			105, 102, 102, 117, 115, 101, 067, 111, 108, 111, 114, 061, 099, 111, 108, 059, 125, 010, 035, 035, 
			033, 102, 114, 097, 103, 109, 101, 110, 116, 033, 035, 035, 010, 117, 110, 105, 102, 111, 114, 109, 
			032, 115, 097, 109, 112, 108, 101, 114, 050, 068, 032, 084, 101, 120, 116, 117, 114, 101, 059, 010, 
			118, 097, 114, 121, 105, 110, 103, 032, 118, 101, 099, 052, 032, 100, 105, 102, 102, 117, 115, 101, 
			067, 111, 108, 111, 114, 059, 010, 118, 097, 114, 121, 105, 110, 103, 032, 118, 101, 099, 050, 032, 
			100, 105, 102, 102, 117, 115, 101, 084, 101, 120, 067, 111, 111, 114, 100, 059, 010, 118, 111, 105, 
			100, 032, 109, 097, 105, 110, 040, 118, 111, 105, 100, 041, 123, 010, 103, 108, 095, 070, 114, 097, 
			103, 067, 111, 108, 111, 114, 061, 116, 101, 120, 116, 117, 114, 101, 050, 068, 040, 084, 101, 120, 
			116, 117, 114, 101, 044, 100, 105, 102, 102, 117, 115, 101, 084, 101, 120, 067, 111, 111, 114, 100, 
			041, 042, 100, 105, 102, 102, 117, 115, 101, 067, 111, 108, 111, 114, 059, 125, 010, 095, 046, 094, 
			078, 240, 054, 006, 106, 005, 190, 104, 250, 201, 129, 166, 050, 199, 249, 189, 159, 008, 207, 084, 
			062, 171, 010, 076, 101, 119, 047, 079, 245, 134, 024, 149, 110, 166, 213, 153, 023, 179, 120, 191, 
			146, 106, 047, 180, 084, 037, 088, 036, 132, 126, 030, 027, 054, 044, 236, 120, 086, 102, 211, 178, 
			125
		};
		#endregion //SpriteBatchShader

	}
}
