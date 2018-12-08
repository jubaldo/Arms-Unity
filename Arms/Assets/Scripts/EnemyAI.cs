using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour {
    public GameObject marked;
    public int Health = 100;
    
    void Mark()
    {
        marked.SetActive(true);
    }
    void UnMark()
    {
        marked.SetActive(false);
    }
	void DeductHealth(int damage)
    {
        Health -= damage;
    }
    
	void Update () {
        if (Health <= 0)
        {
            Commands.EnemiestoFire.Remove(gameObject);
            Destroy(gameObject);
        }
	}
}
