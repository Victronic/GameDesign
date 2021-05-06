﻿
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ItemContainer
{ 
    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform itemsParent;

    protected override void Start()
    {
        base.Start();
        SetStartingItems();
    }
    protected override void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>(includeInactive: true);
        SetStartingItems();
    }

    private void SetStartingItems()
    {
        Clear();
        for(int i =0; i< startingItems.Count; i++)
        {
            AddItem(startingItems[i].GetCopy());
        }
    }
}
