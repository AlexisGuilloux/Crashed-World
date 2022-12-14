using CrashedWorld.Crafts;
using CrashedWorld.Managers;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CrashedWorld.UI
{
	public class RecipeUI : MonoBehaviour
    {
        public TextMeshProUGUI label;
        public List<RecipeRequirementUI> requirements;

        public void Init(Recipe recipe)
		{
            label.text = ItemManager.Instance.database.Get(recipe.result).itemName;
            requirements.ForEach(r => r.Hide());
            for(int i = 0; i < recipe.recipies.Count; i++)
			{
                requirements[i].Init(recipe.recipies[i]);
                requirements[i].Show();
			}
		}
    }
}


