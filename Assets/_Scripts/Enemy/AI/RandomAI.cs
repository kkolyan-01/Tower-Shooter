using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : IEnemyAI
{
    private Enemy _enemy;
    private Vector3 _movePoint;
    public RandomAI(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.agent.isStopped = false;
        _movePoint = CreateRandomPoint();
    }

    public void Move()
    {
        if (!_enemy.agent.hasPath)
            _movePoint = CreateRandomPoint();
        _enemy.MoveToPoint(_movePoint);
    }

    private Vector3 CreateRandomPoint()
    {
        Vector3 point = Random.onUnitSphere * 5;
        Debug.Log(point);
        return point;
    }
}
