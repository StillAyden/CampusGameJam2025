using UnityEngine;
using UnityEngine.AI; // If using NavMeshAgent

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float attackRange = 2f;
    private EnemyAttack enemyAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAttack = GetComponent<EnemyAttack>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            // Move toward the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // In range, start attack sequence
            if (!enemyAttack.isAttacking)
            {
                enemyAttack.StartAttack();
            }
        }
    }
}
