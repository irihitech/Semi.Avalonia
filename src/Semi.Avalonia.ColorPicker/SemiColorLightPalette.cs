using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Utilities;

namespace Semi.Avalonia.ColorPicker;

public class SemiColorLightPalette: IColorPalette
{
    private static readonly Color[,] Colors = new Color[,]
    {
        {
            Color.FromUInt32(0xFFFEF2ED),
        },
        {
            Color.FromUInt32(0xFFFEF2ED),
        }
    };
    public Color GetColor(int colorIndex, int shadeIndex)
    {
        return Colors[
            MathUtilities.Clamp(colorIndex, 0, ColorCount - 1),
            MathUtilities.Clamp(shadeIndex, 0, ShadeCount - 1)
        ];
    }

    public int ColorCount => Colors.GetLength(0);

    public int ShadeCount => Colors.GetLength(1);
}