using Procedural_Generation;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class AutoGenerateInEditor : Editor
{
    public override void OnInspectorGUI() {
        MapGenerator mapGen = (MapGenerator)target;
        if (DrawDefaultInspector()) {
            // if (mapGen.autoUpdate) {
            mapGen.DrawMapInEditor();
            // }
        }
        if (GUILayout.Button("Generate")) {
            mapGen.DrawMapInEditor();
            mapGen.GenerateCrystals();
        }
    }
}