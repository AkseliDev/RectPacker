using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectPacker;

/// <summary>
/// Represents a rectangle area with X, Y, Width and Height components
/// </summary>
public struct Rect {

    /// <summary>
    /// X location of the rectangle
    /// </summary>
    public int X;

    /// <summary>
    /// Y location of the rectangle
    /// </summary>
    public int Y;

    /// <summary>
    /// Width of the rectangle
    /// </summary>
    public int Width;

    /// <summary>
    /// Height of the rectangle
    /// </summary>
    public int Height;

    /// <summary>
    /// Constructs a new rectangle from all 4 size components
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="width">Rectangle width</param>
    /// <param name="height">Rectangle height</param>
    public Rect(int x, int y, int width, int height) {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Constructs a new rectangle from X, Y and a <see cref="Size"/>
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="size">Size of the rectangle</param>
    public Rect(int x, int y, Size size) {
        X = x;
        Y = y;
        Width = size.Width;
        Height = size.Height;
    }
}