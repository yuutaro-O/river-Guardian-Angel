using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChanWave_gene : MonoBehaviour {
    bool waveAdd;
	
	
	// Update is called once per frame
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
    
    public void Ad_WaveDraw()
    {
        waveAdd = true;
    }
    public void Sub_WaveDraw()
    {
        waveAdd = false;
    }
}
