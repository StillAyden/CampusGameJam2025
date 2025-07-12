using UnityEngine;

public class PlayerAttackEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Collider _swordCollider;
    public bool _canAttack = false;
    public float _attackDamage;
    void Start()
    {
        _swordCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void timeToAttack(float attackDamage)
    {
        _canAttack = true;
        _swordCollider.enabled = true;
        _attackDamage = attackDamage;
        Debug.Log("Time To Attack!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (_canAttack && other.CompareTag("Enemy"))
        {
            Debug.Log("Hit " + other.name+"!");
            // Optional: Damage enemy
            other.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);
            _canAttack = false;
            _swordCollider.enabled = false;
        }
    }
}
