using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
    public GlobalField globalField;
	// Use this for initialization
	void Start () {
        globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("waveManager.sponumfish" + globalField.spoNumFish);
        Debug.Log("waveManager.sponumtrash" + globalField.spoNumTrash);
        if (globalField.waveFish.num >= globalField.waveFish.max)
        {
            if (globalField.spoNumFish.num <= 0)
            {
                if (globalField.spoNumTrash.num <= 0)
                {
                    globalField.WaveChange();
                }
            }
        }
	}


}
