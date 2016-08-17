using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class variables : MonoBehaviour {

	public static bool turno = true;
    public static string debug;
    public Text DebugText;
    

	// Use this for initialization
	void Start () {
	    debug = "DDEBUG :\n";
    }
	
	// Update is called once per frame
	void Update () {
        DebugText.text = debug;
	}
}
