using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour {
    public static List<GameObject> EnemiestoFire = new List<GameObject>();
    public float MaxRange=15;
    

    bool CurrentlyFiring= false;
    // Use this for initialization
    void FireAway()
    {
        if (gameObject.tag == "Alpha")
        {
            foreach (GameObject bot in gameLog.Alpha)
            {
                bot.transform.SendMessage("LockFire", EnemiestoFire, SendMessageOptions.DontRequireReceiver);
              
            }
        }
        else if (gameObject.tag == "Beta")
        {
            foreach (GameObject bot in gameLog.Beta)
            {
                bot.transform.SendMessage("LockFire", EnemiestoFire, SendMessageOptions.DontRequireReceiver);
       
            }
        }
        
    }
    void FollowMe()
    {
        if (gameObject.tag == "Alpha")
        {
            foreach (GameObject bot in gameLog.Alpha)
            {
                bot.transform.SendMessage("FollowPlayer", gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
        else if (gameObject.tag == "Beta")
        {
            foreach (GameObject bot in gameLog.Beta)
            {
                bot.transform.SendMessage("FollowPlayer", gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }



    }
    void ResetAimBots()
    {
        if (gameObject.tag == "Alpha")
        {
            foreach (GameObject bot in gameLog.Alpha)
            {
                bot.transform.SendMessage("ResetEnemy", SendMessageOptions.DontRequireReceiver);
           
            }
        }
        else if (gameObject.tag == "Beta")
        {
            foreach (GameObject bot in gameLog.Beta)
            {
                bot.transform.SendMessage("ResetEnemy", SendMessageOptions.DontRequireReceiver);
       
            }
        }
       
    }
    void UnMarkEnemies()
    {
        foreach(GameObject enemy in EnemiestoFire)
        {
            enemy.SendMessage("UnMark", SendMessageOptions.DontRequireReceiver);
        }
    }
    void LockOnEnemies()//gets called repeatedly
    {
        float distance = 0f;
        if (Input.GetButton("Fire1"))//Hold Right click always takes us here
        {
            if (!CurrentlyFiring)
            {
                RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))//shoot raycast and continue if we hit something
                {
                    distance = Shot.distance;
                    if (Shot.distance <= MaxRange)
                    {
                        if (Shot.transform.gameObject.tag == "Alpha" || Shot.transform.gameObject.tag == "Beta")//check if gameobject we hit is a player object
                        {
                            if (Shot.transform.gameObject.tag != gameObject.tag)//Not in the same team
                            {
                                //add to enemies to be fired list
                                if (!EnemiestoFire.Contains(Shot.transform.gameObject))
                                {
                                    Shot.transform.SendMessage("Mark", SendMessageOptions.DontRequireReceiver);//mark dat target
                                    EnemiestoFire.Add(Shot.transform.gameObject);//make sure same enemy aint on list
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                //reset bots
                ResetAimBots();
                //unmark enemies
                UnMarkEnemies();
                //clear list
                EnemiestoFire.Clear();
                //we are no longer firing for now
                CurrentlyFiring = false;
            }

        }
        else//let go of rightclick go here
        {
            CurrentlyFiring = true;
            //shoot enemies i held right click to
            FireAway();
        }
    }
 

  
    void Update()
    {
        LockOnEnemies();
    }
}
