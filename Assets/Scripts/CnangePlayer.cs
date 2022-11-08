using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CnangePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMove _firstPlayer;
    [SerializeField] private PlayerMove _secondPlayer;

    private void Start() 
    {
        _firstPlayer.GetComponent<PlayerMove>();        
        _secondPlayer.GetComponent<PlayerMove>();    

        _firstPlayer.enabled = false;
        _secondPlayer.enabled = false;
    }

    public void FirstPlayerActive()
    {
        _firstPlayer.enabled = true;
        _secondPlayer.enabled = false;
    }

    public void SecondPlayerActive()
    {
        _firstPlayer.enabled = false;
        _secondPlayer.enabled = true;
    }
}