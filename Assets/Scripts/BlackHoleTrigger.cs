using UnityEngine;
using System.Collections;

public class BlackHoleTrigger : MonoBehaviour {

    public GameObject blackhole_core;
    bool can_suck;
    GameObject object_being_drawn_in;
    Vector2 diff, direction;
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name.Contains("Meteor"))
        {
            if (other.GetComponent<OrbitNow>().previous_holder != null)
            {
                other.GetComponent<OrbitNow>().previous_holder.GetComponent<Orbit_Adder>().IncreaseEntropy();
            }
            
            object_being_drawn_in = other.gameObject;
            can_suck = true;
        }
        else if (other.name.Contains("Player")) {
            other.GetComponent<SpaceShip_Move>().canMove = false;
            object_being_drawn_in = other.gameObject;
            other.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
            diff = this.transform.position - object_being_drawn_in.transform.position;
            direction = diff.normalized;
            Rigidbody2D rgd = object_being_drawn_in.GetComponent<Rigidbody2D>();
            float gravitationForce = (float)(1000 * rgd.mass * 40) / diff.sqrMagnitude;
            rgd.AddForce(direction * gravitationForce);
            can_suck = true;
            print("Sucking");
        }
    }
    
    void Update () {
        if (can_suck && object_being_drawn_in != null) {
            diff = this.transform.position - object_being_drawn_in.transform.position;
            direction = diff.normalized;
            Rigidbody2D rgd = object_being_drawn_in.GetComponent<Rigidbody2D>();
            float gravitationForce = (float)(1000 * rgd.mass * 40) / diff.sqrMagnitude;
            rgd.AddForce(direction * gravitationForce);
            can_suck = false;
            //print("sucked in: " + object_being_drawn_in.name);
        }

	}
}
