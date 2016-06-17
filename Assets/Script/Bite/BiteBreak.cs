using UnityEngine;
using System.Collections;

public class BiteBreak : MonoBehaviour {
    int cnt;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        cnt++;

	    if(cnt >= GlobalField.globalField.biteBreakCnt)
        {
            cnt = 0;
            BiteDelete();
        }
	}

    public void BiteDelete()
    {
        Destroy(base.gameObject);
        GlobalField.globalField.spoNumBite.num -= 1;
    }
}
