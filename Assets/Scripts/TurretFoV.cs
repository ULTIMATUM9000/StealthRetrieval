using System;
using System.Collections;
using UnityEngine;

public class TurretFoV:FieldOfView
{
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
                    //Interactable code here
                    FindObjectOfType<PlayerController>().isCaught = true;
                }
            }
        }
    }
}
