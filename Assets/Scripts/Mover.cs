using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanteVisible;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
    private Animator _animator;
    private string _walk = "isWalk";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        Animator.StringToHash(_walk);
    }

    private void Update()
    {
        var collisionCount = _rigidbody2D.Cast(transform.right, _filter, _results, _distanteVisible);

        if (collisionCount == 0)
        {
            _rigidbody2D.velocity = transform.right * _speed;
            _animator.SetBool(_walk, true);
        }
        else if (collisionCount > 0)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool(_walk, false);
        }
    }
}
