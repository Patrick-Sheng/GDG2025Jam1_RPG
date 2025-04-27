using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private string initialStateID;

    [Header("States")]
    [SerializeField] private DecisionState[] states;

    public DecisionState CurrentState { get; set; }

    public Transform Player {  get; set; }

    private void Start()
    {
        ChangeState(initialStateID);
    }

    private void Update()
    {
        CurrentState.ExecuteState(this);
    }
    public void ChangeState(string newStateID)
    {
        DecisionState state = GetState(newStateID);
        if (state == null) return;
        CurrentState = state;
    }

    private DecisionState GetState(string stateID)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].StateID == stateID)
            {
                return states[i];
            }
        }
        return null;
    }
}
