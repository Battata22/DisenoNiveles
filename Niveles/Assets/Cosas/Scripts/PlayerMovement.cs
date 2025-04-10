using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _xAxis, _zAxis;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (_xAxis != 0 || _zAxis != 0)
        {
            Movement();
        }
    }

    void Movement()
    { 
        Vector3 dir = (transform.right * _xAxis + transform.forward * _zAxis).normalized;
        _rb.position += (dir * Time.fixedDeltaTime * _speed);
    }


}
