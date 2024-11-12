using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public enum AIState { Patrol, Chase, Attack, Flee }

    public AIState currentState = AIState.Patrol;
    public Transform player;
    public NavMeshAgent agent;
    public HealthBar healthBar;

    public float maxHealth = 50f;                
    public float health;
    public float chaseDistance = 10f;            
    public float attackDistance = 2f;            
    public float fleeHealthThreshold = 10f;     
    public Transform[] waypoints;               
    public GameObject projectilePrefab;         
    public Transform firePoint;                  
    public float attackCooldown = 2f;

    private int currentWaypoint = 0;
    private float attackTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);  
        GoToNextWaypoint();
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        
        switch (currentState)
        {
            case AIState.Patrol:
                Patrol();
                if (distanceToPlayer <= chaseDistance)
                {
                    currentState = AIState.Chase;  
                }
                break;

            case AIState.Chase:
                Chase();
                if (distanceToPlayer <= attackDistance)
                {
                    currentState = AIState.Attack;  
                }
                else if (distanceToPlayer > chaseDistance)
                {
                    currentState = AIState.Patrol;  
                }
                break;

            case AIState.Attack:
                Attack();
                if (distanceToPlayer > attackDistance)
                {
                    currentState = AIState.Chase;  
                }
                if (health <= fleeHealthThreshold)
                {
                    currentState = AIState.Flee;  
                }
                break;

            case AIState.Flee:
                Flee();
                if (distanceToPlayer > chaseDistance)
                {
                    currentState = AIState.Patrol;  
                }
                break;
        }
    }

    private void Patrol()
    {
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;
        agent.destination = waypoints[currentWaypoint].position;
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }

    private void Chase()
    {
        
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        
        if (attackTimer <= 0f)
        {
            FireProjectile();
            attackTimer = attackCooldown;
        }
    }

    private void FireProjectile()
    {
        
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    private void Flee()
    {
        
        Vector3 fleeDirection = transform.position - player.position;
        agent.SetDestination(transform.position + fleeDirection.normalized * 10f);
    }

    public void TakeDamage()
    {
        float damage = 5f;  
        health -= damage;
        healthBar.SetHealth(health);  
        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
