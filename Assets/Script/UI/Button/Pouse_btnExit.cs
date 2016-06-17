using UnityEngine;
using System.Collections;

public class Pouse_btnExit : MonoBehaviour {
    SceneManager sceneManager;
	// Use this for initialization
	void Start () {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () {
        

	}
    public void ButtonPush()
    {
        GlobalField.globalField.pouseFlg = sceneManager.changePouse(false);
        sceneManager.changeScene((int)SceneManager.scene.TITLE);
    }
}
