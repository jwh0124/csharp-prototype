using System.ComponentModel;
using System.Reflection;

namespace iSecureGateway_Suprema.Commons.Utils
{
    public static class EnumTypeAnnotation
    {
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            string enumName = Enum.GetName(enumType, value) ?? throw new ArgumentException("Invalid enum value", nameof(value));
            FieldInfo field = enumType.GetField(enumName) ?? throw new ArgumentException("Enum value has no corresponding field", nameof(value));
            DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return enumName;
            }
        }

        public static string GetCategory(this Enum value)
        {
            Type enumType = value.GetType();
            string enumName = Enum.GetName(enumType, value) ?? throw new ArgumentException("Invalid enum value", nameof(value));
            FieldInfo field = enumType.GetField(enumName) ?? throw new ArgumentException("Enum value has no corresponding field", nameof(value));
            CategoryAttribute[] attributes = (CategoryAttribute[])field.GetCustomAttributes(typeof(CategoryAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Category;
            }
            else
            {
                return enumName;
            }
        }
    }
}
