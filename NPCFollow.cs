using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//biblioteka potrzebna do ustawienia podazania za playerem

public class NPCFollow : MonoBehaviour
{
    //transform - pozycja - ktora NPC bedzie mial follow'owac
    public Transform transformToFollow;
    //NavMesh Agent
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //przypisujemy zmiennej agent element posiadajacy komponent nawmesh agent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Follow player
        agent.destination = transformToFollow.position;
    }
}
