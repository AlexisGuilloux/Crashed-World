using CrashedWorld.Items;
using CrashedWorld.Player;
using UnityEngine;

namespace CrashedWorld.UI
{
	public class ActionBarUI : MonoBehaviour
	{
		public GridSlotUI slot;
		public Animator animator;

		private void Start()
		{
			slot.Init(null, -1);
			slot.OnDropItem += Slot_OnDropItem;
			PlayerAction.OnUseItem += PlayerAction_OnUseItem;
		}

		private void PlayerAction_OnUseItem(Item item)
		{
			animator.SetTrigger("use");
		}

		private void Slot_OnDropItem(Item item)
		{
			PlayerAction.Instance.SelectItem(item);
		}
	}
}


