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

      public GameObject StoneTableNPC1;
      public GameObject StoneTableNPC2;
      public GameObject StoneTableNPC3;


      private List<ItemEnum> inventory = StaticManager.inventory;

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

          if (itemPlaceableSlot1 != null) {
            if (StaticManager.placedDogBoneOnTable) {
              itemPlaceableSlot1.SetActive(true);
              itemPlaceableSlot1.GetComponent<SpriteRenderer>().sprite = dogBoneSprite;
              StoneTableNPC1.SetActive(false);
            }
          }
          if (itemPlaceableSlot2 != null) {
            if (StaticManager.placedTruffleOnTable) {
              itemPlaceableSlot2.SetActive(true);
              itemPlaceableSlot2.GetComponent<SpriteRenderer>().sprite = truffleSprite;
              StoneTableNPC2.SetActive(false);
            }
          }
          if (itemPlaceableSlot3 != null) {
            if (StaticManager.placedRubyOnTable) {
              itemPlaceableSlot3.SetActive(true);
              itemPlaceableSlot3.GetComponent<SpriteRenderer>().sprite = rubySprite;
              StoneTableNPC3.SetActive(false);
            }
          }
      }

      void Update()
      {

        if (IsCorrectItemPlacement())
        {
            StaticManager.PlacedAll = true;
        }
        // MoleRoom1 items 
        if (StaticManager.pushTimes >= 3) {
          StaticManager.wallCracked = true;
        }

        // MoleRoom1 and MoleRoom3 uses the following statements
        if (StaticManager.pickedUpBone) {
          StaticManager.pickedUpBone = false;
          StaticManager.firstTime_pickedUpBone = true;
          if (DogBone != null) {
            DogBone.SetActive(false);
          }
          ToggleItem(ItemEnum.DOG_BONE);
        }
        if (StaticManager.pickedUpTruffle) {
          StaticManager.pickedUpTruffle = false;
          StaticManager.firstTime_pickedUpTruffle = true;
          if (Truffle != null) {
            Truffle.SetActive(false);
          }
          ToggleItem(ItemEnum.TRUFFLE);
        }
        if (StaticManager.pickedUpRuby) {
          StaticManager.pickedUpRuby = false;
          StaticManager.firstTime_pickedUpRuby = true;
          if (Ruby != null) {

            Ruby.SetActive(false);
          }
          ToggleItem(ItemEnum.RUBY);
        }

        // MoleRoom2 condition to pass the level
        if (StaticManager.completedPressurePlatePuzzle) {
          if (Room2StoneWall != null) {
            Room2StoneWall.SetActive(false);
          }
        }

        // MoleRoom3 condition to pass the level
        if (IsCorrectItemPlacement())
        {
          if (Room3StoneWall != null) {
            Room3StoneWall.SetActive(false);
          }
        }

        if (StaticManager.placedDogBone)
        {
          StaticManager.placedDogBone = false;
          StartCoroutine(PlaceItemNextFrame(ItemEnum.DOG_BONE));
        }

        if (StaticManager.placedTruffle)
        {
          StaticManager.placedTruffle = false;
          StartCoroutine(PlaceItemNextFrame(ItemEnum.TRUFFLE));
        }

        if (StaticManager.placedRuby)
        {
          StaticManager.placedRuby = false;
          StartCoroutine(PlaceItemNextFrame(ItemEnum.RUBY));
        }
      }

      public bool IsCorrectItemPlacement()
      {
        if (itemPlaceableSlot1 == null || itemPlaceableSlot2 == null || itemPlaceableSlot3 == null) {
          return false; // Safety check
        }
          
        SpriteRenderer sr1 = itemPlaceableSlot1.GetComponent<SpriteRenderer>();
        SpriteRenderer sr2 = itemPlaceableSlot2.GetComponent<SpriteRenderer>();
        SpriteRenderer sr3 = itemPlaceableSlot3.GetComponent<SpriteRenderer>();

        bool table1Correct = itemPlaceableSlot1.activeSelf && sr1.sprite == dogBoneSprite;
        bool table2Correct = itemPlaceableSlot2.activeSelf && sr2.sprite == truffleSprite;
        bool table3Correct = itemPlaceableSlot3.activeSelf && sr3.sprite == rubySprite;

        return table1Correct && table2Correct && table3Correct;
      }

      private void ToggleItem(ItemEnum item)
      {
          if (inventory.Contains(item))
              RemoveItem(item);
          else
              AddItem(item);
      }

      private void AddItem(ItemEnum item)
      {
          if (inventory.Count >= slots.Length)
          {
              Debug.LogWarning("Inventory full!");
              return;
          }

          inventory.Add(item);
          UpdateUI();
      }

      private void RemoveItem(ItemEnum item)
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
            case ItemEnum.DOG_BONE:
              PlaceItemOnTable(dogBoneSprite);
              break;
            case ItemEnum.TRUFFLE:
              PlaceItemOnTable(truffleSprite);
              break;
            case ItemEnum.RUBY:
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
              StoneTableNPC1.SetActive(false);
              StaticManager.placedDogBoneOnTable = true;
              break;
            case 2:
              itemPlaceableSlot2.SetActive(true);
              itemPlaceableSlot2.GetComponent<SpriteRenderer>().sprite = sprite;
              StoneTableNPC2.SetActive(false);
              StaticManager.placedTruffleOnTable = true;
              break;
            case 3:
              itemPlaceableSlot3.SetActive(true);
              itemPlaceableSlot3.GetComponent<SpriteRenderer>().sprite = sprite;
              StoneTableNPC3.SetActive(false);
              StaticManager.placedRubyOnTable = true;
              break;
            default:
              break;
          }
      }

      private System.Collections.IEnumerator PlaceItemNextFrame(ItemEnum item)
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

      private Sprite GetSpriteForItem(ItemEnum item)
      {
          switch (item)
          {
              case ItemEnum.DOG_BONE: return dogBoneSprite;
              case ItemEnum.TRUFFLE: return truffleSprite;
              case ItemEnum.RUBY: return rubySprite;
              default: return null;
          }
      }
  }
