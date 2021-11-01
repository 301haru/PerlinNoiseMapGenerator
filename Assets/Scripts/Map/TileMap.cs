using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileMap : MonoBehaviour
{
    public static TileMap Instance;


    [Header("Perlin Noise Options")]
    public int mapSeed;
    public float scale;
    public int octaves;
    public float lacunarity;
    public float persistance;

    [Header("Settings")]
    public int renderDistance;
    public bool saveMap;

    [Header("Tile Options")]
    public Tilemap tileMap;
    public TileBase tilebase, rock, water;
    

    private void Awake()
    {
        Instance = this;

        Chunk.tileNumberPerChunk = 16;

        if (mapSeed == 0)
        {
            mapSeed = Noise.GenerateRandomSeed();
        }

        if (renderDistance <2)
        {
            renderDistance = 2;
        }
    }

    private void Update()
    {
        UpdateMap();
    }

    private void UpdateMap()
    {
        var (chunkcoord_x, chunkcoord_y) = Chunk.getChunkCoord(PlayerManager.Instance.getPlayerPositionXY().x, PlayerManager.Instance.getPlayerPositionXY().y);

        for (int x = -1 * renderDistance + 1; x <= renderDistance - 1; x++)
        {
            for (int y = -1 * renderDistance + 1; y <= renderDistance - 1; y++)
            {
                Chunk.GenerateChunk(chunkcoord_x + x, chunkcoord_y + y);
                Chunk.RenderChunk(chunkcoord_x + x, chunkcoord_y + y);
            }
        }
    }
}

