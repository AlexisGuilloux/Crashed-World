using System;
using UnityEngine;

namespace CrashedWorld.Items
{
	[Serializable]
	public class WeaponTypeMultiplier
	{
		public WeaponTypes type;
		[Range(0, 1)] public float multiplier;
	}

	public enum WeaponTypes
	{
		Sword,
		Axe,
		Pickaxe,
	}
}
