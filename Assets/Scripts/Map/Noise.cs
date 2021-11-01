using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{

    //2���� �迭 �޸������� ���� �޼ҵ�
    public static float[,] GeneratePerlinNoiseMap(int mapX, int mapY, float seed, float scale, int xoff, int yoff, 
                                                    int octaves, float persistance, float lacunarity) //persistance=1���� ����, lacunarity=1����ŭ
    {
        //mapX = ���� ����ũ��
        //mapY = ���� ����ũ��
        //seed = �� �õ�

        float[,] noiseMap = new float[mapX, mapY];

        for(int y=0; y<mapY; y++)
        {
            for(int x=0; x<mapX; x++)
            {

                float amplitude = 1;
                float freequency = 1;
                float noiseHeight = 0;

                for(int i=0; i<octaves; i++)
                {
                    float seedX = (x + seed + xoff) * scale * freequency;
                    float seedY = (y + seed + yoff) * scale * freequency;

                    noiseHeight += Mathf.PerlinNoise((float)seedX, (float)seedY) * amplitude;

                    amplitude *= persistance; //�����۾���
                    freequency *= lacunarity; //����Ŀ��    
                }
                noiseMap[x, y] = noiseHeight;
            }
        }

        return noiseMap;
    }

    public static int GenerateRandomSeed()
    {
        int number = 0;
        while (number == 0)
        {
            number = Random.Range(-100000, 100000);
        }
        Debug.Log("RandomSeed Generated!" + number);
        return number;
    }
}