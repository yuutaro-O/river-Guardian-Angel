using UnityEngine;
using System.Collections;

public class Pouse_btnExit : MonoBehaviour {

    GlobalField globalField;
    SceneManager sceneManager;
	// Use this for initialization
	void Start () {
        globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () {
        

	}
    public void ButtonPush()
    {
        globalField.pouseFlg = sceneManager.changePouse(false);
        sceneManager.changeScene(0);
    }
}
