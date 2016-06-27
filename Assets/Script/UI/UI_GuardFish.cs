using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI_GuardFish : MonoBehaviour {
    Text text;
	void Start () {
        text = GetComponent<Text>();
	}
	void Update () {
        text.text = (GlobalField.globalField.waveFish.max - GlobalField.globalField.GetLife()).ToString();
	}
}
