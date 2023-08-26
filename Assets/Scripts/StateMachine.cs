using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
   public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    //chave
    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currentState;
    public Player player;
    public float timetoStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;
        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);
    }

    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();
        _currentState = dictionaryState[state];
        //_currentState.OnStateEnter(player);
        if (_currentState != null) _currentState.OnStateEnter();


    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
    
}
