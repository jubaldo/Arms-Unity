using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {
    public GameObject Prompt;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("CommandMenu"))
        {
            Prompt.SetActive(false);
        }
        else
        {
            Prompt.SetActive(true);
        }
	}
}
