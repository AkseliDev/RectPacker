# RectPacker

Rect packer is a tool created specifically for sprite packing. It is used to pack rectangles (sprites) into a bigger area as tight as possible (a spritesheet). The packing algorithm is my own custom algorithm. No texture manipulation is shipped with this project, this is just a packer for rectangles, the actual texture generation is left to the user. Thus this packer is cross platform and graphics api independent.

## Example usage

Used correctly the packer should reach results like this:

 - Where each color represents a different size sprite
 - Where black color represents the empty space
 
 ![results](https://user-images.githubusercontent.com/96961979/179387452-fea619b1-d0d7-46c0-9fb8-83ec897f14cb.png)
 
 Another picture with some padding adding to help to distinguish other sprites:
 ![results](https://user-images.githubusercontent.com/96961979/179387526-9e7f0846-6c30-4ef4-96e1-a3af711d06c9.png)
