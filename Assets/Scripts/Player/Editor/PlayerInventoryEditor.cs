using CrashedWorld.Attribute;
using CrashedWorld.Items;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CrashedWorld.Player.Editor
{
	[CustomEditor(typeof(PlayerInventory))]
    [CanEditMultipleObjects]
	public class PlayerInventoryEditor : UnityEditor.Editor
	{
		PlayerInventory pInv;
		Item targetItem; 

		public override void OnInspectorGUI()
		{
			pInv ??= (PlayerInventory)target;

			if (Application.isPlaying)
			{
				EditorGUILayout.BeginHorizontal();
				targetItem = (Item)EditorGUILayout.ObjectField("Item", targetItem, typeof(Item), false);
				if (GUILayout.Button("Add Item"))
					pInv.bag.Add(targetItem);
				EditorGUILayout.EndHorizontal();

				foreach (KeyValuePair<string, int> kvp in pInv.bag.items)
				{
					EditorGUILayout.LabelField($"{kvp.Key} x{kvp.Value}");
				}
			}
			else
			{
				base.OnInspectorGUI();
			}
		}
	}
}
