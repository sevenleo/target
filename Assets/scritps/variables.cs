using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class variables : MonoBehaviour {

	public static bool turno = true;
    public static string debug;
    public static string debug2;
    public Text DebugText;
    public Text DebugText2;
    public static bool movelock;
    public static float minimaldistance = 20;



    // Use this for initialization
    void Start () {
	    debug = "DEBUG\n";
        debug2 = "DEBUG2\n";
    }
	
	// Update is called once per frame
	void Update () {
        DebugText.text = debug;
        DebugText2.text = debug2;

    }
}
