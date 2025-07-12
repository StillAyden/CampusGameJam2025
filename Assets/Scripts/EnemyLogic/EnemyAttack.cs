using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDamage = 10f;
    public bool isAttacking = false;
    public Renderer enemyRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.2f;
    public int flashCount = 3;
    public float attackRange = 2f;

    private Color originalColor;
    private Transform player; // Reference to player position
    public PlayerMovement playerMovement; // Reference to player script
    void Start()
    {
        if (enemyRenderer == null)
            enemyRenderer = GetComponentInChildren<Renderer>();

        originalColor = enemyRenderer.material.color;

        // Find player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerMovement = playerObj.GetComponent<PlayerMovement>();
        }
    }
  
    public void StartAttack()
    {
        if (!isAttacking)
        {
            StartCoroutine(FlashBeforeAttack());
        }
    }

    IEnumerator FlashBeforeAttack()
    {
        isAttacking = true;

        for (int i = 0; i < flashCount; i++)
        {
            // Flash red
            enemyRenderer.material.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            // Return to original color
            enemyRenderer.material.color = originalColor;

            // Wait until the next second
            float waitTime = 1f - flashDuration;
            yield return new WaitForSeconds(waitTime);
        }

        DealDamage();
        isAttacking = false;
    }

    void DealDamage()
    {
        Debug.Log("Enemy attacked the player for " + attackDamage + " damage.");
        if (player != null && playerMovement != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer >= attackRange)
            {
                Debug.Log("Enemy attacked the player for " + attackDamage + " damage.");
                playerMovement.LoseHealth(attackDamage);
            }
            else
            {
                Debug.Log("Player was out of range — attack missed.");
            }
        }
    }
}
