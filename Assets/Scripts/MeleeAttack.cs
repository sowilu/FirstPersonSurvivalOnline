using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("Attack Settings")] 
    public float damage = 25;
    public float range = 5;
    public float radius = 2.6f;
    public float attackCooldown = 0.5f;
    public LayerMask hitLayer;
    
    [Header("References")]
    public Transform targetPoint; //usually weapon or camera
    
    private bool canAttack = true;
    
    void Start()
    {
        if (targetPoint == null)
        {
            targetPoint = Camera.main.transform;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        
        var hits = Physics.OverlapSphere(targetPoint.position, radius, hitLayer);
        foreach (var hit in hits)
        {
            var directionToTarget = (hit.transform.position - targetPoint.position).normalized;

            if (Vector3.Dot(directionToTarget, targetPoint.forward) > 0.5f)
            {
                var distanceToTarget = Vector3.Distance(targetPoint.position, hit.transform.position);
                if (distanceToTarget <= range)
                {
                    //TODO: deal damage
                    Destroy(hit.gameObject);
                }
            }
        }
        
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        if (targetPoint == null) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetPoint.position, radius);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(targetPoint.position, targetPoint.position + targetPoint.forward * range);
    }
}
