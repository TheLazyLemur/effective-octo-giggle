using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverseer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseSystem.Instance.IsPaused())
        {
            PauseSystem.Instance.PauseGame();
        }
    }
}