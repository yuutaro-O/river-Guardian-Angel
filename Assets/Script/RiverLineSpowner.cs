using UnityEngine;
using System.Collections;

public class RiverLineSpowner : MonoBehaviour {
    [SerializeField]
    GameObject P_RiverLine;
    [SerializeField]
    float[] RiverRandomSpeed;
    bool[] spownRiverLineflg;
    int spownNumber;
    public void SpownRiverLine()
    {
        spownRiverLineflg = new bool[GlobalField.globalField.spownPointx.Length];
        for (int i = 0;i < GlobalField.globalField.spoNumRiverLine.max; i++)
        {
            spownNumber = Random.Range(0, GlobalField.globalField.spoNumRiverLine.max - 1);
            if(spownRiverLineflg[spownNumber] == true) {
                for(int j = 0; j < spownRiverLineflg.Length; j++)
                {
                    if(spownRiverLineflg[j] == false)
                    {
                        spownNumber = j;
                        break;
                    }
                }
            }
            GlobalField.globalField.RiverLine[i] = (GameObject)Instantiate(P_RiverLine, new Vector3(GlobalField.globalField.trashSpownPoint[spownNumber].x, GlobalField.globalField.trashSpownPoint[spownNumber].y, (float)GlobalField.LEYER.LINE), P_RiverLine.transform.rotation);
            GlobalField.globalField.RiverLine[i].GetComponent<SCRiverLine>().SetRandSpd(Random.Range(RiverRandomSpeed[0],RiverRandomSpeed[1]));
            spownRiverLineflg[spownNumber] = true;
        }
    }
    public void RiverLineAllDelete()
    {
        for(int i = 0; i < GlobalField.globalField.RiverLine.Length; i++)
        {
            if(GlobalField.globalField.RiverLine[i] == null)
            {
                continue;
            }
            GlobalField.globalField.RiverLine[i].GetComponent<SCRiverLine>().DeleteObject();
        }
    }
}