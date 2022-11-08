using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _endBackground;    
    [SerializeField] private GameObject _startBackground;
    // [SerializeField] private DrawPath _secondPlayer;

    private void Start()
    {
        // _secondPlayer.GetComponent<DrawPath>();
        _endBackground.SetActive(false);
    }

    public void EndGame()
    {
        // // _secondPlayer.enabled = false;
        // _endBackground.SetActive(false);
        // _startBackground.SetActive(true);

        SceneManager.LoadScene(0);
    }
}