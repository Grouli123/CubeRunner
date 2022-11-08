using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
   //private PlayerMove _playerMove;
    private void Start() 
    {
     //  _playerMove.GetComponent<PlayerMove>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(gameObject.GetComponent<PlayerMove>())
        {
            Debug.Log("1");
        }    
    }
}
