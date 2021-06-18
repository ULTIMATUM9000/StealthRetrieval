using System.Collections;
using UnityEngine;
public class GuardFoV:FieldOfView
{
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    protected override void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle/2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    //code to chase player here
                    StartCoroutine(ChasePlayer(5.0f));
                }
            }
        }
    }

    IEnumerator ChasePlayer(float delay)
    {
        _enemyMovement.currentTarget = _enemyMovement.player;
        yield return new WaitForSeconds(delay);
        _enemyMovement.SetTargetWaypoint();
    }
}
