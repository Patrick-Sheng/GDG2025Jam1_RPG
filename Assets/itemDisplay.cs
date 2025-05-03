using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class itemDisplay : MonoBehaviour
{
  public Sprite sprite1;
  public Sprite sprite2;
  public Sprite sprite3;

  private UnityEngine.UI.Image image;

  void Start()
  {
    image = gameObject.GetComponent<UnityEngine.UI.Image>();

    image.enabled = false;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q)) {
      image.enabled = true;
      gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprite1;
    } else if (Input.GetKeyDown(KeyCode.W)) {
      gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprite2;
    } else if (Input.GetKeyDown(KeyCode.E)) {
      gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprite3;
    }
    

    

  }



}
