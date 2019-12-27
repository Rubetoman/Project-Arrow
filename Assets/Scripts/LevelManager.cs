using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public enum BlockType {Breakable, Unbreakable, Obstacle, Goal, None }

public class Block
{
    public Block(TileBase tile, BlockType type = BlockType.None) { this.tile = tile; this.type = type; }
    TileBase tile;
    BlockType type;
}

public class LevelManager : MonoBehaviour
{
    public Tilemap blocksTilemap;


    private Block[,] blocks;

    // Start is called before the first frame update
    void Start()
    {
        ConvertTilesToLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ConvertTilesToLevel()
    {
        uint column = 0u;
        uint row = 0u;
        uint maxColumn = (uint)(blocksTilemap.cellBounds.xMax - blocksTilemap.cellBounds.xMin);
        uint maxRow = (uint)(blocksTilemap.cellBounds.yMax - blocksTilemap.cellBounds.yMin);

        blocks = new Block[maxColumn, maxRow];
        for (int n = blocksTilemap.cellBounds.xMin; n < blocksTilemap.cellBounds.xMax; ++n)
        {
            for (int p = blocksTilemap.cellBounds.yMin; p < blocksTilemap.cellBounds.yMax; ++p)
            {

                Vector3Int localPlace = (new Vector3Int(n, p, 0));

                TileBase currentTile = blocksTilemap.GetTile(localPlace);
                if(currentTile != null)
                    blocks[column, row] = new Block(currentTile);

                ++row;
            }
            ++column; row = 0;
        }
    }
}
