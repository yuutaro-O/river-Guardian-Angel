using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ChanWave_gene : MonoBehaviour {
    bool waveAdd;
	void Update () {
        if (waveAdd == true)
        {
            base.gameObject.GetComponent<Text>().text = (GlobalField.globalField.wave + 1).ToString();
        }
        else
        {
            base.gameObject.GetComponent<Text>().text = GlobalField.globalField.wave.ToString();
        }
    }
    public void Sub_WaveDraw()
    {
        waveAdd = false;
    }
}
