using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAI
{
    off,
    chase,
    random,
}
public class EnemyAIFactory : MonoBehaviour
{
    public static IEnemyAI Create(EnemyAI AI, Enemy enemy)
    {
        switch (AI)
        {
            case EnemyAI.off:
                return new OffEnemyAi(enemy);
            case EnemyAI.chase:
                return new ChaseEnemyAi(enemy);
            case EnemyAI.random:
                return new RandomAI(enemy);
        }

        return null;
    }
}
