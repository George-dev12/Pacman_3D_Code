using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public float lastAttack = 0f, attackSpeed = 1.0f;
    public bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player != null) inRangeCheck();
        if (inRange) attack();
    }

    private void inRangeCheck() 
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 2)
        {
            inRange = true;
        }
        else inRange = false;
    }

    private void attack() 
    {
        if (Time.fixedTime - lastAttack > attackSpeed) // sprawdzamy, czy czas od ostatniego uderzenia jest odpowiedni
        {
            if (player != null) // zabezpieczenie, aby nie uderzalo jesli juz nie zyjemy
            player.GetComponent<Health>().GetDamage();
            lastAttack = Time.fixedTime;
        }
    }
}
