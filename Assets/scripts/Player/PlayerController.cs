﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float sideSpeed;

    public GameObject Bullet;
    public Transform firePoint;
    public float bulletSpeed = 60f;

    public static float maxHealth = 80f;
    public static int maxLives = 3;
    public static float currentHealth = maxHealth;
    public static int currentLives = maxLives;
    public HealthBar healthBar;
    public LifeDots lifeDots;

    private Rigidbody rb;
    private PersistentManager Manager;
    private float timeToNextFire = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Manager = GameObject.FindWithTag("PersistentManager").GetComponent<PersistentManager>();
    }

    {
        else if (Input.GetKey("c")) { rb.velocity = -transform.forward * sideSpeed;}
        else if (Input.GetKey("w")) { rb.velocity = transform.up * sideSpeed;}
        else if (Input.GetKey("s")) { rb.velocity = -transform.up * sideSpeed;}
        else if (Input.GetKey("a")) { rb.velocity = -transform.right * sideSpeed;}
        else if (Input.GetKey("d")) { rb.velocity = transform.right * sideSpeed;}

        if (Input.GetKey(KeyCode.Return))

        if (Input.GetButton("Fire3") && Time.time >= timeToNextFire)
        {
            timeToNextFire = Time.time + 1 / fireRate;
            Fire();
        }
    }

    void PartialDeath()

    void CompleteDeath()


    void Movement(Vector3 direction)
    {
        
    }



    void Fire()
}