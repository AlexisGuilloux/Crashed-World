using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace CrashedWorld.Loots.Editor
{
	[CustomEditor(typeof(LootHolder))]
	[CanEditMultipleObjects]
	public class LootHolderEditor : UnityEditor.Editor
	{
		LootHolder holder;

		public override void OnInspectorGUI()
		{
			holder ??= (LootHolder)target;

			base.OnInspectorGUI();

			ShowPercentage();
		}

		private void ShowPercentage()
		{
			int sum = holder.lootsData.Sum(i => i.weight);
			if (sum != 0)
			{
				int ratio = 100 / sum;
				List<int> normalizedList = holder.lootsData.Select(i => i.weight * ratio).ToList();

				for (int i = 0; i < normalizedList.Count; i++)
				{
					EditorGUILayout.LabelField($"Element {i} - {normalizedList[i]}%");
					EditorGUILayout.LabelField($"({string.Join(", ", holder.lootsData[i].items)})");
				}
			}
		}
	}
}
