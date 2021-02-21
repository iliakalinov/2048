using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderEndGame : MonoBehaviour
{
    public Action<bool> endGame;
    public void SetCallback(Action<bool> action)
    {
        endGame = action;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("EndGame");
            endGame?.Invoke(true);
        }
    }

}

