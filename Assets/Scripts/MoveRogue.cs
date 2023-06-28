using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRogue : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanteVisible;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
    private Animator _animator;
    private static MoveRogue s_Instance;
    public static MoveRogue Instance
    {
        get
        {
            return s_Instance;
        }
    }

    private void Update()
    {
        _animator = GetComponent<Animator>();
        var collisionCount = _rigidbody2D.Cast(transform.right, _filter, _results, _distanteVisible);

        if (collisionCount == 0)
        {
            _rigidbody2D.velocity = transform.right * _speed;
            _animator.SetBool("isWalk", true);
        }
        else if (collisionCount > 0)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool("isWalk", false);
        }
    }
}
