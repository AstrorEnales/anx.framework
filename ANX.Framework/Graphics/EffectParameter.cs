using System;
using System.Runtime.InteropServices;
using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
	[PercentageComplete(100)]
	[TestState(TestStateAttribute.TestState.Untested)]
    [Developer("Glatzemann")]
	public sealed class EffectParameter
	{
        internal INativeEffectParameter NativeParameter
        {
            get;
            private set;
        }

		#region Public
        public EffectAnnotationCollection Annotations
        {
            get { return NativeParameter.Annotations; }
        }

        public EffectParameterCollection Elements
        {
            get { return NativeParameter.Elements; }
        }

        public EffectParameterCollection StructureMembers
        {
            get { return NativeParameter.StructureMembers; }
        }

		public int ColumnCount
		{
            get { return NativeParameter.ColumnCount; }
		}

	    public string Name
	    {
            get { return NativeParameter.Name; }
	    }

	    public EffectParameterClass ParameterClass
	    {
            get { return NativeParameter.ParameterClass; }
	    }

	    public EffectParameterType ParameterType
	    {
            get { return NativeParameter.ParameterType; }
	    }

	    public int RowCount
	    {
            get { return NativeParameter.RowCount; }
	    }

	    public string Semantic
	    {
            get { return NativeParameter.Semantic; }
	    }
		#endregion

        internal EffectParameter(INativeEffectParameter nativeParameter)
        {
            this.NativeParameter = nativeParameter;
        }

		#region GetValue
		public bool GetValueBoolean()
		{
			return NativeParameter.GetValueBoolean();
		}

		public bool[] GetValueBooleanArray(int count)
		{
			return NativeParameter.GetValueBooleanArray(count);
		}

		public int GetValueInt32()
		{
			return NativeParameter.GetValueInt32();
		}

		public Int32[] GetValueInt32Array(int count)
		{
			return NativeParameter.GetValueInt32Array(count);
		}

		public Matrix GetValueMatrix()
		{
			return NativeParameter.GetValueMatrix();
		}

		public Matrix[] GetValueMatrixArray(int count)
		{
			return NativeParameter.GetValueMatrixArray(count);
		}

		public Matrix GetValueMatrixTranspose()
		{
			return NativeParameter.GetValueMatrixTranspose();
		}

		public Matrix[] GetValueMatrixTransposeArray(int count)
		{
			return NativeParameter.GetValueMatrixTransposeArray(count);
		}

		public Quaternion GetValueQuaternion()
		{
			return NativeParameter.GetValueQuaternion();
		}

		public Quaternion[] GetValueQuaternionArray(int count)
		{
			return NativeParameter.GetValueQuaternionArray(count);
		}

		public float GetValueSingle()
		{
			return NativeParameter.GetValueSingle();
		}

		public float[] GetValueSingleArray(int count)
		{
			return NativeParameter.GetValueSingleArray(count);
		}

		public string GetValueString()
		{
			return NativeParameter.GetValueString();
		}

		public Texture2D GetValueTexture2D()
		{
			return NativeParameter.GetValueTexture2D();
		}

		public Texture3D GetValueTexture3D()
		{
			return NativeParameter.GetValueTexture3D();
		}

		public TextureCube GetValueTextureCube()
		{
			return NativeParameter.GetValueTextureCube();
		}

		public Vector2 GetValueVector2()
		{
			return NativeParameter.GetValueVector2();
		}

		public Vector2[] GetValueVector2Array(int count)
		{
			return NativeParameter.GetValueVector2Array(count);
		}

		public Vector3 GetValueVector3()
		{
			return NativeParameter.GetValueVector3();
		}

		public Vector3[] GetValueVector3Array(int count)
		{
			return NativeParameter.GetValueVector3Array(count);
		}

		public Vector4 GetValueVector4()
		{
			return NativeParameter.GetValueVector4();
		}

		public Vector4[] GetValueVector4Array(int count)
		{
			return NativeParameter.GetValueVector4Array(count);
		}
		#endregion

		#region SetValue
		public void SetValue([MarshalAs(UnmanagedType.U1)] bool value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(bool[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(int value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(int[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Matrix value)
		{
			NativeParameter.SetValue(value, false);
		}

		public void SetValue(Matrix[] value)
		{
			NativeParameter.SetValue(value, false);
		}

		public void SetValue(Quaternion value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Quaternion[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(float value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(float[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(string value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Texture value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Vector2 value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Vector2[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Vector3 value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Vector3[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Vector4 value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValue(Vector4[] value)
		{
			NativeParameter.SetValue(value);
		}

		public void SetValueTranspose(Matrix value)
		{
			NativeParameter.SetValue(value, true);
		}

		public void SetValueTranspose(Matrix[] value)
		{
			NativeParameter.SetValue(value, true);
		}
		#endregion
	}
}
