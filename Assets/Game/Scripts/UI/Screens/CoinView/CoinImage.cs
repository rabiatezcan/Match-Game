using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImage : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _middlePos;
    private Vector3 _targetPos;
    private float _time;
    private bool _canMove;

    [SerializeField] private List<GameObject> _objs;
    public void SetActive()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        _canMove = false;
        gameObject.SetActive(false);
    }

    public void SetMovePosition(Vector3 newPos)
    {
        SetActive();

        _targetPos = newPos;
        _time = 0f;
        _canMove = true;
        _startPos = transform.position;
        _middlePos = _startPos + (Vector3.left * 2f);

        _objs[0].transform.position = _startPos;
        _objs[1].transform.position = _middlePos;
        _objs[2].transform.position = _targetPos;
    }

    private void MoveToTargetPosition()
    {
        //_startPos = transform.position;
        //_middlePos = _startPos + (Vector3.left * 5f) + (Vector3.up * 3f) ;
        //Vector3 startToMiddle = Vector3.Slerp(_startPos, _middlePos, Time.deltaTime);
        //Vector3 middletoEnd = Vector3.Slerp(_middlePos, _targetPos, Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, _targetPos, Time.deltaTime * 15f);


        if (Vector3.Distance(transform.position, _targetPos) < .2f)
        {
            ScoreSystem.AddScore(1);
            Hide();
        }
    }
    private void Update()
    {
        if (_canMove)
        {
            MoveToTargetPosition();
        }
    }
}
