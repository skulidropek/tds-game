using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    private Vector2 _mousePos;

    private void Update()
    {
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _mousePos;
    }
}
