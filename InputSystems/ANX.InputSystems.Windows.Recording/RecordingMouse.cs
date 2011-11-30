﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANX.Framework.NonXNA;
using ANX.Framework.Input;
using System.IO;

#endregion

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

namespace ANX.InputSystem.Windows.Recording
{
    [Flags]
    public enum MouseRecordInfo : byte
    {
        LeftButton = 1,
        RightButton = 2,
        MiddleButton = 4,
        X1Button = 8,
        X2Button = 16,
        ScrollWheel = 32,
        XPosition = 64,
        YPosition = 128,
        LRMButtons = LeftButton | RightButton | MiddleButton,
        XButtons = X1Button | X2Button,
        AllButtons = LRMButtons | XButtons,
        Position = XPosition | YPosition,
        All = AllButtons | Position | ScrollWheel
    }

    /// <summary>
    /// Wrapper arround another IGamePad, will record all inputs and allows playback.
    /// </summary>
    public class RecordingMouse : RecordableDevice, IMouse
    {
        public IntPtr WindowHandle { get; set; }

        public MouseState GetState()
        {
            throw new NotImplementedException();
        }

        public void SetPosition(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Initialize(MouseRecordInfo info)
        {
            base.Initialize();
        }

        public void Initialize(MouseRecordInfo info, Stream bufferStream)
        {
            base.Initialize(bufferStream);
        }

        private int GetPaketSize(MouseRecordInfo info)
        {
            int ret = 0; //TODO: Pack the bools in one byte to save space sizeof(bool) == sizeof(byte)!
            if (info.HasFlag(MouseRecordInfo.LeftButton))
                ret += sizeof(bool);
            if (info.HasFlag(MouseRecordInfo.RightButton))
                ret += sizeof(bool);
            if (info.HasFlag(MouseRecordInfo.MiddleButton))
                ret += sizeof(bool);
            if (info.HasFlag(MouseRecordInfo.X1Button))
                ret += sizeof(bool);
            if (info.HasFlag(MouseRecordInfo.X2Button))
                ret += sizeof(bool);

            if (info.HasFlag(MouseRecordInfo.XPosition))
                ret += sizeof(int);
            if (info.HasFlag(MouseRecordInfo.YPosition))
                ret += sizeof(int);
            if (info.HasFlag(MouseRecordInfo.ScrollWheel))
                ret += sizeof(int);

            return ret;
        }
    }
}
