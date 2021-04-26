using UnityEngine.EventSystems;
using UnityEngine;
using System;
public class DropItemArea : MonoBehaviour,IDropHandler
{
    public event Action OnDropEvent;

    public void OnDrop(PointerEventData eventData)
    {
        if(OnDropEvent != null)
        {
            OnDropEvent();
        }
    }
}
