using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectPacker;

/// <summary>
/// Represents size of an area consisting of Width and Height
/// </summary>
public struct Size {

    /// <summary>
    /// Width of the area
    /// </summary>
    public int Width;

    /// <summary>
    /// Height of the area
    /// </summary>
    public int Height;

    /// <summary>
    /// Constructs a new Size from width and height
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Size(int width, int height) {
        Width = width;
        Height = height;
    }
}