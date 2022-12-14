using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour {
    public float waterLevel = .4f;
    float scale = .1f;
    public int size = 100;
    int seed = 0;
    Cell[,] grid;

    private void Start() {
        DrawMapInEditor();
        
        AnalyticEventTrigger.SendMapGenerationEvent(size, waterLevel);
    }

    void GenerateMapData() {
        float[,] noiseMap = generateNoiseMap(size, seed, scale);
        float[,] falloffMap = generateFalloffMap(size);
        grid = new Cell[size, size];
        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                float noiseValue = noiseMap[x, y];
                noiseValue -= falloffMap[x, y];
                bool isWater = noiseValue < waterLevel;
                Cell cell = new Cell(isWater);
                grid[x, y] = cell;
            }
        }
    }

    float[,] generateNoiseMap(int size, int seed, float scale) {  //add default persistance and lacunarity if wanting a more detailed map
        float[,] noiseMap = new float[size, size];
        System.Random prng = new System.Random(seed);
        (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }
        return noiseMap;
    }

    float[,] generateFalloffMap(int size) {
        float[,] falloffMap = new float[size, size];
        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                float xv = x / (float)size * 2 - 1;
                float yv = y / (float)size * 2 - 1;
                float v = Mathf.Max(Mathf.Abs(xv), Mathf.Abs(yv));
                falloffMap[x, y] = Mathf.Pow(v, 3f) / (Mathf.Pow(v, 3f) + Mathf.Pow(2.2f - 2.2f * v, 3f));
            }
        }
        return falloffMap;
    }
    


    public void DrawMapInEditor() {
        GenerateMapData();
        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawTerrainMesh(grid, size);
    }
}
