using UnityEngine;
using System;
public abstract class ItemContainer : MonoBehaviour,IItemContainer
{
    public ItemSlot[] ItemSlots;

    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    protected virtual void OnValidate()
    {
        ItemSlots = GetComponentsInChildren<ItemSlot>(includeInactive: true);
    }

    protected virtual void Awake()
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            ItemSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
            ItemSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
            ItemSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            ItemSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
            ItemSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
            ItemSlots[i].OnDragEvent += slot => OnDragEvent(slot);
            ItemSlots[i].OnDropEvent += slot => OnDropEvent(slot);
        }
    }
    public virtual bool CanAddItem(Item item, int amount = 1)
    {
        int freeSpace = 0;
        foreach (ItemSlot itemSlot in ItemSlots)
        {
            if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
            {
                freeSpace += item.MaximumStacks - itemSlot.Amount;
            }
        }

        return freeSpace >= amount;
    }
    public virtual bool AddItem(Item item)
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (ItemSlots[i].CanAddStack(item))
            {
                ItemSlots[i].Item = item;
                ItemSlots[i].Amount++;
                return true;
            }
        }

        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (ItemSlots[i].Item == null)
            {
                ItemSlots[i].Item = item;
                ItemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public virtual bool RemoveItem(Item item)
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (ItemSlots[i].Item == item)
            {
                ItemSlots[i].Amount--;
                return true;
            }
        }
        return false;
    }

    public Item RemoveItem(string itemID)
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            Item item = ItemSlots[i].Item;
            if (item != null && item.ID == itemID)
            {
                ItemSlots[i].Amount--;
                return item;
            }
        }
        return null;
    }


    /*public virtual bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }*/

    public virtual int ItemCount(string itemID)
    {
        int number = 0;

        for (int i = 0; i < ItemSlots.Length; i++)
        {
            Item item = ItemSlots[i].Item;
            if (item !=null && item.ID == itemID)
            {
                number += ItemSlots[i].Amount;
            }
        }
        return number;
    }

    public virtual void Clear()
    {
        for (int i=0; i< ItemSlots.Length; i++)
        {
            ItemSlots[i].Item = null;
        }
    }
}
