using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using Assets.Scripts.Utility;


/*! PlayerScript that controls the players movement and animations. */
public class PlayerScript : MonoBehaviour {

    

    public float moveSpeed = 1.0f;
    private bool isDead = false;
    private int countDownTimer = 1000;

    public Animator anim;
    public GameObject skull;

    public Camera cam1;
    public Camera cam2;

    public GameObject turretSwivel;
    public GameObject turretTilt;
    public GameObject leftBarrelBase;
    public GameObject leftBarrel;
    public GameObject rightBarrelBase;
    public GameObject rightBarrel;

    public bool isMultiplayer;

	// Use this for initialization
	void Start () {
	    
	}

    /*! Decides movement based on the input controls. */
    void Update()
    {
        if (!isDead)
        {
            if (isMultiplayer)
            {
                if (VRDevice.isPresent)
                {
                    //Player 1
                    float vmvmt = Input.GetAxis("Vertical");
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

                    //Player 2 (VR Player)
                    //print(cam2.transform.localRotation.eulerAngles.y);
                    if (UtilRotate.newRotateNumber(turretSwivel.transform.localRotation.eulerAngles.y + 180) < UtilRotate.newRotateNumber(cam2.transform.localRotation.eulerAngles.y - 90))
                    {
                        turretSwivel.transform.Rotate(new Vector3(0, 0.1f, 0));
                    } else if (UtilRotate.newRotateNumber(turretSwivel.transform.localRotation.eulerAngles.y + 180) > UtilRotate.newRotateNumber(cam2.transform.localRotation.eulerAngles.y - 90))
                    {
                        turretSwivel.transform.Rotate(new Vector3(0, -0.1f, 0));
                    }

                    if (UtilRotate.newRotateNumber(turretTilt.transform.localEulerAngles.x) < UtilRotate.newRotateNumber(cam2.transform.localEulerAngles.x))
                    {
                        //turretTilt.transform.Rotate(new Vector3(0, 0, 0.1f));
                        turretTilt.transform.Rotate(Vector3.Cross(turretTilt.transform.right, turretTilt.transform.up), 0.1f);
                    } else if (UtilRotate.newRotateNumber(turretTilt.transform.localEulerAngles.x) > UtilRotate.newRotateNumber(cam2.transform.localEulerAngles.x))
                    {
                        //turretTilt.transform.Rotate(new Vector3(0, 0, -0.1f));
                        turretTilt.transform.Rotate(Vector3.Cross(turretTilt.transform.right, turretTilt.transform.up), -0.1f);
                    }

                    

                } else
                {
                    //Player 1

                    //Player 2

                }
            }
            else
            {
                if (VRDevice.isPresent)
                {
                    float vmvmt = Input.GetAxis("Vertical");

                    if (vmvmt > 0)
                    {
                        anim.SetInteger("currentState", 1);
                    }
                    else
                    {
                        anim.SetInteger("currentState", 0);
                    }

                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("StandingStill"))
                    {
                        transform.Translate(new Vector3(-(vmvmt / 50) * moveSpeed, 0, 0));

                    }

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
                    }
                    else
                    {
                        anim.SetInteger("currentState", 0);
                    }

                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("StandingStill"))
                    {
                        transform.Translate(new Vector3(-(vmvmt / 50) * moveSpeed, 0, 0));

                    }
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
