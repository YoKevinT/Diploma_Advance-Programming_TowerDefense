using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public int damage = 10;
    public float fireDelay = .5f;
    public float range = 5f;
    public int cost = 5;
    public int level = 1; // Covert to level -1 for array

    private float fireTimer = 0; // Elapsed time from last fire

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        // Increase the fireTimer
        fireTimer += Time.deltaTime;
        // If fireTimer > fireDelay
        if (fireTimer >= fireDelay)
        {
            // Detect Targets
            List<Transform> targets = DetectTargets();
            // Detect Targets
            Transform closestTarget = GetCloseTarget(targets);

            Aim(closestTarget);
            Fire(closestTarget);

            fireTimer = 0;
        }
    }

    public Transform GetCloseTarget(List<Transform> targets)
    {
        // Set float min to infinity
        float min = float.MaxValue;
        // Set Transform closest to null
        Transform closest = null;
        // Loop through each target
        foreach (var target in targets)
        {
            // Get distance between target.position & current.position (tower)
            float distance = Vector3.Distance(target.position, transform.position);
            // If distance < min
            if (distance < min)
            {
                min = distance;
                closest = target;
            }
        }
        // return closest
        return closest;
    }

    protected List<Transform> DetectTargets()
    {
        List<Transform> result = new List<Transform>();
        // Perform on OverlapSphere Physics Detection
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        // Loop through all hits
        foreach (var hit in hits)
        {
            // If hit contain Enemy
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy)
            {
                // Add to Transform list
                result.Add(enemy.transform);
            }
        }
        // Return transform list
        return result;
    }

    // Fires and applies damage to a given target
    public virtual void Fire(Transform target)
    {

    }

    // Aims or rotate barrel to a given target
    public virtual void Aim(Transform target)
    {

    }
}