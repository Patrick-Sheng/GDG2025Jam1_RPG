using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using System.Collections.Generic;

public class MoleRoomManager : MonoBehaviour
{
  
    public GameObject DogBone;
    public GameObject Truffle;
    public GameObject Ruby;

    [Header("Sprites")]
    public Sprite dogBoneSprite;
    public Sprite truffleSprite;
    public Sprite rubySprite;

    [Header("UI Slots")]
    public GameObject[] slots;        // Should contain slot1, slot2, slot3
    public GameObject[] imageSlots;   // Should contain imageSlot1, imageSlot2, imageSlot3

    private List<Item> inventory = new List<Item>();

    void Start()
    {
        // Ensure all slots are disabled at start
        foreach (var slot in slots)
            slot.SetActive(false);
    }

    void Update()
    {
      if (StaticManager.pushTimes >= 3) {
        StaticManager.wallCracked = true;
      }
      if (StaticManager.pickedUpBone) {
        StaticManager.pickedUpBone = false;
        DogBone.SetActive(false);
        ToggleItem(Item.DOG_BONE);
      }
      if (StaticManager.pickedUpTruffle) {
        StaticManager.pickedUpTruffle = false;
        Truffle.SetActive(false);
        ToggleItem(Item.TRUFFLE);
      }
      if (StaticManager.pickedUpRuby) {
        StaticManager.pickedUpRuby = false;
        Ruby.SetActive(false);
        ToggleItem(Item.RUBY);
      }
    }

    private void ToggleItem(Item item)
    {
        if (inventory.Contains(item))
            RemoveItem(item);
        else
            AddItem(item);
    }

    private void AddItem(Item item)
    {
        if (inventory.Count >= slots.Length)
        {
            Debug.LogWarning("Inventory full!");
            return;
        }

        inventory.Add(item);
        UpdateUI();
    }

    private void RemoveItem(Item item)
    {
        if (!inventory.Contains(item))
        {
            Debug.LogWarning("Item not in inventory!");
            return;
        }

        inventory.Remove(item);
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Clear all slots first
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Count)
            {
                slots[i].SetActive(true);
                imageSlots[i].GetComponent<UnityEngine.UI.Image>().sprite = GetSpriteForItem(inventory[i]);
            }
            else
            {
                slots[i].SetActive(false);
                imageSlots[i].GetComponent<UnityEngine.UI.Image>().sprite = null;
            }
        }
    }

    private Sprite GetSpriteForItem(Item item)
    {
        switch (item)
        {
            case Item.DOG_BONE: return dogBoneSprite;
            case Item.TRUFFLE: return truffleSprite;
            case Item.RUBY: return rubySprite;
            default: return null;
        }
    }
}
