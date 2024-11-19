using System.Collections;
using System.Linq;
using Avalonia.Data.Converters;

namespace Semi.Avalonia.Converters;

public static class ItemConverter
{
    public static readonly IValueConverter ItemVisibleConverter =
        new FuncValueConverter<int?, bool>(count => count is > 1);

    public static readonly IValueConverter ItemToObjectConverter =
        new FuncValueConverter<int?, IEnumerable>(count => Enumerable.Repeat(new object(), count ?? 0));
}