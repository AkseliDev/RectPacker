using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectPacker;

/// <summary>
/// Represents a Dirty Rectangle in the atlas. A dirty rect or area means that area couldn't fit in the atlas
/// vertically anymore, so it has to be placed somewhere else, making the atlas dirty.
/// 
/// <para>Documentation pending due to unfinished state.</para>
/// </summary>
internal struct DirtyRect {

    /// <summary>
    /// Rectangle of the dirty area
    /// </summary>
    public Rect Rect;

    public int RowIndex;

    public DirtyRect(Rect rect, int rowIndex) {
        Rect = rect;
        RowIndex = rowIndex;
    }
}