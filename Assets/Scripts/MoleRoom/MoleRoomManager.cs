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

      [Header("Objects to place items on")]

      public GameObject itemPlaceableSlot1;
      public GameObject itemPlaceableSlot2;
      public GameObject itemPlaceableSlot3;


      private List<Item> inventory = StaticManager.inventory;

      void Start()
      {   
          // First time entering the room1
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

          if (Room3StoneWall != null) {
            Room3StoneWall.SetActive(true);
          }

          itemPlaceableSlot1.SetActive(false);
          itemPlaceableSlot2.SetActive(false);
          itemPlaceableSlot3.SetActive(false);
      }

      void Update()
      {
        // Debugging: Press Q, W, E, R to add items
        if (Input.GetKeyDown(KeyCode.Q)) {
          ToggleItem(Item.DOG_BONE);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
          ToggleItem(Item.TRUFFLE);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
          ToggleItem(Item.RUBY);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
          AddItem(Item.DOG_BONE);
          AddItem(Item.TRUFFLE);
          AddItem(Item.RUBY);
        }

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

        if (IsCorrectItemPlacement())
        {
          if (Room3StoneWall != null) {
            Room3StoneWall.SetActive(false);
          }
        }

        if (StaticManager.placedDogBone)
        {
          StaticManager.placedDogBone = false;
          StartCoroutine(PlaceItemNextFrame(Item.DOG_BONE));
        }

        if (StaticManager.placedTruffle)
        {
          StaticManager.placedTruffle = false;
          StartCoroutine(PlaceItemNextFrame(Item.TRUFFLE));
        }

        if (StaticManager.placedRuby)
        {
          StaticManager.placedRuby = false;
          StartCoroutine(PlaceItemNextFrame(Item.RUBY));
        }
      }

      public bool IsCorrectItemPlacement()
      {
          SpriteRenderer sr1 = itemPlaceableSlot1.GetComponent<SpriteRenderer>();
          SpriteRenderer sr2 = itemPlaceableSlot2.GetComponent<SpriteRenderer>();
          SpriteRenderer sr3 = itemPlaceableSlot3.GetComponent<SpriteRenderer>();

          bool table1Correct = itemPlaceableSlot1.activeSelf && sr1.sprite == dogBoneSprite;
          bool table2Correct = itemPlaceableSlot2.activeSelf && sr2.sprite == truffleSprite;
          bool table3Correct = itemPlaceableSlot3.activeSelf && sr3.sprite == rubySprite;

          return table1Correct && table2Correct && table3Correct;
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

          switch (item)
          {
            case Item.DOG_BONE:
              PlaceItemOnTable(dogBoneSprite);
              break;
            case Item.TRUFFLE:
              PlaceItemOnTable(truffleSprite);
              break;
            case Item.RUBY:
              PlaceItemOnTable(rubySprite);
              break;
          }
      }

      private void PlaceItemOnTable(Sprite sprite)
      {
        Debug.Log($"Placing {sprite.ToString()} on table: {StaticManager.currentInteractingStoneTable}");
          switch (StaticManager.currentInteractingStoneTable) {
            case 1:
              itemPlaceableSlot1.SetActive(true);
              itemPlaceableSlot1.GetComponent<SpriteRenderer>().sprite = sprite;
              break;
            case 2:
              itemPlaceableSlot2.SetActive(true);
              itemPlaceableSlot2.GetComponent<SpriteRenderer>().sprite = sprite;
              break;
            case 3:
              itemPlaceableSlot3.SetActive(true);
              itemPlaceableSlot3.GetComponent<SpriteRenderer>().sprite = sprite;
              break;
            default:
              break;
          }
      }

      private System.Collections.IEnumerator PlaceItemNextFrame(Item item)
      {
          yield return null; // Wait for one frame
          RemoveItem(item);  // Now the inventory and UI are ready
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
