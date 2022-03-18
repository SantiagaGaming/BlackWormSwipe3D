using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    public enum Direction
    {
        Left, Right, Up, Down
    }
   private bool[] _swipe = new bool[4];
   private Vector2 _startTouch;
   private bool _touchMoved;
   private Vector2 _swipeDelta;
   private const float SWIPE_THRESHOLD = 50;

    Vector2 TouchPosition()
    { return (Vector2)Input.mousePosition; }
    bool TouchBegan()
    {
        return Input.GetMouseButtonDown(0);
    }
    bool TouchEnded()
    {
        return Input.GetMouseButtonUp(0);
    }
    bool GetTouch() { return Input.GetMouseButton(0); }

    private void Update()
    {
        if (TouchBegan())
        {
            _startTouch = TouchPosition();
            _touchMoved = true;
        }
        else if (TouchEnded() && _touchMoved == true)
        {
            SendSwipe();
            _touchMoved = false;
        }
        _swipeDelta = Vector2.zero;
        if (_touchMoved && GetTouch())
        {
            _swipeDelta = TouchPosition() - _startTouch;
        }
        if (_swipeDelta.magnitude > SWIPE_THRESHOLD)
        {
            if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
            {
                if (_swipe[(int)Direction.Left] = _swipeDelta.x < 0) { _playerMover.MoveLeft(); }


                else if (_swipe[(int)Direction.Right] = _swipeDelta.x > 0) { _playerMover.MoveRight(); }
            }
            else
            {
               if (_swipe[(int)Direction.Down] = _swipeDelta.y > 0) { _playerMover.MoveUp(); }
                _swipe[(int)Direction.Up] = _swipeDelta.y < 0;
            }
            SendSwipe();
        }
    }
    void SendSwipe()
    {
        if (_swipe[0] || _swipe[1] || _swipe[2] || _swipe[3])
        {
            Debug.Log(_swipe[0] + "|" + _swipe[1] + "|" + _swipe[2] + "|" + _swipe[3]);
        }
        else { Debug.Log("Click"); }
        Reset();
    }
    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _touchMoved = false;
        for (int i = 0; i < 4; i++)
        {
            _swipe[i] = false;
        }
    }

}
