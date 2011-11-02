﻿#region Using Statements
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

namespace ANX.Framework
{
    public struct Matrix : IEquatable<Matrix>
    {
        #region Public Fields

        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        #endregion

        #region Constructors

        public Matrix(
            float m11,
            float m12,
            float m13,
            float m14,
            float m21,
            float m22,
            float m23,
            float m24,
            float m31,
            float m32,
            float m33,
            float m34,
            float m41,
            float m42,
            float m43,
            float m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        #endregion

        #region Public Static Properties

        private static Matrix identity = new Matrix(1f, 0f, 0f, 0f,
                                           0f, 1f, 0f, 0f,
                                           0f, 0f, 1f, 0f,
                                           0f, 0f, 0f, 1f);
        public static Matrix Identity
        {
            get { return identity; }
        }

        #endregion

        #region Public Properties

        public Vector3 Right
        {
            get { return new Vector3(M11, M12, M13); }
            set
            {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
            }
        }

        public Vector3 Left
        {
            get { return new Vector3(-M11, -M12, -M13); }
            set
            {
                M11 = -value.X;
                M12 = -value.Y;
                M13 = -value.Z;
            }
        }

        public Vector3 Up
        {
            get { return new Vector3(M21, M22, M23); }
            set
            {
                M21 = value.X;
                M22 = value.Y;
                M23 = value.Z;
            }
        }

        public Vector3 Down
        {
            get { return new Vector3(-M21, -M22, -M23); }
            set
            {
                M21 = -value.X;
                M22 = -value.Y;
                M23 = -value.Z;
            }
        }

        public Vector3 Backward
        {
            get { return new Vector3(M31, M32, M33); }
            set
            {
                M31 = value.X;
                M32 = value.Y;
                M33 = value.Z;
            }
        }

        public Vector3 Forward
        {
            get { return new Vector3(-M31, -M32, -M33); }
            set
            {
                M31 = -value.X;
                M32 = -value.Y;
                M33 = -value.Z;
            }
        }

        public Vector3 Translation
        {
            get { return new Vector3(M41, M42, M43); }
            set
            {
                M41 = value.X;
                M42 = value.Y;
                M43 = value.Z;
            }
        }

        #endregion

        #region Public Static Methods

        #region Arithmetic Operations

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Add(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static void Add(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M14 = matrix1.M14 + matrix2.M14;

            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M24 = matrix1.M24 + matrix2.M24;

            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
            result.M34 = matrix1.M34 + matrix2.M34;

            result.M41 = matrix1.M41 + matrix2.M41;
            result.M42 = matrix1.M42 + matrix2.M42;
            result.M43 = matrix1.M43 + matrix2.M43;
            result.M44 = matrix1.M44 + matrix2.M44;
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Subtract(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static void Subtract(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 - matrix2.M11;
            result.M12 = matrix1.M12 - matrix2.M12;
            result.M13 = matrix1.M13 - matrix2.M13;
            result.M14 = matrix1.M14 - matrix2.M14;

            result.M21 = matrix1.M21 - matrix2.M21;
            result.M22 = matrix1.M22 - matrix2.M22;
            result.M23 = matrix1.M23 - matrix2.M23;
            result.M24 = matrix1.M24 - matrix2.M24;

            result.M31 = matrix1.M31 - matrix2.M31;
            result.M32 = matrix1.M32 - matrix2.M32;
            result.M33 = matrix1.M33 - matrix2.M33;
            result.M34 = matrix1.M34 - matrix2.M34;

            result.M41 = matrix1.M41 - matrix2.M41;
            result.M42 = matrix1.M42 - matrix2.M42;
            result.M43 = matrix1.M43 - matrix2.M43;
            result.M44 = matrix1.M44 - matrix2.M44;
        }

        public static Matrix Divide(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Divide(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static void Divide(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            Matrix invMatrix2;
            Invert(ref matrix2, out invMatrix2);
            Multiply(ref matrix1, ref invMatrix2, out result);
        }

        public static Matrix Divide(Matrix matrix1, float divider)
        {
            Matrix result;
            Divide(ref matrix1, divider, out result);
            return result;
        }

        public static void Divide(ref Matrix matrix1, float divider, out Matrix result)
        {
            Matrix.Multiply(ref matrix1, 1f / divider, out result);
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Multiply(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static void Multiply(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41;
            result.M21 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41;
            result.M31 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41;
            result.M41 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41;

            result.M12 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42;
            result.M22 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42;
            result.M32 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42;
            result.M42 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42;

            result.M13 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43;
            result.M23 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43;
            result.M33 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43;
            result.M43 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43;

            result.M14 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44;
            result.M24 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44;
            result.M34 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44;
            result.M44 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44;
        }

        public static Matrix Multiply(Matrix matrix1, float scaleFactor)
        {
            Matrix result;
            Multiply(ref matrix1, scaleFactor, out result);
            return result;
        }

        public static void Multiply(ref Matrix matrix1, float scaleFactor, out Matrix result)
        {
            result.M11 = matrix1.M11 * scaleFactor;
            result.M21 = matrix1.M21 * scaleFactor;
            result.M31 = matrix1.M31 * scaleFactor;
            result.M41 = matrix1.M41 * scaleFactor;

            result.M12 = matrix1.M12 * scaleFactor;
            result.M22 = matrix1.M22 * scaleFactor;
            result.M32 = matrix1.M32 * scaleFactor;
            result.M42 = matrix1.M42 * scaleFactor;

            result.M13 = matrix1.M13 * scaleFactor;
            result.M23 = matrix1.M23 * scaleFactor;
            result.M33 = matrix1.M33 * scaleFactor;
            result.M43 = matrix1.M43 * scaleFactor;

            result.M14 = matrix1.M14 * scaleFactor;
            result.M24 = matrix1.M24 * scaleFactor;
            result.M34 = matrix1.M34 * scaleFactor;
            result.M44 = matrix1.M44 * scaleFactor;
        }

        public static Matrix Lerp(Matrix matrix1, Matrix matrix2, float amount)
        {
            Matrix result;
            Lerp(ref matrix1, ref matrix2, amount, out result);
            return result;
        }

        public static void Lerp(ref Matrix matrix1,
            ref Matrix matrix2,
            float amount,
            out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix Negate(Matrix matrix)
        {
            Matrix result;
            Negate(ref matrix, out result);
            return result;
        }

        public static void Negate(ref Matrix matrix, out Matrix result)
        {
            Matrix.Multiply(ref matrix, -1.0f, out result);
        }

        public static Matrix Invert(Matrix matrix)
        {
            Matrix result;
            Invert(ref matrix, out result);
            return result;
        }

        public static void Invert(ref Matrix matrix, out Matrix result)
        {
            /*
             * This part was copied from the Mono:XNA Project.
             */

            //
            // Use Laplace expansion theorem to calculate the inverse of a 4x4 matrix
            // 
            // 1. Calculate the 2x2 determinants needed and the 4x4 determinant based on the 2x2 determinants 
            // 2. Create the adjugate matrix, which satisfies: A * adj(A) = det(A) * I
            // 3. Divide adjugate matrix with the determinant to find the inverse

            float det1 = matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21;
            float det2 = matrix.M11 * matrix.M23 - matrix.M13 * matrix.M21;
            float det3 = matrix.M11 * matrix.M24 - matrix.M14 * matrix.M21;
            float det4 = matrix.M12 * matrix.M23 - matrix.M13 * matrix.M22;
            float det5 = matrix.M12 * matrix.M24 - matrix.M14 * matrix.M22;
            float det6 = matrix.M13 * matrix.M24 - matrix.M14 * matrix.M23;
            float det7 = matrix.M31 * matrix.M42 - matrix.M32 * matrix.M41;
            float det8 = matrix.M31 * matrix.M43 - matrix.M33 * matrix.M41;
            float det9 = matrix.M31 * matrix.M44 - matrix.M34 * matrix.M41;
            float det10 = matrix.M32 * matrix.M43 - matrix.M33 * matrix.M42;
            float det11 = matrix.M32 * matrix.M44 - matrix.M34 * matrix.M42;
            float det12 = matrix.M33 * matrix.M44 - matrix.M34 * matrix.M43;

            float detMatrix = (float)(det1 * det12 - det2 * det11 + det3 * det10 + det4 * det9 - det5 * det8 + det6 * det7);

            float invDetMatrix = 1f / detMatrix;

            Matrix ret; // Allow for matrix and result to point to the same structure

            ret.M11 = (matrix.M22 * det12 - matrix.M23 * det11 + matrix.M24 * det10) * invDetMatrix;
            ret.M12 = (-matrix.M12 * det12 + matrix.M13 * det11 - matrix.M14 * det10) * invDetMatrix;
            ret.M13 = (matrix.M42 * det6 - matrix.M43 * det5 + matrix.M44 * det4) * invDetMatrix;
            ret.M14 = (-matrix.M32 * det6 + matrix.M33 * det5 - matrix.M34 * det4) * invDetMatrix;
            ret.M21 = (-matrix.M21 * det12 + matrix.M23 * det9 - matrix.M24 * det8) * invDetMatrix;
            ret.M22 = (matrix.M11 * det12 - matrix.M13 * det9 + matrix.M14 * det8) * invDetMatrix;
            ret.M23 = (-matrix.M41 * det6 + matrix.M43 * det3 - matrix.M44 * det2) * invDetMatrix;
            ret.M24 = (matrix.M31 * det6 - matrix.M33 * det3 + matrix.M34 * det2) * invDetMatrix;
            ret.M31 = (matrix.M21 * det11 - matrix.M22 * det9 + matrix.M24 * det7) * invDetMatrix;
            ret.M32 = (-matrix.M11 * det11 + matrix.M12 * det9 - matrix.M14 * det7) * invDetMatrix;
            ret.M33 = (matrix.M41 * det5 - matrix.M42 * det3 + matrix.M44 * det1) * invDetMatrix;
            ret.M34 = (-matrix.M31 * det5 + matrix.M32 * det3 - matrix.M34 * det1) * invDetMatrix;
            ret.M41 = (-matrix.M21 * det10 + matrix.M22 * det8 - matrix.M23 * det7) * invDetMatrix;
            ret.M42 = (matrix.M11 * det10 - matrix.M12 * det8 + matrix.M13 * det7) * invDetMatrix;
            ret.M43 = (-matrix.M41 * det4 + matrix.M42 * det2 - matrix.M43 * det1) * invDetMatrix;
            ret.M44 = (matrix.M31 * det4 - matrix.M32 * det2 + matrix.M33 * det1) * invDetMatrix;

            result = ret;
        }

        public static Matrix Transpose(Matrix matrix)
        {
            Matrix result;
            Transpose(ref matrix, out result);
            return result;
        }

        public static void Transpose(ref Matrix matrix, out Matrix result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;
            
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;

            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;

            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;
        }

        #endregion

        #region Creation Operations

        public static Matrix CreateBillboard(Vector3 objectPosition,
            Vector3 cameraPosition,
            Vector3 cameraUpVector,
            Nullable<Vector3> cameraForwardVector)
        {
            Matrix result;
            CreateBillboard(ref objectPosition,
                ref cameraPosition,
                ref cameraUpVector,
                cameraForwardVector,
                out result);
            return result;
        }

        public static void CreateBillboard(ref Vector3 objectPosition,
            ref Vector3 cameraPosition,
            ref Vector3 cameraUpVector,
            Nullable<Vector3> cameraForwardVector,
            out Matrix result)
        {
            Vector3 translation;
            Vector3.Subtract(ref objectPosition, ref cameraPosition, out translation);

            Vector3 right;
            Vector3 up;
            Vector3 backward;

            Vector3.Normalize(ref translation, out backward);

            Vector3.Normalize(ref cameraUpVector, out up);

            Vector3.Cross(ref backward, ref up, out right);
            
            // TODO: check if necessary
            Vector3.Cross(ref backward, ref right, out up);

            result = Matrix.Identity;
            result.Backward = backward;
            result.Right = right;
            result.Up = up;
            result.Translation = translation;
        }

        public static Matrix CreateConstrainedBillboard(Vector3 objectPosition,
            Vector3 cameraPosition,
            Vector3 rotateAxis,
            Nullable<Vector3> cameraForwardVector,
            Nullable<Vector3> objectForwardVector)
        {
            Matrix result;
            CreateConstrainedBillboard(ref objectPosition,
                ref cameraPosition,
                ref rotateAxis,
                cameraForwardVector,
                objectForwardVector,
                out result);
            return result;
        }

        public static void CreateConstrainedBillboard(ref Vector3 objectPosition,
            ref Vector3 cameraPosition,
            ref Vector3 rotateAxis,
            Nullable<Vector3> cameraForwardVector,
            Nullable<Vector3> objectForwardVector,
            out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Matrix result;
            CreateFromAxisAngle(ref axis, angle, out result);
            return result;
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateFromQuaternion(Quaternion quaternion)
        {
            Matrix result;
            CreateFromQuaternion(ref quaternion, out result);
            return result;
        }

        public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            Matrix result;
            CreateFromYawPitchRoll(yaw, pitch, roll, out result);
            return result;
        }

        public static void CreateFromYawPitchRoll(float yaw,
            float pitch,
            float roll,
            out Matrix result)
        {
            Matrix yawRotation = Matrix.Identity;
            Matrix pitchRotation = Matrix.Identity;
            Matrix rollRotation = Matrix.Identity;

            Matrix.CreateRotationY(yaw, out yawRotation);
            Matrix.CreateRotationX(pitch, out pitchRotation);
            Matrix.CreateRotationZ(roll, out rollRotation);

            Matrix tmp = Matrix.identity;
            Matrix.Multiply(ref yawRotation, ref pitchRotation, out tmp);
            Matrix.Multiply(ref tmp, ref rollRotation, out result);
        }

        public static Matrix CreateLookAt(Vector3 cameraPosition,
            Vector3 cameraTarget,
            Vector3 cameraUpVector)
        {
            Matrix result;
            CreateLookAt(ref cameraPosition, ref cameraTarget, ref cameraUpVector, out result);
            return result;
        }

        public static void CreateLookAt(ref Vector3 cameraPosition,
            ref Vector3 cameraTarget,
            ref Vector3 cameraUpVector,
            out Matrix result)
        {
            Vector3 vectorZ;
            Vector3 targetToCamera;
            Vector3.Subtract(ref cameraPosition, ref cameraTarget, out targetToCamera);
            Vector3.Normalize(ref targetToCamera, out vectorZ);

            Vector3 vectorX;
            Vector3 unnormalizedVectorX;
            Vector3.Cross(ref cameraUpVector, ref vectorZ, out unnormalizedVectorX);
            Vector3.Normalize(ref unnormalizedVectorX, out vectorX);

            // vectorX and vectorZ are normalized so vectorY don't has to be normalized another time
            Vector3 vectorY;
            Vector3.Cross(ref vectorZ, ref vectorX, out vectorY);
            
            result = Matrix.Identity;
            result.M11 = vectorX.X;
            result.M12 = vectorY.X;
            result.M13 = vectorZ.X;

            result.M21 = vectorX.Y;
            result.M22 = vectorY.Y;
            result.M23 = vectorZ.Y;
            
            result.M31 = vectorX.Z;
            result.M32 = vectorY.Z;
            result.M33 = vectorZ.Z;

            float dotProduct;

            dotProduct = 0.0f;
            Vector3.Dot(ref vectorX, ref cameraPosition, out dotProduct);
            result.M41 = -dotProduct;

            dotProduct = 0.0f;
            Vector3.Dot(ref vectorY, ref cameraPosition, out dotProduct);
            result.M42 = -dotProduct;

            dotProduct = 0.0f;
            Vector3.Dot(ref vectorZ, ref cameraPosition, out dotProduct);
            result.M43 = -dotProduct;
        }

        public static Matrix CreateOrthographic(float width,
            float height,
            float zNearPlane,
            float zFarPlane)
        {
            Matrix result;
            CreateOrthographic(width, height, zNearPlane, zFarPlane, out result);
            return result;
        }

        public static void CreateOrthographic(float width,
            float height,
            float zNearPlane,
            float zFarPlane,
            out Matrix result)
        {
            result = new Matrix();

            float nPmfP = zNearPlane - zFarPlane;

            result.M11 = width * 0.5f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = height * 0.5f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f / nPmfP;
            result.M34 = -1f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = zNearPlane / nPmfP;
            result.M44 = 1f;
        }

        public static Matrix CreateOrthographicOffCenter(float left,
            float right,
            float bottom,
            float top,
            float zNearPlane,
            float zFarPlane)
        {
            Matrix result;
            CreateOrthographicOffCenter(left, right, bottom, top, zNearPlane, zFarPlane, out result);
            return result;
        }

        public static void CreateOrthographicOffCenter(float left,
            float right,
            float bottom,
            float top,
            float zNearPlane,
            float zFarPlane,
            out Matrix result)
        {
            result = new Matrix();

            float nPmfP = zNearPlane - zFarPlane;

            result.M11 = (right - left) * 0.5f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = (top - bottom) * 0.5f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f / nPmfP;
            result.M34 = 0f;
            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = zNearPlane / nPmfP;
            result.M44 = 1f;
        }

        public static Matrix CreatePerspective(float width,
            float height,
            float nearPlaneDistance,
            float farPlaneDistance)
        {
            Matrix result;
            CreatePerspective(width, height, nearPlaneDistance, farPlaneDistance, out result);
            return result;
        }

        public static void CreatePerspective(float width,
            float height,
            float nearPlaneDistance,
            float farPlaneDistance,
            out Matrix result)
        {
            if (nearPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "nearPlaneDistance needs to be greater than zero");
            }
            if (farPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", "farPlaneDistance needs to be greater than zero");
            }
            if (farPlaneDistance >= nearPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", "farPlaneDistance needs to be behind nearPlaneDistance");
            }

            result = new Matrix();

            float TwoNpD = nearPlaneDistance + nearPlaneDistance;
            float nPmfP = nearPlaneDistance - farPlaneDistance;

            result.M11 = TwoNpD / width;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = TwoNpD / height;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = farPlaneDistance / nPmfP;
            result.M34 = -1f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / nPmfP;
            result.M44 = 0f;
        }

        public static Matrix CreatePerspectiveFieldOfView(float fieldOfView,
            float aspectRatio,
            float nearPlaneDistance,
            float farPlaneDistance)
        {
            Matrix result;
            CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance, out result);
            return result;
        }

        public static void CreatePerspectiveFieldOfView(float fieldOfView,
            float aspectRatio,
            float nearPlaneDistance,
            float farPlaneDistance,
            out Matrix result)
        {
            result = new Matrix();

            if (fieldOfView <= 0f || fieldOfView >= MathHelper.Pi)
            {
                throw new ArgumentOutOfRangeException("fieldOfView", "FieldOfView needs to be in range 0.0f ... PI");
            }
            if (nearPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "nearPlaneDistance needs to be greater than zero");
            }
            if (farPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", "farPlaneDistance needs to be greater than zero");
            }
            if (farPlaneDistance >= nearPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", "farPlaneDistance needs to be behind nearPlaneDistance");
            }

            float OneOverTanFoV = 1f / (float)Math.Tan(fieldOfView * 0.5f);
            float nPmfP = nearPlaneDistance - farPlaneDistance;

            result.M11 = OneOverTanFoV / aspectRatio;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = OneOverTanFoV;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = farPlaneDistance / nPmfP;
            result.M34 = -1f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / nPmfP;
            result.M44 = 0f;
        }

        public static Matrix CreatePerspectiveOffCenter(float left,
            float right,
            float bottom,
            float top,
            float nearPlaneDistance,
            float farPlaneDistance)
        {
            Matrix result;
            CreatePerspectiveOffCenter(left, right, bottom, top, nearPlaneDistance, farPlaneDistance, out result);
            return result;
        }

        public static void CreatePerspectiveOffCenter(float left,
            float right,
            float bottom,
            float top,
            float nearPlaneDistance,
            float farPlaneDistance,
            out Matrix result)
        {
            if (nearPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "nearPlaneDistance needs to be greater than zero");
            }
            if (farPlaneDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", "farPlaneDistance needs to be greater than zero");
            }
            if (farPlaneDistance >= nearPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", "farPlaneDistance needs to be behind nearPlaneDistance");
            }

            float TwoNPD = nearPlaneDistance + nearPlaneDistance;
            float nPmfP = nearPlaneDistance - farPlaneDistance;
            float width = right - left;
            float height = top - bottom;

            result.M11 = TwoNPD / width;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = TwoNPD / height;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = (left + right) / width;
            result.M32 = (top + bottom) / height;
            result.M33 = farPlaneDistance / nPmfP;
            result.M34 = -1f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / nPmfP;
            result.M44 = 0f;
        }

        public static Matrix CreateReflection(Plane value)
        {
            Matrix result;
            CreateReflection(ref value, out result);
            return result;
        }

        public static void CreateReflection(ref Plane value, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateRotationX(float radians)
        {
            Matrix result;
            CreateRotationX(radians, out result);
            return result;
        }

        public static void CreateRotationX(float radians, out Matrix result)
        {
            result = Matrix.Identity;
            result.M22 = (float)Math.Cos(radians);
            result.M23 = (float)Math.Sin(radians);
            result.M32 = -result.M23;
            result.M33 = result.M22;
        }

        public static Matrix CreateRotationY(float radians)
        {
            Matrix result;
            CreateRotationY(radians, out result);
            return result;
        }

        public static void CreateRotationY(float radians, out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = (float)Math.Cos(radians);
            result.M13 = (float)-Math.Sin(radians);
            result.M22 = 1f;
            result.M31 = -result.M13;
            result.M33 = result.M11;
        }

        public static Matrix CreateRotationZ(float radians)
        {
            Matrix result;
            CreateRotationZ(radians, out result);
            return result;
        }

        public static void CreateRotationZ(float radians, out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = (float)Math.Cos(radians);
            result.M12 = (float)Math.Sin(radians);
            result.M21 = -result.M12;
            result.M22 = result.M11;
        }

        public static Matrix CreateScale(float scale)
        {
            Matrix result;
            CreateScale(scale, out result);
            return result;
        }

        public static void CreateScale(float scale, out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = scale;
            result.M22 = scale;
            result.M33 = scale;
        }

        public static Matrix CreateScale(float xScale, float yScale, float zScale)
        {
            Matrix result;
            CreateScale(xScale, yScale, zScale, out result);
            return result;
        }

        public static void CreateScale(float xScale,
            float yScale,
            float zScale,
            out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = xScale;
            result.M22 = yScale;
            result.M33 = zScale;
        }

        public static Matrix CreateScale(Vector3 scales)
        {
            Matrix result;
            CreateScale(ref scales, out result);
            return result;
        }

        public static void CreateScale(ref Vector3 scales, out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = scales.X;
            result.M22 = scales.Y;
            result.M33 = scales.Z;
        }

        public static Matrix CreateShadow(Vector3 lightDirection, Plane plane)
        {
            Matrix result;
            CreateShadow(ref lightDirection, ref plane, out result);
            return result;
        }

        public static void CreateShadow(ref Vector3 lightDirection, ref Plane plane, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateTranslation(float xPosition, float yPosition, float zPosition)
        {
            Matrix result;
            CreateTranslation(xPosition, yPosition, zPosition, out result);
            return result;
        }

        public static void CreateTranslation(float xPosition,
            float yPosition,
            float zPosition,
            out Matrix result)
        {
            result = Matrix.Identity;
            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
        }

        public static Matrix CreateTranslation(Vector3 position)
        {
            Matrix result;
            CreateTranslation(ref position, out result);
            return result;
        }

        public static void CreateTranslation(ref Vector3 position, out Matrix result)
        {
            result = Matrix.Identity;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
        }

        public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
        {
            Matrix result;
            CreateWorld(ref position, ref forward, ref up, out result);
            return result;
        }

        public static void CreateWorld(ref Vector3 position,
            ref Vector3 forward,
            ref Vector3 up,
            out Matrix result)
        {
            Vector3 vectorZ;
            Vector3.Normalize(ref forward, out vectorZ);

            Vector3 vectorX;
            Vector3 unnormalizedVectorX;
            Vector3.Cross(ref vectorZ, ref up, out unnormalizedVectorX);
            Vector3.Normalize(ref unnormalizedVectorX, out vectorX);

            // vectorX and vectorZ are normalized so vectorY don't has to be normalized another timeZ
            Vector3 vectorY;
            Vector3.Cross(ref vectorX, ref vectorZ, out vectorY);

            result = Matrix.Identity;
            result.Right = vectorX;
            result.Up = vectorY;
            result.Forward = vectorZ;
            result.Translation = position;
        }

        #endregion

        #region Transformations

        public static Matrix Transform(Matrix value, Quaternion rotation)
        {
            Matrix result;
            Transform(ref value, ref rotation, out result);
            return result;
        }

        public static void Transform(ref Matrix value, ref Quaternion rotation, out Matrix result)
        {
            Matrix rotationMatrix;
            CreateFromQuaternion(ref rotation, out rotationMatrix);
            Matrix.Multiply(ref value, ref rotationMatrix, out result);
        }

        #endregion

        #endregion

        #region Operator Overloading

        public static Matrix operator -(Matrix matrix1)
        {
            Matrix result;
            Negate(ref matrix1, out result);
            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Subtract(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            return !(matrix1.Equals(matrix2));
        }

        public static Matrix operator *(float scaleFactor, Matrix matrix)
        {
            Matrix result;
            Multiply(ref matrix, scaleFactor, out result);
            return result;
        }

        public static Matrix operator *(Matrix matrix, float scaleFactor)
        {
            Matrix result;
            Multiply(ref matrix, scaleFactor, out result);
            return result;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Multiply(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static Matrix operator /(Matrix matrix1, float divider)
        {
            Matrix result;
            Divide(ref matrix1, divider, out result);
            return result;
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Divide(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            Matrix result;
            Add(ref matrix1, ref matrix2, out result);
            return result;
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            return (matrix1.Equals(matrix2));
        }

        #endregion

        #region Public Methods

        public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        {
            throw new NotImplementedException();
        }

        public float Determinant()
        {
            float part1; 
            float part2;
            float part3;
            float part4;
            float part5;
            float part6;

            part1 = M31 * M42 - M32 * M41;
            part2 = M31 * M43 - M33 * M41;
            part3 = M31 * M44 - M34 * M41;
            part4 = M32 * M43 - M33 * M42;
            part5 = M32 * M44 - M34 * M42;
            part6 = M33 * M44 - M34 * M43;

            return M11 * (M22 * part6 - M23 * part5 + M24 * part4) -
                M12 * (M21 * part6 - M23 * part3 + M24 * part2) +
                M13 * (M21 * part5 - M22 * part3 + M24 * part1) -
                M14 * (M21 * part4 - M22 * part2 + M23 * part1);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}\n{4} {5} {6} {7}\n{8} {9} {10} {11}\n{12} {13} {14} {15}",
                M11, M12, M13, M14,
                M21, M22, M23, M24,
                M31, M32, M33, M34,
                M41, M42, M43, M44);
        }

        #endregion

        #region IEquatable Implementation

        public override bool Equals(object obj)
        {
            return (obj is Matrix) ? this.Equals((Matrix)obj) : false;
        }

        public bool Equals(Matrix other)
        {
            return ((M11 == other.M11) &&
                    (M12 == other.M12) &&
                    (M13 == other.M13) &&
                    (M14 == other.M14) &&
                    (M21 == other.M21) &&
                    (M22 == other.M22) &&
                    (M23 == other.M23) &&
                    (M24 == other.M24) &&
                    (M31 == other.M31) &&
                    (M32 == other.M32) &&
                    (M33 == other.M33) &&
                    (M34 == other.M34) &&
                    (M41 == other.M41) &&
                    (M42 == other.M42) &&
                    (M43 == other.M43) &&
                    (M44 == other.M44));
        }

        #endregion
    }
}
