using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float walkingSpeed= 0.03f;
    public float runningSpeed = 0.07f;
    public float idleDistance = 3f;
    public float walkDistance = 6f;


    private void FollowPlayer(GameObject player)
    {
        float speed = 0f;//default remain idle
        float distance=  Vector3.Distance(player.transform.position, transform.position);
        if(idleDistance< distance && distance<= walkDistance)//walk
        {
            speed = walkingSpeed;
        }
        else if(distance> walkDistance)//run
        {
            speed = runningSpeed;
        }
        else//remainIdle
        {
            speed = 0f;
            //add idle animations
        }
        Vector3 cpy = player.transform.position;
        cpy.y = transform.position.y; 

        transform.position = Vector3.MoveTowards(transform.position, cpy, speed);
        transform.LookAt(cpy);

    }



}
