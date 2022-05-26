using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagment : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    public void BeginLevel()
    {
        GameManager.instance.LevelStarted = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject == player)
        {
            //Debug.Log("Collided " + collision.gameObject.name);
            WinLevel();
        }
    }

    public void WinLevel()
    {
        GameManager.instance.WinGame = true;
        GameManager.instance.GamePlaying = false;
    }
}
