using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Chunk
{

    private static float[,] noiseMap;
    public static int tileNumberPerChunk { get; set; }
    //�⺻16

    //ûũ��ü��ǥ=>ûũ��ǥ
    //ûũ������ǥ=>ûũ �� 0,0~15,15 ���� ��ǥ


    //������ǥ�� ûũ��ü ��ǥ��
    public static (int chunkcoord_x, int chunkcoord_y) getChunkCoord(int world_x, int world_y) //ûũ ��ü�� ��ǥ=ChunkCoord
    {
        int chunkcoord_x;
        int chunkcoord_y;

        // ������ǥ=>ûũ��ü��ǥ
        // 0,0 => 0,0 
        // 0,-16 => 0,-1
        // 0,-5=> 0,-1
        // 0,5=>0,1

        // 3,3 => 0,0
        //-3,-3=> -1,-1
        //-3,3 => -1, 0
        // 3,-3=> 0,-1

        if (world_x >= 0)
        {
            chunkcoord_x = world_x / tileNumberPerChunk;
        }
        else
        {
            chunkcoord_x = world_x / tileNumberPerChunk - 1;
        }

        if (world_y >= 0)
        {
            chunkcoord_y = world_y / tileNumberPerChunk;
        }
        else
        {
            chunkcoord_y = world_y / tileNumberPerChunk - 1;
        }

        return (chunkcoord_x, chunkcoord_y);
    }

    //������ǥ�� ûũ���� ��ǥ��
    public static (int chunk_x, int chunk_y) getChunkInnerXY(int world_x, int world_y)
    {
        int chunk_x;
        int chunk_y;

        if (world_x >=0)
        {
            chunk_x = world_x % tileNumberPerChunk;
        }
        else
        {
            if (world_x % tileNumberPerChunk == 0)
                chunk_x = 0;
            else
                chunk_x = 16 + (world_x % tileNumberPerChunk);
        }

        if (world_y >= 0)
        {
            chunk_y = world_y % tileNumberPerChunk;
        }
        else
        {
            if (world_y % tileNumberPerChunk == 0)
                chunk_y = 0;
            else
                chunk_y = 16 + (world_y % tileNumberPerChunk);
        }

        return (chunk_x, chunk_y);
    }

    //ûũ��ü, ûũ���� ��ǥ�� ������ǥ��
    public static (int world_x, int world_y) getWorldXY(int chunkcoord_x, int chunkcoord_y, int chunk_x, int chunk_y)
    {


        int world_x = chunkcoord_x * tileNumberPerChunk + chunk_x;
        int world_y = chunkcoord_y * tileNumberPerChunk + chunk_y;

        return (world_x, world_y);
    }

    public static void GenerateChunk(int chunkcoord_x, int chunkcoord_y)
    {
        int chunkSize = tileNumberPerChunk;

        int x_off = chunkcoord_x * chunkSize;
        int y_off = chunkcoord_y * chunkSize;

        noiseMap = Noise.GeneratePerlinNoiseMap(chunkSize, chunkSize, TileMap.Instance.mapSeed, TileMap.Instance.scale, x_off, y_off, TileMap.Instance.octaves, TileMap.Instance.persistance, TileMap.Instance.lacunarity);
    }//ûũ����

    public static void RenderChunk(int chunkcoord_x, int chunkcoord_y)
    {
        int chunkSize = tileNumberPerChunk;

        BoundsInt bounds = new BoundsInt(chunkcoord_x * chunkSize, chunkcoord_y * chunkSize, 0, chunkSize, chunkSize, 1);
        TileBase[] newtilebase = new TileBase[chunkSize * chunkSize];

        for (int i = 0; i < newtilebase.Length; i++)
        {
            var (x, y) = Subtitution(i, chunkSize);
            if (noiseMap[x, y] <= 1.0f)
                newtilebase[i] = TileMap.Instance.water;
            if (noiseMap[x, y] > 1.0f && noiseMap[x, y] < 1.3f)
                newtilebase[i] = TileMap.Instance.rock;
            if (noiseMap[x, y] >= 1.3f)
                newtilebase[i] = TileMap.Instance.tilebase;
        }

        TileMap.Instance.tileMap.SetTilesBlock(bounds, newtilebase);
    }//ûũ������
    private static (int x, int y) Subtitution(int i, int width)
    {
        int x = 0;
        int y = 0;

        if (i >= width)
        {
            x = i % width;
            y = i / width;

        }
        else if (i < width)
        {
            x = i;
            y = 0;
        }

        return (x, y);
    } //1�����迭�� 2�����迭�� �ٲ� width=2�����迭 ���α���, i=1�����迭index
}
