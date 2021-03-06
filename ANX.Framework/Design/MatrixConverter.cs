using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Design
{
#if !WINDOWSMETRO      //TODO: search replacement for Win8
    [Developer("GinieDP")]
    [TestState(TestStateAttribute.TestState.Tested)]
    public class MatrixConverter : MathTypeConverter
    {
        public MatrixConverter()
        {
            base.propertyDescriptions = MathTypeConverter.CreateFieldDescriptor<Matrix>(
                "M11", "M12", "M13", "M14",
                "M21", "M22", "M23", "M24",
                "M31", "M32", "M33", "M34",
                "M41", "M42", "M43", "M44");
            supportStringConvert = false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (value is Matrix)
            {
                Matrix instance = (Matrix)value;

                if (IsTypeInstanceDescriptor(destinationType))
                {
                    return CreateInstanceDescriptor<Matrix>(new object[]
                    {
                        instance.M11, instance.M12, instance.M13, instance.M14, 
                        instance.M21, instance.M22, instance.M23, instance.M24,
                        instance.M31, instance.M32, instance.M33, instance.M34,
                        instance.M41, instance.M42, instance.M43, instance.M44
                    });
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues");

            return new Matrix(
                (float)propertyValues["M11"], (float)propertyValues["M12"], (float)propertyValues["M13"], (float)propertyValues["M14"],
                (float)propertyValues["M21"], (float)propertyValues["M22"], (float)propertyValues["M23"], (float)propertyValues["M24"],
                (float)propertyValues["M31"], (float)propertyValues["M32"], (float)propertyValues["M33"], (float)propertyValues["M34"],
                (float)propertyValues["M41"], (float)propertyValues["M42"], (float)propertyValues["M43"], (float)propertyValues["M44"]);
        }
    }

#endif
}
