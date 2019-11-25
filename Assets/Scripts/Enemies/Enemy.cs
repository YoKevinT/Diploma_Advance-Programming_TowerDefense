﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 100;
    public float speed = 10f;

    protected List<Transform> DetectObstacles()
    {

        return new List<Transform>(); // Temporary
    }

    // Attacks and deals damage to a given target
    public virtual void Attack(Transform target)
    {

    }

    // Actions to perform upon death (if any)
    public virtual void Death()
    {

    }

    // Reduce health with given damage
    public void TakeDamage(int damage)
    {
        // Reduce health by damage
        health -= damage;
        // If health <= 0
        if (health <= 0)
        {
            // Died
            Death();
        }
    }
}