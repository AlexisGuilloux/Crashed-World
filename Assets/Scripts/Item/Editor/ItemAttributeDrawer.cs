using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using CrashedWorld.Items;

namespace CrashedWorld.Attribute.Editor
{
	[CustomPropertyDrawer(typeof(ItemAttribute))]
	public class ItemAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string[] itemsIds = ItemDatabase.Instance.items.Select(i => i.ID).ToArray();

			int currentIndex = Mathf.Clamp(Array.IndexOf(itemsIds, property.stringValue), 0, itemsIds.Length);

			string selectedId = itemsIds[EditorGUI.Popup(position, label, currentIndex, itemsIds.Select(i => new GUIContent(i)).ToArray())];

			property.stringValue = selectedId;
		}
	}
}
