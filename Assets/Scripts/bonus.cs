using UnityEngine;
using Scriptable;

public class bonus : MonoBehaviour
{
    // [SerializeField] private Text _coins;
    
    [SerializeField] private IntegerVariable _coinCounter;

    [SerializeField] private int _countCoin;

    private void Start()
    {
        _coinCounter.SetValue(0);
        // _coins.GetComponent<Text>();
    }

    // private void Update() 
    // {
    //     _coins.text = _countCoin.ToString();
    // }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("PlayerTwo") || other.gameObject.CompareTag("Player"))
        {
            _coinCounter.ApplyChange(_countCoin);
            // _countCoin += 1;
        }
    }
    
    // private void OnCollisionEnter(Collision other) {
    //      if (other.gameObject.CompareTag("Player"))
    //     {
    //         _coinCounter.ApplyChange(_countCoin);
    //         // _countCoin += 1;
    //     }
    // }
}
