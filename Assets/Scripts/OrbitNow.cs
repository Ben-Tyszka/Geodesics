using UnityEngine;
using System.Collections;

public class OrbitNow : MonoBehaviour {

    public GameObject point;
    Vector2 diff, direction;
    public bool EJECT = false;
    public GameObject previous_holder;
    void Start () {
	
	}
	void Update () {
        if (point != null) {
            diff = point.transform.position - this.transform.position;
            direction = diff.normalized;
            Rigidbody2D this_rgd = GetComponent<Rigidbody2D>();
            this_rgd.angularVelocity = 600.0f;
            float gravitationForce = (float)(1 * this_rgd.mass * 35) / diff.sqrMagnitude;
            this_rgd.AddForce(direction * gravitationForce);
            
            
        }
        if (EJECT) {
            point = null;
            this.transform.parent = null;
            Rigidbody2D this_rgd = GetComponent<Rigidbody2D>();
            this_rgd.AddForce(-direction * 2);
            EJECT = false;
            //print("Previous holder was: " + previous_holder.name);
        }
	}
    void setup() {
        this.transform.parent = point.transform;
        previous_holder = point.gameObject;
        tag = "Meteor_Attached";
    }
    public void SETEJECT() {
        EJECT = true;
    }
}
