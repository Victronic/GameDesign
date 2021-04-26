
using UnityEngine;

public class ItemStash : ItemContainer
{
    [SerializeField] Transform itemsParent;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] KeyCode openKeycode = KeyCode.E;

    private bool isInRange;
    private bool isOpen;

    private Character character;
    protected override void OnValidate()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>(includeInactive: true);
        spriteRenderer.enabled = false;
    }

    protected override void Start()
    {
        base.Start();
        itemsParent.gameObject.SetActive(false);
    }
    private void Update()
    {
       if(isInRange && Input.GetKeyDown(openKeycode))
        {
            isOpen = !isOpen;
            itemsParent.gameObject.SetActive(isOpen);

            if (isOpen)
                character.OpenItemCotainer(this);
            else
                character.CloseItemCotainer(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckCollision(other.gameObject, true);
    }

    private void OnTriggerExit(Collider other)
    {
        CheckCollision(other.gameObject, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckCollision(collision.gameObject, false);
    }

    private void CheckCollision(GameObject gameObject, bool state)
    {
        if (gameObject.CompareTag("Player"))
        {
            isInRange = state;
            spriteRenderer.enabled = state;

            if (!isInRange && isOpen)
            {
                isOpen = false;
                itemsParent.gameObject.SetActive(false);
                character.CloseItemCotainer(this);
            }

            if (isInRange)
                character = gameObject.GetComponent<Character>();
            else
                character = null;
        }
    }
}
