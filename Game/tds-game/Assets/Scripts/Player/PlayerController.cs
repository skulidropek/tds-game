using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    private Vector2 _mousePos;
    public float Speed { get; set; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _moveVelocity = _moveInput.normalized * Speed;

        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);

        Vector2 _lookDir = _mousePos - _rb.position;
        float _angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = _angle;
    }
}
