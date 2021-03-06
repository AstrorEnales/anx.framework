#region Using Statements
using System;
using NUnit.Framework;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

#region Datatype Usings
using XNAMouseState = Microsoft.Xna.Framework.Input.MouseState;
using ANXMouseState = ANX.Framework.Input.MouseState;

using XNAPoint = Microsoft.Xna.Framework.Point;
using ANXPoint = ANX.Framework.Point;

using XNAColor = Microsoft.Xna.Framework.Color;
using ANXColor = ANX.Framework.Color;

using XNAVector2 = Microsoft.Xna.Framework.Vector2;
using ANXVector2 = ANX.Framework.Vector2;

using XNAVector3 = Microsoft.Xna.Framework.Vector3;
using ANXVector3 = ANX.Framework.Vector3;

using XNAVector4 = Microsoft.Xna.Framework.Vector4;
using ANXVector4 = ANX.Framework.Vector4;

using XNABoundingBox = Microsoft.Xna.Framework.BoundingBox;
using ANXBoundingBox = ANX.Framework.BoundingBox;

using XNABoundingSphere = Microsoft.Xna.Framework.BoundingSphere;
using ANXBoundingSphere = ANX.Framework.BoundingSphere;

using XNABoundingFrustum = Microsoft.Xna.Framework.BoundingFrustum;
using ANXBoundingFrustum = ANX.Framework.BoundingFrustum;

using XNAPlane = Microsoft.Xna.Framework.Plane;
using ANXPlane = ANX.Framework.Plane;

using XNARect = Microsoft.Xna.Framework.Rectangle;
using ANXRect = ANX.Framework.Rectangle;

using XNAMatrix = Microsoft.Xna.Framework.Matrix;
using ANXMatrix = ANX.Framework.Matrix;

using XNAQuaternion = Microsoft.Xna.Framework.Quaternion;
using ANXQuaternion = ANX.Framework.Quaternion;

using XNAStorageDevice = Microsoft.Xna.Framework.Storage.StorageDevice;
using ANXStorageDevice = ANX.Framework.Storage.StorageDevice;

using XNAStorageContainer = Microsoft.Xna.Framework.Storage.StorageContainer;
using ANXStorageContainer = ANX.Framework.Storage.StorageContainer;

using XNACurve = Microsoft.Xna.Framework.Curve;
using ANXCurve = ANX.Framework.Curve;

using XNACurveKey = Microsoft.Xna.Framework.CurveKey;
using ANXCurveKey = ANX.Framework.CurveKey;

using XNACurveContinuity = Microsoft.Xna.Framework.CurveContinuity;
using ANXCurveContinuity = ANX.Framework.CurveContinuity;

using XNACurveLoopType = Microsoft.Xna.Framework.CurveLoopType;
using ANXCurveLoopType = ANX.Framework.CurveLoopType;

using XNACurveKeyCollection = Microsoft.Xna.Framework.CurveKeyCollection;
using ANXCurveKeyCollection = ANX.Framework.CurveKeyCollection;

using XNACurveTangent = Microsoft.Xna.Framework.CurveTangent;
using ANXCurveTangent = ANX.Framework.CurveTangent;

using XNAGamePadState = Microsoft.Xna.Framework.Input.GamePadState;
using ANXGamePadState = ANX.Framework.Input.GamePadState;

using XNAGamePadButtons = Microsoft.Xna.Framework.Input.GamePadButtons;
using ANXGamePadButtons = ANX.Framework.Input.GamePadButtons;

using XNAButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using ANXButtonState = ANX.Framework.Input.ButtonState;

using XNAKeyboardState = Microsoft.Xna.Framework.Input.KeyboardState;
using ANXKeyboardState = ANX.Framework.Input.KeyboardState;

using XNAKeys = Microsoft.Xna.Framework.Input.Keys;
using ANXKeys = ANX.Framework.Input.Keys;
#endregion // Datatype usings

namespace ANX.Framework.TestCenter
{
    class AssertHelper
    {
        private const float epsilon = 0.0000001f;
        private const int complementBits = 8;

        private const string defaultFailText = "{0} failed: xna: ({1}) anx: ({2})";

        #region Compare

/*
        public static bool CompareFloats(float a, float b, float epsilon)
        {
            // Ok, but not right in all cases

            //return (float)Math.Abs((double)(a - b)) < epsilon;

            // better, but not perfect

            //float absA = Math.Abs(a);
            //float absB = Math.Abs(b);
            //float diff = Math.Abs(a - b);

            //if (diff == 0.0f)
            //{
            //    return true;
            //}
            //else if (a * b == 0) 
            //{ 
            //    // a or b or both are zero         
            //    // relative error is not meaningful here         
            //    return diff < (epsilon * epsilon);     
            //} 
            //else 
            //{ 
            //    // use relative error         
            //    return diff / (absA + absB) < epsilon;     
            //}         

            // ok
            return AlmostEqual2sComplement(a, b, complementBits);
        }
*/

        private static unsafe int FloatToInt32Bits(float f)
        {
            return *((int*)&f);
        }

        private static bool AlmostEqual2sComplement(float a, float b, int maxDeltaBits)
        {
            int aInt = FloatToInt32Bits(a);
            if (aInt < 0)
            {
                aInt = Int32.MinValue - aInt;
            }

            int bInt = FloatToInt32Bits(b);
            if (bInt < 0)
            {
                bInt = Int32.MinValue - bInt;
            }

            int intDiff = Math.Abs(aInt - bInt);

            return intDiff <= (1 << maxDeltaBits);
        }

        public static bool Compare(Microsoft.Xna.Framework.Graphics.VertexElement xna,
            ANX.Framework.Graphics.VertexElement anx)
        {
            return (xna.Offset == anx.Offset &&
                xna.UsageIndex == anx.UsageIndex &&
                (int)xna.VertexElementFormat == (int)anx.VertexElementFormat &&
                (int)xna.VertexElementUsage == (int)anx.VertexElementUsage);
        }

        private static bool Compare(XNACurve xna, ANXCurve anx)
        {
            return (xna.IsConstant == anx.IsConstant) && (Compare(xna.Keys, anx.Keys)) && (Compare(xna.PreLoop, anx.PreLoop)) && (Compare(xna.PostLoop, anx.PostLoop));
        }

        private static bool Compare(XNACurveLoopType xna, ANXCurveLoopType anx)
        {
            return ((int)xna == (int)anx);
        }

        private static bool Compare(XNACurveKeyCollection xna, ANXCurveKeyCollection anx)
        {
            if (xna.Count != anx.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < xna.Count; i++)
                {
                    if (!Compare(xna[i], anx[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool Compare(XNACurveKey xna, ANXCurveKey anx)
        {
            return xna.Position == anx.Position && xna.Value == anx.Value && xna.TangentIn == anx.TangentIn && xna.TangentOut == anx.TangentOut && Compare(xna.Continuity, anx.Continuity);
        }

        private static bool Compare(XNACurveContinuity xna, ANXCurveContinuity anx)
        {
            return ((int)xna == (int)anx);
        }

        private static bool Compare(XNAStorageDevice xna, ANXStorageDevice anx)
        {
            return (xna.FreeSpace == anx.FreeSpace) && (xna.IsConnected == anx.IsConnected) && (xna.TotalSpace == anx.TotalSpace);
        }

        #endregion

        #region ConvertEquals
        public static void ConvertEquals(Microsoft.Xna.Framework.Graphics.Viewport xna, ANX.Framework.Graphics.Viewport anx, String test)
        {
            if (xna.X == anx.X &&
                xna.Y == anx.Y &&
                xna.Width == anx.Width &&
                xna.Height == anx.Height &&
                xna.MinDepth == anx.MinDepth &&
                xna.MaxDepth == anx.MaxDepth)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(Microsoft.Xna.Framework.PlaneIntersectionType xna, ANX.Framework.PlaneIntersectionType anx, String test)
        {
            if ((int)xna == (int)anx)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(Microsoft.Xna.Framework.ContainmentType xna, ANX.Framework.ContainmentType anx, String test)
        {
            if ((int)xna == (int)anx)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(float xna, float anx, String test)
        {
            if (AssertHelper.AlmostEqual2sComplement(xna, anx, complementBits) ||
                (xna + epsilon >= float.MaxValue && anx + epsilon >= float.MaxValue) ||
                (xna - epsilon <= float.MinValue && anx - epsilon <= float.MinValue))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(float? xna, float? anx, String test)
        {
            if ((!xna.HasValue && !anx.HasValue) || 
                (xna.HasValue && anx.HasValue && AssertHelper.AlmostEqual2sComplement(xna.Value, anx.Value, complementBits)) ||
                (xna + epsilon >= float.MaxValue && anx + epsilon >= float.MaxValue) ||
                (xna - epsilon <= float.MinValue && anx - epsilon <= float.MinValue))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(Exception xna, Exception anx, String test)
        {
            if (xna.GetType() == anx.GetType())
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(String xna, String anx, String test)
        {
            if (xna == anx)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna, anx));
            }
        }

        public static void ConvertEquals(bool xna, bool anx, String test)
        {
            if (xna == anx)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEqualsPackedVector<T>(Microsoft.Xna.Framework.Graphics.PackedVector.IPackedVector<T> lhs,
            ANX.Framework.Graphics.PackedVector.IPackedVector<T> rhs, string test)
        {
            if (lhs.PackedValue.Equals(rhs.PackedValue))
                Assert.Pass(test + " passed");
            else
                Assert.Fail("{0} failed: {1} XNA: ({2}) {1} ANX: ({3})", test, lhs.GetType().Name, lhs, rhs);
        }

        public static void ConvertEquals(byte a, byte b, String test)
        {
            if (a == b)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format("{0} failed: byte a: ({1}) byte b: ({2})", test, a, b));
            }
        }

        public static void ConvertEquals(XNAColor xna, ANXColor anx, String test)
        {
            if (xna.R == anx.R &&
                xna.G == anx.G &&
                xna.B == anx.B &&
                xna.A == anx.A)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAVector2 xna, ANXVector2 anx, String test)
        {
            if (AlmostEqual2sComplement(xna.X, anx.X, complementBits) &&
                AlmostEqual2sComplement(xna.Y, anx.Y, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(test + " failed: xna({" + xna.X + "}{" + xna.Y + "}) anx({" + anx.X + "}{" + anx.Y + "})");
            }
        }

        public static void ConvertEquals(ANXVector2 xna, ANXVector2 anx, String test)
        {
            if (AlmostEqual2sComplement(xna.X, anx.X, complementBits) &&
                AlmostEqual2sComplement(xna.Y, anx.Y, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(test + " failed: anx({" + xna.X + "}{" + xna.Y + "}) compared to anx({" + anx.X + "}{" + anx.Y + "})");
            }
        }

        public static void ConvertEquals(XNAVector2[] xna, ANXVector2[] anx, String test)
        {
            bool result = true;
            string xnaString = string.Empty;
            string anxString = string.Empty;

            for (int i = 0; i < xna.Length; i++)
            {
                result = AlmostEqual2sComplement(xna[i].X, anx[i].X, complementBits) &&
                         AlmostEqual2sComplement(xna[i].Y, anx[i].Y, complementBits);

                xnaString = xna[i].ToString() + "  ";
                anxString = anx[i].ToString() + "  ";

                if (!result)
                    break;
            }

            if (result)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(string.Format(defaultFailText, test, xnaString, anxString));
            }
        }

        public static void ConvertEquals(XNAVector3 xna, ANXVector3 anx, String test)
        {
            if (AlmostEqual2sComplement(xna.X, anx.X, complementBits) &&
                AlmostEqual2sComplement(xna.Y, anx.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Z, anx.Z, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(string.Format("{0} failed: xna({1},{2},{3}) anx({4},{5},{6})", test, xna.X, xna.Y, xna.Z, anx.X, anx.Y, anx.Z));
            }
        }

        public static void ConvertEquals(XNAVector3[] xna, ANXVector3[] anx, String test)
        {
            bool result = true;
            string xnaString = string.Empty;
            string anxString = string.Empty;

            for (int i = 0; i < xna.Length; i++)
            {
                result = AlmostEqual2sComplement(xna[i].X, anx[i].X, complementBits) &&
                         AlmostEqual2sComplement(xna[i].Y, anx[i].Y, complementBits) &&
                         AlmostEqual2sComplement(xna[i].Z, anx[i].Z, complementBits);

                xnaString += xna[i].ToString() + "  ";
                anxString += anx[i].ToString() + "  ";

                if (!result)
                    break;
            }

            if (result)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(string.Format(defaultFailText, test, xnaString, anxString));
            }
        }

        public static void ConvertEquals(XNAVector4 xna, ANXVector4 anx, String test)
        {
            if (AlmostEqual2sComplement(xna.X, anx.X, complementBits) &&
                AlmostEqual2sComplement(xna.Y, anx.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Z, anx.Z, complementBits) &&
                AlmostEqual2sComplement(xna.W, anx.W, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(string.Format("{0} failed: xna({1},{2},{3},{4}) anx({5},{6},{7},{8})", test, xna.X, xna.Y, xna.Z, xna.W, anx.X, anx.Y, anx.Z, anx.W));
            }
        }

        public static void ConvertEquals(XNAVector4[] xna, ANXVector4[] anx, String test)
        {
            bool result = true;
            string xnaString = string.Empty;
            string anxString = string.Empty;

            for (int i = 0; i < xna.Length; i++)
            {
                result = AlmostEqual2sComplement(xna[i].X, anx[i].X, complementBits) &&
                         AlmostEqual2sComplement(xna[i].Y, anx[i].Y, complementBits) &&
                         AlmostEqual2sComplement(xna[i].Z, anx[i].Z, complementBits) &&
                         AlmostEqual2sComplement(xna[i].W, anx[i].W, complementBits);

                xnaString += xna[i].ToString() + "  ";
                anxString += anx[i].ToString() + "  ";

                if (!result)
                    break;
            }

            if (result)
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(string.Format(defaultFailText, test, xnaString, anxString));
            }
        }

        public static void ConvertEquals(XNABoundingBox xna, ANXBoundingBox anx, String test)
        {
            if (AlmostEqual2sComplement(xna.Min.X, anx.Min.X, complementBits) &&
                AlmostEqual2sComplement(xna.Min.Y, anx.Min.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Min.Z, anx.Min.Z, complementBits) &&
                AlmostEqual2sComplement(xna.Max.X, anx.Max.X, complementBits) &&
                AlmostEqual2sComplement(xna.Max.Y, anx.Max.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Max.Z, anx.Max.Z, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNABoundingSphere xna, ANXBoundingSphere anx, String test)
        {
            if (AlmostEqual2sComplement(xna.Center.X, anx.Center.X, complementBits) &&
                AlmostEqual2sComplement(xna.Center.Y, anx.Center.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Center.Z, anx.Center.Z, complementBits) &&
                AlmostEqual2sComplement(xna.Radius, anx.Radius, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNARect xna, ANXRect anx, String test)
        {
            if (AlmostEqual2sComplement(xna.X, anx.X, complementBits) &&
                AlmostEqual2sComplement(xna.Y, anx.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Width, anx.Width, complementBits) &&
                AlmostEqual2sComplement(xna.Height, anx.Height, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(test + " failed: xna({" + xna.X + "}{" + xna.Y + "}{" + xna.Width + "}{" + xna.Height + "}) anx({" + anx.X + "}{" + anx.Y + "}{" + anx.Width + "}{" + anx.Height + "})");
            }
        }

        public static void ConvertEquals(XNABoundingFrustum xna, ANXBoundingFrustum anx, String test)
        {
            ConvertEquals(xna.Matrix, anx.Matrix, test);
        }

        public static void ConvertEquals(XNAPlane xna, ANXPlane anx, String test)
        {
            if (AlmostEqual2sComplement(xna.D, anx.D, complementBits) &&
                AlmostEqual2sComplement(xna.Normal.X, anx.Normal.X, complementBits) &&
                AlmostEqual2sComplement(xna.Normal.Y, anx.Normal.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Normal.Z, anx.Normal.Z, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAMatrix xna, ANXMatrix anx, String test)
        {
            if (AlmostEqual2sComplement(xna.M11, anx.M11, complementBits) &&
                AlmostEqual2sComplement(xna.M12, anx.M12, complementBits) &&
                AlmostEqual2sComplement(xna.M13, anx.M13, complementBits) &&
                AlmostEqual2sComplement(xna.M14, anx.M14, complementBits) &&
                AlmostEqual2sComplement(xna.M21, anx.M21, complementBits) &&
                AlmostEqual2sComplement(xna.M22, anx.M22, complementBits) &&
                AlmostEqual2sComplement(xna.M23, anx.M23, complementBits) &&
                AlmostEqual2sComplement(xna.M24, anx.M24, complementBits) &&
                AlmostEqual2sComplement(xna.M31, anx.M31, complementBits) &&
                AlmostEqual2sComplement(xna.M32, anx.M32, complementBits) &&
                AlmostEqual2sComplement(xna.M33, anx.M33, complementBits) &&
                AlmostEqual2sComplement(xna.M34, anx.M34, complementBits) &&
                AlmostEqual2sComplement(xna.M41, anx.M41, complementBits) &&
                AlmostEqual2sComplement(xna.M42, anx.M42, complementBits) &&
                AlmostEqual2sComplement(xna.M43, anx.M43, complementBits) &&
                AlmostEqual2sComplement(xna.M44, anx.M44, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAQuaternion xna, ANXQuaternion anx, String test)
        {
            if (AlmostEqual2sComplement(xna.X, anx.X, complementBits) &&
                AlmostEqual2sComplement(xna.Y, anx.Y, complementBits) &&
                AlmostEqual2sComplement(xna.Z, anx.Z, complementBits) &&
                AlmostEqual2sComplement(xna.W, anx.W, complementBits))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAStorageDevice xna, ANXStorageDevice anx, String test)
        {
            if (Compare(xna, anx))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAStorageContainer xna, ANXStorageContainer anx, String test)
        {
            if ((Compare(xna.StorageDevice, anx.StorageDevice)) && (xna.IsDisposed == anx.IsDisposed) && (xna.DisplayName == anx.DisplayName))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNACurve xna, ANXCurve anx, String test)
        {
            if (Compare(xna, anx))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNACurve xna, XNACurve xna2, ANXCurve anx, ANXCurve anx2, String test)
        {
            if (Compare(xna, anx) && Compare(xna2, anx) && Compare(xna2, anx2))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAGamePadState xna, ANXGamePadState anx, String test)
        {
            if ((xna.Buttons.ToString() == anx.Buttons.ToString()) && (xna.DPad.ToString() == anx.DPad.ToString()) && (xna.IsConnected == anx.IsConnected) && (xna.ThumbSticks.ToString() == anx.ThumbSticks.ToString()) && (xna.Triggers.ToString() == anx.Triggers.ToString()))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNACurveKey xna, ANXCurveKey anx, String test)
        {
            if (Compare(xna, anx))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }
        
        internal static void ConvertEquals(XNACurveKey xna, ANXCurveKey anx, XNACurveKey xna2, ANXCurveKey anx2, String test)
        {
            if (Compare(xna, anx)&&Compare(xna,anx2)&&Compare(xna2,anx2))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }
        
        public static void ConvertEquals(XNACurveKeyCollection xna, ANXCurveKeyCollection anx, String test)
        {
            if (Compare(xna,anx))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNACurveKey[] xna, ANXCurveKey[] anx, String test)
        {
            if (!(AlmostEqual2sComplement(xna.Length, anx.Length, complementBits)))
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
            for (int i = 0; i < xna.Length; i++)
            {
                if (!(Compare(xna[i], anx[i])))
                {
                    Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
                }
            }
            Assert.Pass(test + " passed");

        }

        public static void ConvertEquals(XNAButtonState xna, ANXButtonState anx, String test)
        {
            if ((xna==XNAButtonState.Released)==(anx==ANXButtonState.Released))
            {
                Assert.Pass(test + " passed");
            }
            else
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
            }
        }

        public static void ConvertEquals(XNAKeys[] xna, ANXKeys[] anx, String test)
        {
            if (xna.Length!=anx.Length)
            {
                Assert.Fail(String.Format(defaultFailText, test, xna.Length.ToString(), anx.Length.ToString()));
            }
            for (int i = 0; i < xna.Length; i++)
            {
                if ((int)xna[i]!=(int)anx[i])
                {
                     Assert.Fail(String.Format(defaultFailText, test, xna[i].ToString(), anx[i].ToString()));
                }
            }
            Assert.Pass(test + " passed");
        }

        public static void ConvertEquals(XNAPoint xna, ANXPoint anx, String test)
        {
            if (xna.X == anx.X &&
                xna.Y == anx.Y)
                Assert.Pass(String.Format("{0} passed", test));
            else
                Assert.Fail(String.Format(defaultFailText, test, xna.ToString(), anx.ToString()));
        }
        public static void ConvertEquals(ANXMouseState referenz, ANXMouseState toTest, String test)
        {
            if ((referenz.X == toTest.X) && (referenz.Y == toTest.Y) && (referenz.ScrollWheelValue == toTest.ScrollWheelValue) && (referenz.LeftButton == toTest.LeftButton) && (referenz.MiddleButton == toTest.MiddleButton) && (referenz.RightButton == toTest.RightButton) && (referenz.XButton1 == toTest.XButton1) && (referenz.XButton2 == toTest.XButton2))
            {
                Assert.Pass(String.Format("{0} passed", test));
            }
            else {
                Assert.Fail(String.Format(defaultFailText, test, referenz.ToString(), toTest.ToString()));
            }
        }
        #endregion
    }
}
