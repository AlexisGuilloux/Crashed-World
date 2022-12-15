using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Procedural_Generation {
    public class MapGenerator : MonoBehaviour {
        public int size = 100;  //need to be smaller than 188 ?
        public bool useFalloff = true;
        [Range(0,1)]
        public float waterLevel = .4f;
        [Range(0,1)]
        public float treeDensity = .5f;
        float treeNoiseScale = 20f;

        public float scale;
        public int seed;
        public Vector2 offset;
        Cell[,] grid;
        private float[,] noiseMap;
        public GameObject[] prefabs;
        private List<GameObject> objectsOnMap = new List<GameObject>();
        private void Start() {
            DrawMapInEditor();
        }

        void GenerateMapData() {
            noiseMap = GenerateNoiseMap(size, seed, scale, offset);
            float[,] falloffMap = GenerateFalloffMap(size);
            grid = new Cell[size, size];
            for(int y = 0; y < size; y++) {
                for(int x = 0; x < size; x++) {
                    float noiseValue = noiseMap[x, y];
                    if (useFalloff) {
                        noiseValue = Mathf.Clamp01(noiseValue - falloffMap[x, y]);
                    }
                    bool isWater = noiseValue < waterLevel;
                    if (noiseValue > 1 || noiseValue < 0) {
                        Debug.Log(noiseValue);}
                    Cell cell = new Cell(isWater);
                    grid[x, y] = cell;
                }
            }


        }

        float[,] GenerateNoiseMap(int size, int seed, float scale, Vector2 offset) {  //add default persistance and lacunarity if wanting a more detailed map
            float[,] noiseMap = new float[size, size];
            System.Random prng = new System.Random(seed);
            (float xOffset, float yOffset) = (prng.Next(-100000, 100000) + offset.x, prng.Next(-100000, 100000) + offset.y);

            for(int y = 0; y < size; y++) {
                for(int x = 0; x < size; x++) {
                    float noiseValue =
                        Mathf.PerlinNoise((x - size / 2) / scale + xOffset, (y - size / 2) / scale + yOffset);
                    noiseMap[x, y] = noiseValue;
                }
            }
            return noiseMap;
        }

        float[,] GenerateFalloffMap(int size) {
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

        void GenerateCrystals(Cell[,] grid) {
            float[,] treeNoiseMap = GenerateNoiseMap(size, seed, treeNoiseScale, offset);
            for (int y = 0; y < size; y++) {
                for (int x = 0; x < size; x++) {
                    Cell cell = grid[x, y];
                    if (!cell.isWater) {
                        float v = Random.Range(0f, treeDensity);
                        if (treeNoiseMap[x, y] < v) {
                            //that's a tree
                            GameObject prefab = prefabs[Random.Range(0,prefabs.Length)];
                            GameObject tree = Instantiate(prefab, transform);
                            tree.transform.position = new Vector3(x, 0, y);
                            tree.transform.rotation = Quaternion.Euler(0, Random.Range(0,360f),0);
                            tree.transform.localScale = Vector3.one * Random.Range(.8f,1.2f);
                            objectsOnMap.Add(tree);
                        }
                    }
                }
            }
        }

        private void OnValidate() {
            if (scale < 1) {
                scale = 1;
            }

            if (treeDensity < 0) {
                treeDensity = 0;
            }
        }

        public void DrawMapInEditor() {
            foreach (var tree in objectsOnMap) {
                DestroyImmediate(tree);
            }
            objectsOnMap.Clear();
            GenerateMapData();
            MapDisplay display = FindObjectOfType<MapDisplay>();
            GenerateCrystals(grid);
            display.DrawTerrainMesh(grid, size);
        }
    }
}
