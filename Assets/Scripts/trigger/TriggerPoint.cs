using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public Player player;
    public string tagToCheck = "Ball"; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == tagToCheck)
        {
            Debug.Log("A Bola Tocou no trigger");
            CountPoint();
        }
    }

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
