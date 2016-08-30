using UnityEngine;
using System.Collections;


public class MapController : MonoBehaviour {

    public GameObject groundPiece;
    public GameObject TNT;
    public int maxAhead;
    
    private GameObject[] tiles = new GameObject[10];
    private GameObject[] tnts = new GameObject[3];

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
	    if (Input.GetKeyDown(KeyCode.A))
        {
            addPiece();
        }
        this.transform.Translate(-0.5f, 0.0f, 0.0f);
        if (this.transform.position.x <= tiles[1].transform.position.x)
        {
            addPiece();
        }
        foreach(GameObject g in tiles)
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
        //if (tiles[9].transform.position.y >= 0)
        //{
        //    tiles[9].transform.position = tiles[9].transform.position + new Vector3(0, -0.1f, 0);
        //}
    }

    void addTNT()
    {

    }
}
