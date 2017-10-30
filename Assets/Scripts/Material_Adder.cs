
using UnityEngine;
using System.Collections;

public class Material_Adder : MonoBehaviour
{
    public CircleCollider2D inner_coll, outter_coll;
    Collider2D other_pub;
    int i = 0;
    int counter = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (i == 0) {
            i++;
            return;
        }
        Rigidbody2D this_rigid = other.gameObject.GetComponent<Rigidbody2D>();
        this_rigid.AddForce((this.transform.position - other.transform.position).normalized * 80, ForceMode2D.Force);
        other.transform.parent = this.transform;
        other_pub = other;
        //this.GetComponentsInChildren<Transform>()[1].localScale += new Vector3(1f, 1f, 1f);
        //this.GetComponentsInChildren<CircleCollider2D>()[1].radius += 0.0001f;
        print(this.GetComponent<CircleCollider2D>().radius);
        if (this.GetComponent<CircleCollider2D>().radius % 5 == 0)
        {
           // this.GetComponentsInChildren<CircleCollider2D>()[0].radius += 1f;
        }
        else {
            //this.GetComponentsInChildren<CircleCollider2D>()[0].radius += 0.5f;
        }
    }
    void Update() {
        //print(counter);
        if (other_pub != null && other_pub.IsTouching(inner_coll)) {
            other_pub.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (other_pub != null && other_pub.IsTouching(outter_coll))
        {
            
            if (counter <= 50) {
                counter++;
            }
            if (counter > 50)
            {
                counter = 0;
                other_pub.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
           
        }

    }
}