using UnityEngine;
using System.Collections;
public class Result_toStart : MonoBehaviour {
    public SceneManager sceneManager;
	public void ButtonPush()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        sceneManager.changeScene(SceneManager.scene.TITLE);
    }
}
