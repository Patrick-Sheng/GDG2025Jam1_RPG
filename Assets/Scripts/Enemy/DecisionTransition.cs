using System;

[Serializable]
public class DecisionTransition
{
    public AbstractEnemyDecision Decision;
    public string TrueState;
    public string FalseState;
}