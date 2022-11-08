using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _lastClickedPos;

    private bool _isMoving;

    private float _step;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isMoving = true;
        }

        if(_isMoving && (Vector2)transform.position != _lastClickedPos)
        {
            _step = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _lastClickedPos, _step);
        }
        else
        {
            _isMoving = false;
        }
    }
}