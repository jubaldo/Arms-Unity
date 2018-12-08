using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCover : MonoBehaviour {
    //incomplete
    public float coverDistance = 10f;
    public float slideSpeed = 0.07f;
    GameObject CoverObject;
	// Use this for initialization
    void Uncover(GameObject pop)
    {

    }
	void InstaCover(GameObject hide) {
      
		
	}
	
	// Update is called once per frame
	bool IsCover(GameObject potentialCover) {
        if (potentialCover.tag == "Hedge")
        {
            return true;
        }
        return false;
    }

      

    
}
