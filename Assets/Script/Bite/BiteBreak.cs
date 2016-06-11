using UnityEngine;
using System.Collections;

public class BiteBreak : MonoBehaviour {
    int cnt;
    public GlobalField globalField;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        cnt++;
        if (globalField == null)
        {
            globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        }
	    if(cnt >= globalField.biteBreakCnt)
        {
            cnt = 0;
            BiteDelete(base.gameObject);
        }
	}

    public void BiteDelete(GameObject deleter)
    {
        Destroy(deleter);
    }
}
