using UnityEngine;


public class AIController : MonoBehaviour
{
    public float attackRange = 5f;
    public Transform player;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float damage = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, attackRange))
            {
                if (hit.transform == player)
                {
                    AttackPlayer();
                }
            }
        }
    }

    void AttackPlayer(){
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        projectileController.SetDirection(player.position - transform.position);

        Destroy(projectile, 2f);  
    }

}