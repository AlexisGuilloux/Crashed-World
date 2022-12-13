using UnityEditor;
using UnityEngine;

public class DatabaseSingleton<T> : ScriptableObject where T : ScriptableObject
{
    /// <summary>
    /// EDITOR ONLY
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = AssetDatabase.LoadAssetAtPath<T>($"Assets/Databases/{typeof(T).Name}.asset");

            return instance;
        }
    }

    private static T instance;
}
