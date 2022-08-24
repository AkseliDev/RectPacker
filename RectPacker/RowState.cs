using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectPacker;

/// <summary>
/// State of a single row
/// </summary>
internal struct RowState {

    /// <summary>
    /// Height of this row
    /// </summary>
    public int Height;
    
    /// <summary>
    /// X state of this row
    /// </summary>
    public int X;

    /// <summary>
    /// Y location of the row in the atlas
    /// </summary>
    public int Y;

    /// <summary>
    /// Constructs a new row from height, x and y
    /// </summary>
    /// <param name="height"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public RowState(int height, int x, int y) {
        Height = height;
        X = x;
        Y = y;
    }
}