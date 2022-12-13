using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {
    //public Renderer textureRenderer;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public MeshFilter edgeFilter;
    public MeshRenderer edgeRenderer;
    public void DrawTerrainMesh(Cell[,] grid, int size) {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();
        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                Cell cell = grid[x, y];
                if(!cell.isWater) {
                    Vector3 a = new Vector3(x - .5f, 0, y + .5f);
                    Vector3 b = new Vector3(x + .5f, 0, y + .5f);
                    Vector3 c = new Vector3(x - .5f, 0, y - .5f);
                    Vector3 d = new Vector3(x + .5f, 0, y - .5f);
                    Vector2 uvA = new Vector2(x / (float)size, y / (float)size);
                    Vector2 uvB = new Vector2((x + 1) / (float)size, y / (float)size);
                    Vector2 uvC = new Vector2(x / (float)size, (y + 1) / (float)size);
                    Vector2 uvD = new Vector2((x + 1) / (float)size, (y + 1) / (float)size);
                    Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                    Vector2[] uv = new Vector2[] { uvA, uvB, uvC, uvB, uvD, uvC };
                    for(int k = 0; k < 6; k++) {
                        vertices.Add(v[k]);
                        triangles.Add(triangles.Count);
                        uvs.Add(uv[k]);
                    }
                }
            }
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
        
        meshFilter.sharedMesh = mesh;
        DrawTexture(grid,size);
        DrawEdge(grid,size);
    }
    
    void DrawTexture(Cell[,] grid, int size) {
        Texture2D texture = new Texture2D(size, size);
        Color[] colorMap = new Color[size * size];
        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                Cell cell = grid[x, y];
                if(cell.isWater)
                    colorMap[y * size + x] = Color.blue;
                else
                    colorMap[y * size + x] = new Color(0.45f, 0.75f, 0.08f);
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(colorMap);
        texture.Apply();

        meshRenderer.sharedMaterial.mainTexture = texture;
    }

    void DrawEdge(Cell[,] grid, int size) {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                Cell cell = grid[x, y];
                if(!cell.isWater) {
                    if(x > 0) {
                        Cell left = grid[x - 1, y];
                        if(left.isWater) {
                            Vector3 a = new Vector3(x - .5f, 0, y + .5f);
                            Vector3 b = new Vector3(x - .5f, 0, y - .5f);
                            Vector3 c = new Vector3(x - .5f, -1, y + .5f);
                            Vector3 d = new Vector3(x - .5f, -1, y - .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for(int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                    if(x < size - 1) {
                        Cell right = grid[x + 1, y];
                        if(right.isWater) {
                            Vector3 a = new Vector3(x + .5f, 0, y - .5f);
                            Vector3 b = new Vector3(x + .5f, 0, y + .5f);
                            Vector3 c = new Vector3(x + .5f, -1, y - .5f);
                            Vector3 d = new Vector3(x + .5f, -1, y + .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for(int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                    if(y > 0) {
                        Cell down = grid[x, y - 1];
                        if(down.isWater) {
                            Vector3 a = new Vector3(x - .5f, 0, y - .5f);
                            Vector3 b = new Vector3(x + .5f, 0, y - .5f);
                            Vector3 c = new Vector3(x - .5f, -1, y - .5f);
                            Vector3 d = new Vector3(x + .5f, -1, y - .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for(int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                    if(y < size - 1) {
                        Cell up = grid[x, y + 1];
                        if(up.isWater) {
                            Vector3 a = new Vector3(x + .5f, 0, y + .5f);
                            Vector3 b = new Vector3(x - .5f, 0, y + .5f);
                            Vector3 c = new Vector3(x + .5f, -1, y + .5f);
                            Vector3 d = new Vector3(x - .5f, -1, y + .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for(int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                }
            }
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        edgeFilter.sharedMesh = mesh;
        //edgeRenderer.sharedMaterial = edgeMaterial;
    }
    // public void DrawTexture(Texture2D texture) {
    //     textureRenderer.sharedMaterial.mainTexture = texture;
    //     textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    // }
    // public void DrawMesh(MeshData meshData, Texture2D texture) {
    //     meshFilter.sharedMesh = meshData.createMesh();
    //     meshRenderer.sharedMaterial.mainTexture = texture;
    // }
}