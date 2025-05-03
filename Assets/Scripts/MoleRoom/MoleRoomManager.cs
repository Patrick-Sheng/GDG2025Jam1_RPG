using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using System.Collections.Generic;

public class MoleRoomManager : MonoBehaviour
{
    [Header("Items")]
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

    [Header("StoneWalls")]
    public GameObject Room2StoneWall;

    public GameObject Room3StoneWall;

    private List<Item> inventory = StaticManager.inventory;

    void Start()
    {   
        // First time entering the room
        if (!StaticManager.moleRoom1Visited) {
          StaticManager.moleRoom1Visited = true;
          StaticManager.inventory.Clear();
        } else {
          if (StaticManager.firstTime_pickedUpBone && DogBone != null) {
            DogBone.SetActive(false);
          }
          if (StaticManager.firstTime_pickedUpTruffle && Truffle != null) {
            Truffle.SetActive(false);
          }
          if (StaticManager.firstTime_pickedUpRuby && Ruby != null) {
            Ruby.SetActive(false);
          }
        }
        // Initialize the inventory UI
        UpdateUI();

        // Initialize the items in the scene
        
        if (Room2StoneWall != null) {
          Room2StoneWall.SetActive(true);
        }
    }

    void Update()
    {
      if (StaticManager.pushTimes >= 3) {
        StaticManager.wallCracked = true;
      }
      if (StaticManager.pickedUpBone) {
        StaticManager.pickedUpBone = false;
        StaticManager.firstTime_pickedUpBone = true;
        if (DogBone != null) {
          DogBone.SetActive(false);
        }
        ToggleItem(Item.DOG_BONE);
      }
      if (StaticManager.pickedUpTruffle) {
        StaticManager.pickedUpTruffle = false;
        StaticManager.firstTime_pickedUpTruffle = true;
        if (Truffle != null) {
          Truffle.SetActive(false);
        }
        ToggleItem(Item.TRUFFLE);
      }
      if (StaticManager.pickedUpRuby) {
        StaticManager.pickedUpRuby = false;
        StaticManager.firstTime_pickedUpRuby = true;
        if (Ruby != null) {
          Ruby.SetActive(false);
        }
        ToggleItem(Item.RUBY);
      }
      if (StaticManager.completedPressurePlatePuzzle) {
        if (Room2StoneWall != null) {
          Room2StoneWall.SetActive(false);
        }
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
