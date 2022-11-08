using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _startBackground;
    [SerializeField] private DrawPath _firstPlayer;

    private void Start()
    {
        _firstPlayer.GetComponent<DrawPath>();
        _startBackground.SetActive(true);
        _firstPlayer.enabled = false;
    }

    public void StartNewGame()
    {
        _startBackground.SetActive(false);
        _firstPlayer.enabled = true;
    }
}