﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NpcMovement : MonoBehaviour
{
    // stating the navemensh agent
    private NavMeshAgent navNpc;

    //speed of the Npc
    public float NpcSpeed = 2.0f;

    //waypoints
    public Transform[] waypoints;

    //current waypoint
    private int NpcCurrentWaypoint = 0;

    //max waypoints
    private int NpcMaxWaypoint;

    //the distance the npc has to go to the waypoint to move on
    public float NpcToWaypointDistance = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        //  get the nave Mesh agent 
        navNpc = GetComponent<NavMeshAgent>();

        // toatl waypoints eqauls to the number of waypoints minus one
        NpcMaxWaypoint = waypoints.Length - 1;


    }

    // Update is called once per frame
    void Update()
    {
        NpcMoving(); 
    }

    public void NpcMoving()
    {
        //Npc speed equal to the NpcSpeed
        navNpc.speed = NpcSpeed;

        // Create two Vector3 variables, one to buffer the ai agents local position, the other to
        // buffer the next waypoints position
        Vector3 tempLocalPosition;
        Vector3 tempWaypointPosition;

        // Agents position (x, set y to 0, z)
        tempLocalPosition = transform.position;
        tempLocalPosition.y = 0f;

        // Current waypoints position (x, set y to 0, z)
        tempWaypointPosition = waypoints[NpcCurrentWaypoint].position;
        tempWaypointPosition.y = 0f;

        // is the npc distance to the waypoint between 0.5f and 0
        if (Vector3.Distance(tempLocalPosition, tempWaypointPosition) <= NpcToWaypointDistance)
        {
            //if the NpcCurrentWaypoint is equal to the NpcMaxWaypoint
            if (NpcCurrentWaypoint == NpcMaxWaypoint)

                //start from the begeening
                NpcCurrentWaypoint = 0;

            else

                // or move to the next waypoint
                NpcCurrentWaypoint++;
        }
        navNpc.SetDestination(waypoints[NpcCurrentWaypoint].position);
    }
}
