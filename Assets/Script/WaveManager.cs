using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
    public GlobalField globalField;
    int cnt;                            //再生カウント
    int playcnt;                        //再生時間
    public float playSecond;            //再生時間（秒単位）
    public bool pouseStats;             //演出を再生中かどうか？
    public GameObject UI_changewave;    //ウェーブチェンジのタイミングで表示されるテキスト
	// Use this for initialization
	void Start () {
        globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        //UI_changewave = GameObject.FindGameObjectWithTag("UI_changeWave");
        Debug.Log("UI_ChangeWave = " + UI_changewave);
        Debug.Log("globalField = " + globalField);
        playSecond = 5.0f;
        playcnt = (int)(playSecond * globalField.framerate);
        cnt = 0;
        pouseStats = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("waveManager.sponumfish" + globalField.spoNumFish);
        Debug.Log("waveManager.sponumtrash" + globalField.spoNumTrash);
        Debug.Log("UI_ChangeWave = " + UI_changewave);
        if (pouseStats == false)
        {
            if (globalField.waveFish.num >= globalField.waveFish.max)
            {
                if (globalField.spoNumFish.num <= 0)
                {
                    if (globalField.spoNumTrash.num <= 0)
                    {
                        pouseStats = true;
                        
                        UI_changewave.SetActive(true);  //参照できていない
                    }
                }
            }
        }
        else
        {
            if(WavePouse() == true)
            {
                pouseStats = false;
                cnt = 0;
                UI_changewave.SetActive(false);
                globalField.WaveChange();
            }
            
        }
	}
    /*ウェーブ変更演出関数*/
    public bool WavePouse()
    {
        bool ret = false;
        if (cnt > playcnt)
        {
            ret = true;
        }

        else
        {
            
        }
        return ret;
    }

}