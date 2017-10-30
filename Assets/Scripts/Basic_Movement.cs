using UnityEngine;
using System.Collections;

public class Basic_Movement : MonoBehaviour {

   float speed = 500.5f;
   public GameObject follow;

    void Start () {
        //this.transform.parent = follow.transform; 
    }
	
	
	void Update () {
        MeshRenderer mesh = follow.GetComponent<MeshRenderer>();
        Vector2 offset = mesh.material.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / speed;
        offset.y = transform.position.y / transform.localScale.y / speed;
        mesh.material.mainTextureOffset = offset;
    }
}
