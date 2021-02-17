using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffEnemyAi : IEnemyAI
{
    private Enemy _enemy;
    public OffEnemyAi(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.agent.isStopped = true;
    }
    public void Move() { }
}