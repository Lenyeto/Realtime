using UnityEngine;
using System.Collections;
using UnityEngine.VR;


public class MapController : MonoBehaviour {
    

    public GameObject groundPiece;
    public GameObject TNT;
    public GameObject coin;
    public int maxAhead;
    
    private GameObject[] tiles = new GameObject[10];
    private GameObject[] tnts = new GameObject[3];

    private GameObject[] coinStream = new GameObject[6];
    private GameObject lastCoin;

    private GameObject lastTNT;
    

    // Use this for initialization
	void Start () {

        tiles[0] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x, 0, this.transform.position.z), new Quaternion()));
        tiles[1] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 5, 0, this.transform.position.z), new Quaternion()));
        tiles[2] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 10, 0, this.transform.position.z), new Quaternion()));
        tiles[3] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 15, 0, this.transform.position.z), new Quaternion()));
        tiles[4] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 20, 0, this.transform.position.z), new Quaternion()));
        tiles[5] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 25, 0, this.transform.position.z), new Quaternion()));
        tiles[6] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 30, 0, this.transform.position.z), new Quaternion()));
        tiles[7] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 35, 0, this.transform.position.z), new Quaternion()));
        tiles[8] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 40, 0, this.transform.position.z), new Quaternion()));
        tiles[9] = (GameObject) (Instantiate(groundPiece, new Vector3(this.transform.position.x - 45, 0, this.transform.position.z), new Quaternion()));


        tnts[0] = (GameObject) (Instantiate(TNT, new Vector3(this.transform.position.x - Random.value * 10 + 20, 0, 5), new Quaternion()));
        tnts[1] = (GameObject)(Instantiate(TNT, new Vector3(this.transform.position.x - Random.value * 10 + 20, 0, 5), new Quaternion()));
        tnts[2] = (GameObject)(Instantiate(TNT, new Vector3(this.transform.position.x - Random.value * 10 + 20, 0, 5), new Quaternion()));
        
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x <= tiles[1].transform.position.x)
        {
            addPiece();
        }

        if (lastCoin != null)
        {
            if (this.transform.position.x <= lastCoin.transform.position.x)
            {
                addCoin();
            }
        } else
        {
            addCoin();
        }
        
        foreach (GameObject g in tiles)
        {
            if (g.transform.position.y < 0)
            {
                g.transform.Translate(new Vector3(0, 0.05f, 0));
            }
        }
        Random r = new Random();
        
        foreach (GameObject tnt in tnts)
        {
            if (!tnt.activeInHierarchy)
            {
                float x = Random.value - 0.5f;
                tnt.SetActive(true);
                tnt.transform.position = new Vector3(tiles[9].transform.position.x, 1, 15 * x);
            } else
            {
                
            }
        }
	}

    void addPiece()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i != 9)
            {
                tiles[i].transform.position = tiles[i + 1].transform.position;
            } else
            {
                tiles[i].transform.position = new Vector3(tiles[i].transform.position.x - 5, -1, tiles[i].transform.position.z);
            }
        }
        if (VRDevice.isPresent)
        {
            GameObject.Destroy(Instantiate(tiles[0]), 10);
        }
    }

    void addTNT()
    {
        GameObject obj = Instantiate(TNT);

        GameObject.Destroy(obj, 10);
    }

    void addCoin()
    {
        coinStream = new GameObject[6];

        //This is for the style of coin placement
        //1 is Straight
        //2 is curve up
        int placement = Random.Range(1, 3);


        for (int i = 0; i < 6; i++)
        {
            GameObject obj = Instantiate(coin);
            GameObject.Destroy(obj, 10);

            if (i == 0)
            {
                obj.transform.position = tiles[9].transform.position;
                obj.transform.Translate(0, Random.Range(-8, 8), 0);
                obj.transform.Translate(new Vector3(0, 0, -5));
            } else
            {
                if (placement == 1)
                {
                    obj.transform.position = coinStream[i - 1].transform.position + new Vector3(-10, 0, 0);
                } else if (placement == 2)
                {
                    obj.transform.position = coinStream[i - 1].transform.position + new Vector3(-10, 10*Mathf.Sin(i), 0);
                }
            }

            coinStream[i] = obj;
        }

        lastCoin = coinStream[5];
    }
}
