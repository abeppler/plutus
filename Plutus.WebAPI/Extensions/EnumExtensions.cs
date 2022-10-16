using System.ComponentModel;
using System.Reflection;

namespace Plutus.WebAPI.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type genericEnumType = value.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(value.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Length > 0))
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return value.ToString();
        }
                
        public static List<KeyValuePair<TEnum, string>> GetList<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();
            return ((TEnum[])Enum.GetValues(typeof(TEnum)))
               .ToDictionary(k => k, v => ((Enum)(object)v).GetDescription())
               .ToList();
        }
    }
}
