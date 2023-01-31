using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomColor : MonoBehaviour
{
    public static readonly string[] WARM_EMBRACE = {"#4871E8", "#B175FF", "#AB729F", "#2D1674"};
    public static readonly string[] DEEP_BLUE = {"#050A30", "#000C66", "#0000FF", "7EC8E3"};
    public static readonly string[] WALL_GREEN = {"#778A35", "#B4FEE7", "A16AE8", "#FD49A0"};
    public static readonly string[] FLOWER_EYE = {"#C55FFC", "#EFDCF9", "#323E42", "#7954A1"};
    public static readonly string[] RAINBOW_DONUT = {"#FF5765", "#FFDB15", "#8A6FDF", "#A8E10C"};
    public static readonly string[] THE_ROYAL = {"#AA381E", "#F5BD02", "#E0DDDD", "#42B89A"};

    public static Color GetColorFromHex(string colorCode)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString(colorCode, out color);
        return color;
    }

    public static double CalcLuminance(Color color)
    {
        return 0.2126 * color.r + 0.7152 * color.g + 0.0722 * color.b;
    }
}
