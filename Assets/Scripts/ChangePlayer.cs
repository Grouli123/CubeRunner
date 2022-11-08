using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] private DrawPath _firstPlayer;
    [SerializeField] private DrawPath _secondPlayer;

    [SerializeField] private GameObject _winPannel;
    
    private void Start()
    {
        _firstPlayer.GetComponent<DrawPath>();
        _secondPlayer.GetComponent<DrawPath>();
        _secondPlayer.enabled = false;
        _winPannel.SetActive(false);
    }

    private void Update() 
    {
        CheckObject();
    }

    private void CheckObject()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit : " + hitColliders[i].name + i);
                i++;

                _secondPlayer.enabled = true;
                _firstPlayer.enabled = false;
                
            }

            else if(hitColliders[i].gameObject.CompareTag("PlayerTwo"))
            {
                _winPannel.SetActive(true);
                _secondPlayer.enabled = false;
            }
            break;
        }
    }
}