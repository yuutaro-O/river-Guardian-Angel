using UnityEngine;
using System.Collections;
public class Pouse_btnExit : MonoBehaviour {
    SceneManager sceneManager;
	void Start () {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
	}
    public void ButtonPush()
    {
        GlobalField.globalField.pouseFlg = sceneManager.changePouse(false);
        sceneManager.changeScene((int)SceneManager.scene.TITLE);
    }
}
