using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed { get; set; }
    public float force { get; set; }
    public Vector3 direction { get; set; }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 tempPosition = transform.position;
        tempPosition += speed * direction * Time.deltaTime;
        transform.position = tempPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = FindEnemyScript(other.gameObject);
            if (enemy)
                enemy.EnableRagdoll();
        }

        Rigidbody otherRigidbody = other.transform.GetComponent<Rigidbody>();
        if (otherRigidbody)
            otherRigidbody.AddForce(direction * force);

        Destroy(gameObject);
    }

    private Enemy FindEnemyScript(GameObject enemyGO)
    {
        Transform enemyPart = enemyGO.transform;
        Enemy enemy = null;
        while (enemyPart != null)
        {
            enemy = enemyPart.GetComponent<Enemy>();
            if (enemy)
                break;
            
            enemyPart = enemyPart.parent;
        }

        return enemy;
    }
}