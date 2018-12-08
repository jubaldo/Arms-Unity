using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour {

    GameObject lockedEnemy;
    public int damageAmount = 15;
    float delay = 1f;
    int Shoot = 0;
    
    void ResetEnemy()
    {
        lockedEnemy = null;
    }

    void LookAtPlayer(GameObject player)
    {
        Vector3 cpy = player.transform.position;
        cpy.y = transform.position.y;
        transform.LookAt(cpy);
    }
    void FirePlayer(GameObject player)
    {
        RaycastHit Shot;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            Shot.transform.SendMessage("DeductHealth", damageAmount, SendMessageOptions.DontRequireReceiver);
    
        }

    }

    IEnumerator StartFire(GameObject player)
    {
        Shoot = 1;
        LookAtPlayer(player);
        FirePlayer(player);
        yield return new WaitForSeconds(delay);//wait for a bit
        Shoot = 0;

    }

    void LockFire(ref List<GameObject> Enemies)
    {
        if (lockedEnemy != null)//follow locked enemy over time
        {
            transform.SendMessage("FollowPlayer", lockedEnemy, SendMessageOptions.DontRequireReceiver);
        }
      

        if (Shoot==0 && Enemies.Count != 0)
        {
            //find closest enemy and fire
            //check if we locked into an enemy
            if (lockedEnemy != null)
            {
                StartCoroutine(StartFire(lockedEnemy));
            }
            else
            {
                float distance = Vector3.Distance(transform.position, Enemies[0].transform.position);
                GameObject closestEnemy = Enemies[0];

                foreach (GameObject enemy in Enemies)
                {
                    float tempDist = Vector3.Distance(transform.position, enemy.transform.position);
                    if (tempDist < distance)
                    {
                        distance = tempDist;
                        closestEnemy = enemy;
                    }
           
                }
                //locked an enemy and set locked enemy
                //kill enemy
                lockedEnemy = closestEnemy;
                StartCoroutine(StartFire(closestEnemy));
            }

        }
  
    
    }

   
}
