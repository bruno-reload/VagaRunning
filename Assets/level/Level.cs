using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleGrid))]
public class Level : MonoBehaviour
{
    [SerializeField]
    public Tile[] tiles;
    public Tile[] water;
    public Dictionary<byte, Tile> spriteFloor;
    public Dictionary<byte, Tile> spriteWater;
    private SimpleGrid simpleGrid;

    void Start()
    {
        simpleGrid = GetComponent<SimpleGrid>();
        spriteFloor = new Dictionary<byte, Tile>();
        spriteWater = new Dictionary<byte, Tile>();

        foreach (Tile item in tiles)
        {
            foreach (byte b in spriteFloor.Keys)
            {
                if (b == item.mask)
                {
                    Debug.Log(item.name);
                    Debug.Log(spriteFloor[b]);
                }
            }
            spriteFloor.Add(item.getMask(), item);
        }
        foreach (Tile item in water)
        {
            foreach (byte b in spriteWater.Keys)
            {
                if (b == item.mask)
                {
                    Debug.Log(item.name);
                    Debug.Log(spriteWater[b]);
                }
            }
            spriteWater.Add(item.getMask(), item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {

            if (simpleGrid.neighborhoorMask(5, 4) == 0)
            {
                foreach (byte key in spriteFloor.Keys)
                {
                    if (spriteFloor[key].start)
                    {
                        // definir a forma com a qual serão iniciadas as contruções de plataforma
                        Instantiate(spriteFloor[key]);
                        simpleGrid.setCell(5, 4, spriteFloor[key]);
                    }
                }
            }
            else
            {

            }

        }
    }
}
