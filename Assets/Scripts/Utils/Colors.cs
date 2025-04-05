using UnityEngine;

public static class UtilsColor
{
    public static Color ParseHex(string hex)
    {
        if (string.IsNullOrEmpty(hex))
        {
            Debug.LogError("Hex string is null or empty!");
            return Color.black;
        }

        // Удаление символа '#' при наличии
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        // Проверка длины строки
        if (hex.Length != 6 && hex.Length != 8)
        {
            Debug.LogError("Invalid HEX format. Use #RRGGBB or #RRGGBBAA.");
            return Color.black;
        }

        // Парсинг цвета
        try
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            byte a = (hex.Length == 8)
                ? byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber)
                : (byte)255;

            return new Color32(r, g, b, a);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to parse HEX color: {ex.Message}");
            return Color.black;
        }
    }
}