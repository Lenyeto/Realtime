using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

/*! PlayerScript that controls the players movement and animations. */
public class PlayerScript : MonoBehaviour {

    

    public float moveSpeed = 1.0f;
    private bool isDead = false;
    private int countDownTimer = 1000;

    public Animator anim;
    public GameObject skull;

	// Use this for initialization
	void Start () {
	
	}

    /*! Decides movement based on the input controls. */
    void Update()
    {
        if (!isDead)
        {
            if (VRDevice.isPresent)
            {
                Quaternion q = InputTracking.GetLocalRotation(VRNode.Head);
                if (transform.position.z < 13 && InputTracking.GetLocalRotation(VRNode.Head).z > 0)
                {
                    transform.Translate(new Vector3(0, 0, (InputTracking.GetLocalRotation(VRNode.Head).z)));
                }
                if (transform.position.z > -3 && InputTracking.GetLocalRotation(VRNode.Head).z < 0)
                {
                    transform.Translate(new Vector3(0, 0, (InputTracking.GetLocalRotation(VRNode.Head).z)));
                }

                skull.transform.rotation.Set(q.x, q.y, q.z, q.w);
                skull.transform.LookAt(new Vector3(0, 0, 0));
                
            }
            else
            {
                float hmvmt = Input.GetAxis("Horizontal");
                float vmvmt = Input.GetAxis("Vertical");

                if (transform.position.z < 13 && hmvmt > 0)
                {
                    transform.Translate(new Vector3(0, 0, (hmvmt / 50) * moveSpeed));
                }
                if (transform.position.z > -3 && hmvmt < 0)
                {
                    transform.Translate(new Vector3(0, 0, (hmvmt / 50) * moveSpeed));
                }

                if (vmvmt > 0)
                {
                    anim.SetInteger("currentState", 1);
                } else
                {
                    anim.SetInteger("currentState", 0);
                }

                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("StandingStill"))
                {
                    transform.Translate(new Vector3(-(vmvmt / 50) * moveSpeed, 0, 0));

                }
            }
        } else
        {
            countDownTimer -= 1;
            if (countDownTimer <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    /*! Decides what happens when the player hits certain items. */
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "DEATH")
        {
            isDead = true;
        } else if (c.gameObject.tag == "COIN")
        {
            GameController.getInstance().addScore();
        }
    }

    void OnDrawGizmos()
    {
        
    }
}
