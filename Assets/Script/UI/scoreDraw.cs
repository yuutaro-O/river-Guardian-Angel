using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class scoreDraw : MonoBehaviour {
	void Update () {
        base.gameObject.GetComponent<Text>().text = GlobalField.globalField.score.ToString();
	}
}
