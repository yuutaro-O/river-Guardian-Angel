using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_GuardFish : MonoBehaviour {

    Text text;
    // Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = (GlobalField.globalField.waveFish.max - GlobalField.globalField.GetLife()).ToString();
	}
}
