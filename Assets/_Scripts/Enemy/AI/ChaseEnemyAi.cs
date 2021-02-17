using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyAi : IEnemyAI
{
    private Enemy _enemy;
    private Transform _target;
    
    public ChaseEnemyAi(Enemy enemy)
    {
        _enemy = enemy;
        _target = _enemy.target;
        _enemy.agent.isStopped = false;
    }
    
    public void Move()
    {
        _enemy.MoveToPoint(_target.position);
    }
}
