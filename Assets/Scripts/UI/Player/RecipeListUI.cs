using CrashedWorld.Crafts;
using CrashedWorld.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
    public class RecipeListUI : MonoBehaviour
    {
        public VerticalLayoutGroup recipeContainer;
        public RecipeUI recipePrefab;

        public void Init()
		{
            foreach (Transform child in recipeContainer.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Recipe recipe in CraftManager.Instance.recipes)
			{
                Instantiate(recipePrefab, recipeContainer.transform).Init(recipe);
			}
		}

        public void Show()
		{
            gameObject.SetActive(true);
		}

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}


