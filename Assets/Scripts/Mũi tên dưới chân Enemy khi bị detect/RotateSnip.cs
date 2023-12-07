using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSnip : MonoBehaviour
{
    public enum Direction
    {
        Left,Right
    }
    public Direction _direction;
    public bool isCheck;
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        if (!isCheck)
            return;
        if (_direction == Direction.Left)
        {
            transform.Rotate(new Vector3(0,0,1) * speed);
        }
        else
        {
            transform.Rotate(-new Vector3(0, 0, 1) * speed);
        }
        
    }
    private void OnEnable()
    {
        isCheck = true;
    }
    private void OnDisable()
    {
        isCheck = false;
        
    }
}
