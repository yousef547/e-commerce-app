using System.ComponentModel;
using System.Reflection;

namespace E_commerce_app.Helpers
{
    public static class GetEnumStatusDescription
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                DescriptionAttribute attribute =
                    Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }
            return value.ToString();
        }
    }
}
