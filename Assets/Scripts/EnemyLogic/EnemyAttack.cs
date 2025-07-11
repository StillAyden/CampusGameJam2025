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

    private Color originalColor;

    void Start()
    {
        if (enemyRenderer == null)
            enemyRenderer = GetComponentInChildren<Renderer>();

        originalColor = enemyRenderer.material.color;
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
        // Add your player damage logic here
    }
}
