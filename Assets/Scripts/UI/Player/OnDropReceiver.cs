using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnDropReceiver : MonoBehaviour, IDropHandler
{
    public UnityEvent<PointerEventData> OnDrop;

	void IDropHandler.OnDrop(PointerEventData eventData)
	{
		Debug.Log("Test");
		OnDrop?.Invoke(eventData);
	}
}
