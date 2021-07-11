using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float triggerRadius;
    public float fireRate;
    public float health;

    private bool isSlain;
    private float timeToNextFire = 0f;
    private Vector3 terminalPos;

    void Start()
    {
        Manager = GameObject.FindWithTag("PersistentManager").GetComponent<PersistentManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
        isSlain = Manager.enemyBoolArr[serialNo];
        terminalPos = transform.position;

        if(isSlain)
    }

    void Update()
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer); // Map Vector3 direction to its corresponding rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed); // slerp smoothes the angle rotation

    public void TakeDamage(float amount)

    private void Die()

    private void SpawnTerminal()

    // Visualize the trigger sphere in editor
    void OnDrawGizmosSelected()

}