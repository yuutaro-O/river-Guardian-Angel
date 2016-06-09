using UnityEngine;
using System.Collections;

public class UITextGeneration : MonoBehaviour {

    GameObject guiGeneration;
    // Use this for initialization
    void Start () {
	    guiGeneration  =  new GameObject("UI_generation");
        guiGeneration.AddComponent<GUIText>();
        //guiGeneration.guiText
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
