using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    float velocidade = -5f;
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocidade, 0, 0);
    }
}
