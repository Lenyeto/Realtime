using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class GameController {

    static GameController instance = new GameController();

    private bool isVR = VRDevice.isPresent;

    private int score = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public static GameController getInstance()
    {
        return instance;
    }

    public bool getVR()
    {
        return isVR;
    }

    public void addScore()
    {
        score++;
    }
}
