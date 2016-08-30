using UnityEngine;
using System.Collections;


public class PlayerScript : MonoBehaviour {

    public float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        float vmvmt = Input.GetAxis("Horizontal");
        if (transform.position.z < 13 && vmvmt > 0)
        {
            transform.Translate(new Vector3(0, 0, (vmvmt / 50) * moveSpeed));
        }
        if (transform.position.z > -3 && vmvmt < 0)
        {
            transform.Translate(new Vector3(0, 0, (vmvmt / 50) * moveSpeed));
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "DEATH")
        {
            
        }
    }
}
