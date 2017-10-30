using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class networkhandforlocal : NetworkBehaviour {

    // Use this for initialization
    public Camera cm;
	void Start () {
        
        if (isLocalPlayer)
        {
            print("this is local");
            this.GetComponent<SpaceShip_Move>().enabled = true;
            this.GetComponent<Orbit_Adder>().enabled = true;
            cm.enabled = true;
        }
        else {
            this.GetComponent<Orbit_Adder>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
