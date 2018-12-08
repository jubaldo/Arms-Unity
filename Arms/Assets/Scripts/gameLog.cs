using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLog : MonoBehaviour {
    public static List<GameObject> Alpha = new List<GameObject>();
    public static List<GameObject> Beta = new List<GameObject>();

	// Use this for initialization
	public static void AddTeamList(GameObject unknown)
    {
        if (unknown.tag == "Alpha")
        {
            Alpha.Add(unknown);

        }
        else if(unknown.tag== "Beta")
        {
            Beta.Add(unknown);

        }
    }
    public static void RemoveTeamList(GameObject unknown)
    {
        if(unknown.tag== "Alpha")
        {
            Alpha.Remove(unknown);
        }
        else if(unknown.tag=="Beta")
        {
            Beta.Remove(unknown);
        }
    }
	
	
}
