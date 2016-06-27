using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_DrawRemFish : MonoBehaviour {
    Text drawText;
    void Start()
    {
        drawText = GetComponent<Text>();
    }
	void Update () {
        drawText.text = (GlobalField.globalField.waveFish.max - GlobalField.globalField.waveFish.num).ToString();
    }
}
