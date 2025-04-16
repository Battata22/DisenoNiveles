using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _xAxis, _zAxis;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] CharacterController _cc;
    private void Start()
    {
        //_rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Gravedad();

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

        _cc.Move(dir * Time.fixedDeltaTime * _speed);

        //_rb.position += (dir * Time.fixedDeltaTime * _speed);
    }

    void Gravedad()
    {
        _cc.Move(-transform.up * 9.8f);
    }
}
