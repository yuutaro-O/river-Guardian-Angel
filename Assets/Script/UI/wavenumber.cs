using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wavenumber : MonoBehaviour {
    public GlobalField globalfield;
	// Use this for initialization
	void Start () {
        globalfield = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
	}
	
	// Update is called once per frame
	void Update () {
        base.gameObject.GetComponent<Text>().text = globalfield.wave.ToString();
	}
}
