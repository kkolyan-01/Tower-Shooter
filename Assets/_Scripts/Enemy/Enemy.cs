using System;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Rigidbody[] _rigidbodies;
    private Animator _animator;
    private NavMeshAgent _agent;
    private IEnemyAI _enemyAi;
    
    
    public Transform target { get; set; }
    public NavMeshAgent agent => _agent;

    private void Start()
    {
        InitializeComponents();
        DisableRagdoll();
    }

    private void InitializeComponents()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponentInChildren<NavMeshAgent>();
        _enemyAi = new OffEnemyAi(this);
        target = _player;  
    }
    
    private void Update()
    {
        float velocity = Vector3.Magnitude(agent.velocity);
        _animator.SetFloat("Velocity", velocity);
        _enemyAi.Move();
    }

    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void Die()
    {
        Destroy(_animator);
        Destroy(_agent);
        Destroy(this);
        EnableRagdoll();   
    }

    private void EnableRagdoll()
    {
        _animator.enabled = false;
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void SetAI(EnemyAI AI)
    {
        _enemyAi = EnemyAIFactory.Create(AI, this);
    }
    
    public void SetAI(int IndexAI)
    {
       _enemyAi = EnemyAIFactory.Create((EnemyAI)IndexAI, this);
    }


}
