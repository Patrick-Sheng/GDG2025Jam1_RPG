using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    // to allow Unity to show this data in the editor (e.g. states)
    [System.Serializable]

    public class State {

        // maps to the image and outline colours of the tiles in unity
        public Color fillColor;
        public Color outlineColor;
    }

    public State state {get; private set;}
    // public getter, private setter
    public char letter {get; private set;}


    private TextMeshProUGUI text;
    private Image fill;
    private Outline outline;


    // function unity calls automatically when script is first initalised
    private void Awake() {
        text = GetComponentInChildren<TextMeshProUGUI>();
        fill = GetComponent<Image>();
        outline = GetComponent<Outline>();
    }

    public void SetLetter(char letter) {

        this.letter = letter;
        text.text = letter.ToString();
    }


    public void SetState(State state) {
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;
    }
}
