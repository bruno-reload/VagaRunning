using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrid : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 size;
    public Vector2 resolution;
    private byte[,] cell;
    void Start()
    {
        int i = (int)((1.0f / resolution.x) * size.x);
        int j = (int)((1.0f / resolution.y) * size.y + 2);

        cell = new byte[i, j];

        for (int l = 0; l < i; l++)
        {
            for (int c = 0; c < j; c++)
            {
                cell[l, c] = (byte)0;
            }

        }
    }

    public void setCell(int l, int c, Tile t)
    {
        cell[l, c] = t.mask;
    }
    public byte getCell(int l, int c)
    {
        return cell[l, c];
    }
    public byte neighborhoorMask(int l, int c)
    {
        return (byte)((cell[l - 1, c] & 0x8) &
        (cell[l, c - 1] & 0x1) &
        (cell[l + 1, c] & 0x4) &
        (cell[l, c + 1] & 0x2) &
        (cell[l - 1, c - 1] & 0x80) &
        (cell[l + 1, c - 1] & 0x40) &
        (cell[l - 1, c + 1] & 0x20) &
        (cell[l + 1, c + 1] & 0x10));
    }
}
