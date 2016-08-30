using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    static GameController instance = new GameController();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    static GameController getInstance()
    {
        return instance;
    }
}
