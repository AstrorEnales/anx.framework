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
    [Developer("GinieDP, Konstantin Koch")]
    [TestState(TestStateAttribute.TestState.Tested)]
    public class ColorConverter : MathTypeConverter
    {
        public ColorConverter()
        {
            base.propertyDescriptions = MathTypeConverter.CreatePropertyDescriptor<Color>("R", "G", "B", "A");
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            byte[] values = ConvertFromString<byte>(context, culture, value as String);
            if (values != null && values.Length == 4)
            {
                return new Color(values[0], values[1], values[2], values[3]);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (value is Color)
            {
                Color instance = (Color)value;

                if (destinationType == typeof(string))
                    return ConvertToString<float>(context, culture,
                        new float[] { instance.R, instance.G, instance.B, instance.A });

                if (IsTypeInstanceDescriptor(destinationType))
                    return CreateInstanceDescriptor<Color>(new object[] { instance.R, instance.G, instance.B, instance.A });
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues");

            return new Color((byte)propertyValues["R"], (byte)propertyValues["G"], (byte)propertyValues["B"], (byte)propertyValues["A"]);
        }
    }

#endif
}
