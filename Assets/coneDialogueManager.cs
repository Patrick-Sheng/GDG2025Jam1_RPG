using UnityEngine;
using Ink.Runtime;     

public class ConeManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public GameObject Moneycanvas;



    public bool canLickCone = false;

    private Story _boundStory;
    private void Update()
    {
        canLickCone = StaticManager.CanLick;






    }
    //void LateUpdate()     
    //{
  
    //    if (_boundStory != null) return;

       
    //    var dm = DialogueManager.GetInstance();
    //    if (dm == null || dm.currentStory == null) return;

    //    // Bind the function on that very Story
    //    dm.currentStory.BindExternalFunction(
    //        "canlickcone",
    //        () => canLickCone
    //    );

    //    _boundStory = dm.currentStory;   
    //}
}

