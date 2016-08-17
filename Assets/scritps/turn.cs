using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class turn : MonoBehaviour {

    public Text TurnText;
    public Text TempoText;
    float nextturn;


	// Use this for initialization
	void Start () {
        nextturn = Time.time+5f;
        if (variables.turno)
        {
            TurnText.text = "Turn P1";
            TempoText.color = Color.white;
        }
        else
        {
            TurnText.text = "Turn P2";
            TempoText.color = Color.gray;
        }
    }
	


	// Update is called once per frame
	void Update () {

        TempoText.text = (nextturn - Time.time).ToString("F1"); ;

        if (Time.time>nextturn)        {
            nextturn=Time.time+5f;
            variables.turno = !variables.turno;
            if (variables.turno)
            {
                TurnText.text = "Turn P1";
                TempoText.color = Color.white;
            }
            else
            {
                TurnText.text = "Turn P2";
                TempoText.color = Color.gray;
            }
            
        }
        

    }
}
