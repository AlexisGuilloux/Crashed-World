using CrashedWorld.Crafts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrashedWorld.Items
{
	public interface IUpgradable
	{
		/// <summary>
		/// The function return null if the object can no longer be upgraded
		/// </summary>
		/// <returns>The upgrade recipe</returns>
		List<Recipe> GetUpgradeRecipes();
	}
}
	