using UnityEngine;
using System.Collections;

public class BiteBreak : MonoBehaviour {
    int cnt;
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