using UnityEngine;
using UnityEngine.UI;
using Victor.CharacterStats;
public class Character : MonoBehaviour
{
    public int Health = 50;

    public CharacterStat ChopPower;
    public CharacterStat MiningPower;
    public CharacterStat CutPower;
    public CharacterStat HuntPower;
    public CharacterStat FishingPower;

    public Inventory Inventory;
    public EquipmentPanel EquipmentPanel;
    [SerializeField] CraftingWindow craftingWindow;
    [SerializeField] StatPanel statPanel;
    [SerializeField] ItemToolTip itemTooltip;
    [SerializeField] Image draggableItem;
    [SerializeField] DropItemArea dropItemArea;
    [SerializeField] QuestionDialogue questionDialogue;
    [SerializeField] ItemSaveManager itemSaveManager;

    private BaseItemSlot draggedSlot;

    private void OnValidate()
    {
        if (itemTooltip == null)
            itemTooltip = FindObjectOfType<ItemToolTip>();
    }


    private void Start()
    {
        statPanel.SetStats(ChopPower, MiningPower, CutPower, HuntPower,FishingPower);
        statPanel.UpdateStatValue();

        //Setup Events:
        //Right Click
        Inventory.OnRightClickEvent += InventoryRightClick;
        EquipmentPanel.OnRightClickEvent += EquipmenPanelRightClick;
        //PointerEnter
        Inventory.OnPointerEnterEvent += ShowTooltip;
        EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
        craftingWindow.OnPointerEnterEvent += ShowTooltip;
        //PointerExit
        Inventory.OnPointerExitEvent += HideTooltip;
        EquipmentPanel.OnPointerExitEvent += HideTooltip;
        craftingWindow.OnPointerEnterEvent += HideTooltip;
        //Begin Drag
        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;
        //End Drag
        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        //Drag
        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        // Drop
        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        dropItemArea.OnDropEvent += DropItemOutsideUI;

        itemSaveManager.LoadEquipment(this);
        itemSaveManager.LoadInventory(this);
    }

    private void OnDestroy()
    {
        itemSaveManager.SaveEquipment(this);
        itemSaveManager.SaveInventory(this);
    }

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
        if(itemSlot.Item is EquippableItem)
        {
            Equip((EquippableItem)itemSlot.Item);
        }
        else if(itemSlot.Item is UsableItem)
        {
            UsableItem usableItem = (UsableItem)itemSlot.Item;
            usableItem.Use(this);
            if (usableItem.IsConsumable) 
            {
                Inventory.RemoveItem(usableItem);
                usableItem.Destroy();
            }
        }
    }
    private void EquipmenPanelRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem)
        {
            Unequip((EquippableItem)itemSlot.Item);
        }
    }
    private void ShowTooltip(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            itemTooltip.ShowTooltip(itemSlot.Item);
        }
    }
    private void HideTooltip(BaseItemSlot itemSlot)
    {
        itemTooltip.HideTooltip();
    }
    private void BeginDrag(BaseItemSlot itemSlot)
    {
        if(itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }
    private void EndDrag(BaseItemSlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }
    private void Drag(BaseItemSlot itemSlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }
    private void Drop(BaseItemSlot dropItemSlot)
    {
        if (draggedSlot == null) return;

        if (dropItemSlot.CanAddStack(draggedSlot.Item))
        {
            AddStacks(dropItemSlot);
        }
        else if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
        {
            SwapItems(dropItemSlot);
        }

    }

    private void DropItemOutsideUI()
    {
        if (draggedSlot == null) return;

        questionDialogue.Show();
        BaseItemSlot baseItemSlot = draggedSlot;
        questionDialogue.OnYesEvent += ()=> DestroyItemSlot(baseItemSlot);
    }

    public void DestroyItemSlot(BaseItemSlot baseItemSlot)
    {
        baseItemSlot.Item.Destroy();
        baseItemSlot.Item = null;
    }

    private void SwapItems(BaseItemSlot dropItemSlot)
    {
        EquippableItem dragItem = draggedSlot.Item as EquippableItem;
        EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

        if (draggedSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Unequip(this);
            if (dropItem != null) dropItem.Equip(this);
        }
        if (dropItemSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Equip(this);
            if (dropItem != null) dropItem.Unequip(this);
        }
        statPanel.UpdateStatValue();

        Item draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;

        draggedSlot.Item = dropItemSlot.Item;
        draggedSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.Item.MaximumStacks = dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, draggedSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        draggedSlot.Amount -= stacksToAdd;
    }

    public void Equip(EquippableItem item)
    {
        if (Inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if(EquipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
                {
                    Inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValue();
                }
                item.Equip(this);
                statPanel.UpdateStatValue();
            }
            else
            {
                Inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValue();
            Inventory.AddItem(item);
        }
    }

    public void UpdateStatValues()
    {
        statPanel.UpdateStatValue();
    }

    private ItemContainer openItemContainer;

    public void TransferToItemContainer(BaseItemSlot itemSlot)
    {
        Item item = itemSlot.Item;
        if(item!=null && openItemContainer.CanAddItem(item))
        {
            Inventory.RemoveItem(item);
            openItemContainer.AddItem(item);
        }
    }
    
    public void TransferToInventory(BaseItemSlot itemSlot)
    {
        Item item = itemSlot.Item;
        if (item != null && openItemContainer.CanAddItem(item))
        {
            openItemContainer.RemoveItem(item);
            Inventory.AddItem(item);
        }
    }

    public void OpenItemCotainer(ItemContainer itemContainer)
    {
        openItemContainer = itemContainer;

        Inventory.OnRightClickEvent -= InventoryRightClick;
        Inventory.OnRightClickEvent += TransferToItemContainer;

        itemContainer.OnRightClickEvent += TransferToInventory;

        itemContainer.OnPointerEnterEvent += ShowTooltip;
        itemContainer.OnPointerExitEvent += HideTooltip;
        itemContainer.OnBeginDragEvent += BeginDrag;
        itemContainer.OnEndDragEvent += EndDrag;
        itemContainer.OnDragEvent += Drag;
        itemContainer.OnDropEvent += Drop;
    }

    public void CloseItemCotainer(ItemContainer itemContainer)
    {
        openItemContainer = null;

        Inventory.OnRightClickEvent += InventoryRightClick;
        Inventory.OnRightClickEvent -= TransferToItemContainer;

        itemContainer.OnRightClickEvent -= TransferToInventory;

        itemContainer.OnPointerEnterEvent += ShowTooltip;
        itemContainer.OnPointerExitEvent += HideTooltip;
        itemContainer.OnBeginDragEvent += BeginDrag;
        itemContainer.OnEndDragEvent += EndDrag;
        itemContainer.OnDragEvent += Drag;
        itemContainer.OnDropEvent += Drop;
    }
}
