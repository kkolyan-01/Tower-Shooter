using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private Animator _animator;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
        }

        _animator = GetComponentInChildren<Animator>();
    }

    public void EnableRagdoll()
    {
        _animator.enabled = false;
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
