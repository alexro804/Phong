using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public static GameManager Instance;
    public float timeToSetBallFree = 1f;
    public StateMachine stateMachine;
    public Player[] players;

    [Header("Menus")]

    public GameObject uiMenu;

    public void Awake()
    {
        Instance = this;

        players = FindObjectsOfType<Player>();
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    public void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
    }

    public void EndGame() 
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }

    public void ShowMenu()
    {
        uiMenu.SetActive(true);
        ballBase.CanMove(false);
    }
}
