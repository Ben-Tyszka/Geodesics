using UnityEngine;
using System.Collections;

public class SpaceShip_Move : MonoBehaviour {

    float speed = 2.5f;
    public bool canMove = true;
    Vector2 prev_pos;
    float touch_dur;
    Touch touch;
    RaycastHit hit;
    Ray ray;
	void Update () {
        //print(Input.mousePosition);
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0) * Time.deltaTime);
       
        if (Input.touchCount > 0)
            {
            
                touch_dur += Time.deltaTime;
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended && touch_dur < 0.2f)
                {
                    StartCoroutine("Determine");
                }
            }
            else {
                touch_dur = 0.0f;
            }

        if (canMove) {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, direction, speed * Time.deltaTime);
        }
            
           /* if (Input.mousePosition.y > 35.0f && Input.mousePosition.y < 75.0f && Input.mousePosition.x > Screen.width - 95)
            {
                print("no zone");

                transform.position = Vector2.Lerp(transform.position, prev_pos, speed * Time.deltaTime);
            }
            else
            {

                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);//new Vector3(Input.GetAxis("Mouse X"),  Input.GetAxis("Mouse Y"), 0);
                                                                                        //direction *= speed * Time.deltaTime;
                prev_pos = direction;
                transform.position = Vector2.Lerp(transform.position, direction, speed * Time.deltaTime);
            }*/
            


            if (Input.GetAxis("Jump") == 1)
            {
                for (int i = 0; i < GetComponentsInChildren<Transform>().Length; i++)
                {
                    if (GetComponentsInChildren<Transform>()[i].name.Contains("Meteor"))
                    {
                        GetComponentsInChildren<Transform>()[i].gameObject.GetComponent<OrbitNow>().SendMessage("SETEJECT");
                    }
                }
            }
        
        
    }
    IEnumerator Determine() {
        yield return new WaitForSeconds(0.2f);
        if (touch.tapCount == 1)
        {
            print("Single");
            //canMove = true;
        }
        else if (touch.tapCount == 2) {
            print("Double");
            //canMove = false;
            for (int i = 0; i < GetComponentsInChildren<Transform>().Length; i++)
            {
                if (GetComponentsInChildren<Transform>()[i].name.Contains("Meteor"))
                {
                    GetComponentsInChildren<Transform>()[i].gameObject.GetComponent<OrbitNow>().SendMessage("SETEJECT");
                }
            }
            StopCoroutine("Determine");
        }
    }
}
