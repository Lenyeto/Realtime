using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class TurretControl2 : MonoBehaviour
{

    public GameObject turretSwivel;
    public GameObject turretTilt;
    public GameObject leftCannonBase;
    public GameObject leftCannonBarrel;

    public GameObject rightCannonBase;
    public GameObject rightCannonBarrel;

    private Vector3 restingLeftCannonPosition;
    private Vector3 restingRightCannonPosition;

    //Needed only for VR
    public Camera c;

    private int animationProgress;
    private bool isShooting;
    private bool canShoot;

    // Use this for initialization
    void Start()
    {
        restingLeftCannonPosition = leftCannonBarrel.transform.position;
        restingRightCannonPosition = rightCannonBarrel.transform.position;

        animationProgress = 0;
        isShooting = false;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isShooting)
        {
            animationProgress++;
            leftCannonBarrel.transform.Translate(-leftCannonBarrel.transform.forward * 0.02f);
            rightCannonBarrel.transform.Translate(-rightCannonBarrel.transform.forward * 0.02f);
            if (animationProgress >= 50)
            {
                isShooting = false;
            }
        }
        else
        {

            if (animationProgress > 0)
            {
                animationProgress--;
                leftCannonBarrel.transform.Translate(leftCannonBarrel.transform.forward * 0.02f);
                rightCannonBarrel.transform.Translate(rightCannonBarrel.transform.forward * 0.02f);
            }
            else
            {
                if (!canShoot)
                {

                    canShoot = true;
                }

            }
            if (canShoot)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Shoot();
                }
            }
            if (Input.GetKey(KeyCode.F))
            {
                turretSwivel.transform.Rotate(0, 0.1f, 0);
            }
            else if (Input.GetKey(KeyCode.G))
            {

            }
        }
        if (VRDevice.isPresent)
        {
            turretSwivel.transform.rotation = InputTracking.GetLocalRotation(VRNode.Head);
        }

    }

    void Shoot()
    {
        if (!isShooting)
        {
            isShooting = true;
            canShoot = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Ray r = new Ray(c.transform.position, InputTracking.GetLocalRotation(VRNode.Head).eulerAngles);
        Ray r = c.ScreenPointToRay(new Vector3(Screen.width / 3, Screen.height));

        RaycastHit rh;

        LayerMask lm = new LayerMask();
        lm.value = 1 << 8;

        if (Physics.Raycast(r, out rh, 1000, lm))
        {
            Gizmos.DrawLine(c.transform.position, rh.point);
            Gizmos.DrawSphere(rh.point, 1);
            if (rh.collider != null)
            {

            }
        }

    }
}
