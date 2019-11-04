# Gdi Sharp
a very simple component-based drawing library based on GDI+.

## Base Classes
- GdiComponent: base class of all component classes. This class defines basic properties and methods such as:
    + HorizontalAlignment
    + VerticalAlignment
    + BackgroundColor
    + Parent
    + Margin
    + GetComponentSize(Graphics graphics)
    + GetAbsolutePosition(Graphics graphics) // important method for calculating the position of the component

- GdiContainer: a component that can contains other components. Properties and methods:
    + Children
    + AddChild(GdiComponent component)
## Components

### GdiText

<img src="https://raw.githubusercontent.com/phamtung1/GdiSharp/master/screenshots/GdiText.jpg" />

```csharp
new GdiText
    {
        Font = SlimFont.Default,
        Content = "First Line\nSecond Line",
        BackgroundColor = Color.Cyan,
        TextAlign = StringAlignment.Near
    };
```

### GdiRectangle

<img src="https://raw.githubusercontent.com/phamtung1/GdiSharp/master/screenshots/GdiRectangle.jpg" />

```csharp
new GdiRectangle
    {
        Margin = new PointF(5, 5),
        Size = new SizeF(100, 50),
        BackgroundColor = Color.Yellow
    };
```

### GdiGrid
<img src="https://raw.githubusercontent.com/phamtung1/GdiSharp/master/screenshots/GdiGrid.jpg" />

```csharp
new GdiGrid
    {
        CellSize = new SizeF(20, 10),
        Size = new SizeF(200, 100),
        LineColor = Color.Cyan
    };
```

### GdiDataGrid

<img src="https://raw.githubusercontent.com/phamtung1/GdiSharp/master/screenshots/GdiDataGrid.jpg" />

```csharp

new GdiDataGrid
{
    Size = new SizeF(400, 300),
    LineColor = Color.Cyan,
    Rows = 10,
    Columns = 10,
    MergedCells = new List<DataGridMergedCell>
    {
        new DataGridMergedCell(1, 1, 3, 3)
    },
    Texts = new string[][]
    {
        new []{ "1", "1", "1" },
        new []{ "1", "1", "", "", "1" },
    }
};
```

 wanna see something more interesting?  Check this out: [SimpleImageCharts](https://github.com/phamtung1/SimpleImageCharts) (a charting library based on this project).


# License

MIT