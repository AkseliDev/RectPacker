using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RectPacker;

public struct Rect {
    
    public int X;
    public int Y;
    public int Width;
    public int Height;
    
    public Rect(int x, int y, int width, int height) {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}

public struct Size {
    
    public int Width;
    public int Height;

    public Size(int width, int height) {
        Width = width;
        Height = height;
    }
}

public class Packer {

    struct RowState {
        public int Height;
        public int X;
        public int Y;
        
        public RowState(int height, int x, int y) {
            Height = height;
            X = x;
            Y = y;
        }
    }
    
    struct DirtyRect {
        
        public Rect Rect;
        public int RowIndex;

        public DirtyRect(Rect rect, int rowIndex) {
            Rect = rect;
            RowIndex = rowIndex;
        }
    }

    /// <summary>
    /// Maximum possible size of the packed area
    /// </summary>
    public const int MaxSize = ushort.MaxValue / 2;

    /// <summary>
    /// Width of the packed area
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Height of the packed area
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Row states of the packed area
    /// </summary>
    private List<RowState> _rows;
    
    // TODO private List<DirtyRect> _dirtyRegions;

    /// <summary>
    /// Initializes a new instance of a rect packer. The given width and height are rounded up to power of 2s.
    /// </summary>
    /// <param name="width">Width of the area</param>
    /// <param name="height">Height of the area</param>
    /// <exception cref="ArgumentOutOfRangeException">If the width or height exceed the maximum size of the packed area <see cref="MaxSize"/></exception>
    public Packer(int width, int height) {
        
        if ((uint)width > MaxSize || (uint)height > MaxSize) {
            throw new ArgumentOutOfRangeException("width or height exceeds the maximum size");
        }

        // round up to power of 2s
        Width = (int)BitOperations.RoundUpToPowerOf2((uint)width);
        Height = (int)BitOperations.RoundUpToPowerOf2((uint)height);

        _rows = new List<RowState>();
        
        // TODO _dirtyRegions = new List<DirtyRect>();
    }

    /// <summary>
    /// Packs a rect as tightly as possible into the packed area and returns the location
    /// </summary>
    /// <param name="size">Size of the rect to pack</param>
    /// <returns>Location of the inputted rect in the packed area</returns>
    /// <exception cref="ArgumentException">If the size given is bigger than the packed area</exception>
    /// <exception cref="Exception">If the rect couldn't be successfully packed (out of space)</exception>
    public Rect PackArea(Size size) {

        // no point trying to fit the area if its impossible
        if (size.Width > Width || size.Height > Height) {
            throw new ArgumentException("Inputted area is bigger than the packed area.");
        }

        int y = 0;

        // loop all existing rows
        for(int i = 0; i < _rows.Count; i++) {

            var row = _rows[i];

            // need to check if there are any existing rows that can fit the area
            if (row.Height == size.Height && row.X + size.Width < Width) {

                // push and update the new state of the row
                row.X += size.Width;
                _rows[i] = row;

                // return the location in the packed area
                return new Rect(row.X - size.Width, row.Y, size.Width, size.Height);
            }

            y += row.Height;
        }

        // verify if the new row can fit in the packed area
        if (y + size.Height < Height) {

            // add the new row and return the location

            _rows.Add(new RowState(size.Height, size.Width, y));

            return new Rect(0, y, size.Width, size.Height);
        }

        // okay, there was no space, lets try to fit it inside another row
        int smallestDiff = int.MaxValue;
        int foundIndex = -1;
        
        for(int i = 0; i < _rows.Count; i++) {
            
            var row = _rows[i];
            
            int diff = row.Height - size.Height;

            // check if the row is big enough to hold the area, also try to find the smallest difference
            if (size.Height < row.Height && diff < smallestDiff && row.X + size.Width < Width) {

                smallestDiff = diff;
                foundIndex = i;

                // 1 pixel is the smallest difference possible
                if (diff == 1) {
                    break;
                }

            }
        }

        if (foundIndex >= 0) {

            // update the row
            var row = _rows[foundIndex];
            row.X += size.Width;
            _rows[foundIndex] = row;

            // add the rects to dirty rects list
            var rect = new Rect(row.X - size.Width, row.Y, size.Width, size.Height);

            // TODO _dirtyRegions.Add(new DirtyRect(rect, foundIndex));

            return rect;
        }
        
        // TODO: add mapping all possible regions and attempt filling

        throw new Exception("Unable to fit the area in packed area");
    }
}