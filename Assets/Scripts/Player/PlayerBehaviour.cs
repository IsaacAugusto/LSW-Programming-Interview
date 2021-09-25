using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static bool CanMove;

    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Animator _anim;

    private Vector2 _moveAxis;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveAxis();
        FlipCharacter();
        ControllAnimatorParams();
    }

    void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Read Input Axis and set on _moveAxis.
    /// </summary>
    private void GetMoveAxis()
    {
        _moveAxis.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    /// <summary>
    /// Apply movement on the player rigidbody using the moveAxis and speed
    /// </summary>
    private void Movement()
    {
        if (CanMove)
        {
            _rb.velocity = _moveAxis.normalized * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void FlipCharacter()
    {
        if (transform.rotation.eulerAngles.y == 0 && _moveAxis.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.rotation.eulerAngles.y != 0 && _moveAxis.x > 0)
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void ControllAnimatorParams()
    {
        _anim.SetFloat("Speed", _rb.velocity.magnitude);
    }
}
