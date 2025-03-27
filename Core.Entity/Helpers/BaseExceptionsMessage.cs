using System.ComponentModel;

namespace Core.Entity.Helpers;

public static class BaseExceptionsMessage
{
    /// <summary>
    /// Публикация ошибки
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string PrintException(this TypeExceptions val)
    {
        DescriptionAttribute[] attr = (DescriptionAttribute[])val
            .GetType()
            .GetField(val.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attr.Length > 0 ? attr[0].Description : string.Empty;
    }
}

