using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private FixedJoystick _joystickLeft;
    [SerializeField] private FixedJoystick _joystickRight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _camera;

    private void Move()
    {
        _playerRB.velocity = _playerRB.rotation * new Vector3(_joystickLeft.Vertical * _moveSpeed, _playerRB.velocity.y, -_joystickLeft.Horizontal * _moveSpeed);
    }
    private void FixedUpdate()
    {
        Move();
        RotationPlayer();
        RotationCamera();
    }
    private void RotationPlayer()
    {
        Vector3 moveVector = (Vector3.up * _joystickRight.Horizontal);
        if (_joystickRight.Horizontal != 0)
        {
            transform.eulerAngles += Vector3.up * Mathf.Atan(_joystickRight.Horizontal) * Mathf.Rad2Deg * _rotationSpeed * Time.deltaTime;
        }
    }
    private void RotationCamera()
    {
        Vector3 moveVector = (Vector3.up * _joystickRight.Horizontal + Vector3.left * _joystickRight.Vertical);
        if (_joystickRight.Vertical != 0)
        {
            _camera.transform.eulerAngles += Vector3.right * Mathf.Atan(-_joystickRight.Vertical) * Mathf.Rad2Deg * _rotationSpeed * Time.deltaTime;
        }
    }
}
