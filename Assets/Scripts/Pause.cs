using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

   public void PauseGame()
   {
    if (_isPaused == false)
    {
        Time.timeScale = 0;
        _isPaused = true;

    }
    else
    {
        Time.timeScale = 1;
        _isPaused = false;
    }
   }
}
