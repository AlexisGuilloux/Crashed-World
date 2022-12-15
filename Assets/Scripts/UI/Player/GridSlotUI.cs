
using CrashedWorld.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class GridSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
	{
		public Color hoverColor = Color.white;
		public Image frame;
		public Image icon;
		public TextMeshProUGUI amountLabel;

		public string ItemID => item?.ID;
		public bool Empty => item == null;

		public Item item { get; private set; }
		public int index { get; private set; }
		public int amount { get; private set; }

		public void Init(Item item, int index)
		{
			this.index = index;
			SetItem(item);
		}

		public void SetItem(Item item, int value = 1)
		{
			if (item == null)
			{
				this.item = null;
				amount = 0;
				icon.color = Color.clear;
				amountLabel.text = string.Empty;
			}
			else
			{
				this.item = item;
				amount = value;
				icon.color = Color.white;
				icon.sprite = item.icon;
				amountLabel.gameObject.SetActive(item.isStackable);
				amountLabel.text = "x" + amount.ToString();
			}
		}

		public void AddAmount(int value = 1)
		{
			amount += value;
			amountLabel.text = "x" + amount.ToString();
		}

		public void RemoveAmount(int value = 1)
		{
			amount -= value;

			if (amount <= 0)
				SetItem(null);
			else
				amountLabel.text = "x" + amount.ToString();
		}

		#region UI Events
		public void OnPointerEnter(PointerEventData data)
		{
			frame.color = hoverColor;
		}

		public void OnPointerExit(PointerEventData data)
		{
			frame.color = Color.white;
		}

		public void OnPointerClick(PointerEventData data)
		{
			Locator.playerInventory.OnClickSlot(item, transform.position);
		}

		public void OnBeginDrag(PointerEventData data)
		{
			if (Empty)
				return;

			Locator.playerInventory.dragImage.gameObject.SetActive(true);
			Locator.playerInventory.dragImage.sprite = item.icon;
			Locator.playerInventory.dragImage.transform.position = Input.mousePosition;
		}

		public void OnDrag(PointerEventData data)
		{
			if (Empty)
				return;

			Locator.playerInventory.dragImage.transform.position = Input.mousePosition;
		}

		public void OnEndDrag(PointerEventData data)
		{
			Locator.playerInventory.dragImage.gameObject.SetActive(false);
		}

		public void OnDrop(PointerEventData data)
		{
			if (Empty)
			{
				if (data.pointerDrag.TryGetComponent(out GridSlotUI originSlot))
				{
					(Item, int) itemAmount = (originSlot.item, originSlot.amount);
					originSlot.SetItem(null);
					SetItem(itemAmount.Item1, itemAmount.Item2);
				}
			}
		}
		#endregion
	}
}


