using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSettings _settings;
    
    private Weapon _weapon;
    private Animator _animator;
    private PlayerState _state;
    private NavMeshAgent _agent;

    public Weapon weapon => _weapon;
    public Animator animator => _animator;
    public PlayerSettings settings => _settings;
    public Vector3 velocity
    {
        get => _agent.velocity;
        set => _agent.velocity = value;
    }
    
    public float speed
    {
        get => _agent.speed;
        set => _agent.speed = value;
    }

    private void Start()
    {
        _state = new IdleState(this);
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        _state.Execute();
    }
    
    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void RotateToPoint(Vector3 point)
    {
        transform.LookAt(point);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);   
    }
    

    public void SetShooterState()
    {
        _state = new ShooterState(this, _weapon);
    }

    public void SetState(PlayerState state)
    {
        _state = state;
    }
    
}
