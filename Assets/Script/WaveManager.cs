using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
    public GlobalField globalField;
    int cnt;                            //再生カウント
    int playcnt;                        //再生時間
    public float playSecond;            //再生時間（秒単位）
    public bool pouseStats;             //演出を再生中かどうか？
    public GameObject UI_changewave;    //ウェーブチェンジのタイミングで表示されるテキスト
    public GameObject UI_changeGene;
    public GameObject rockPlace;
	// Use this for initialization
	void Start () {
        globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        rockPlace = GameObject.FindGameObjectWithTag("RockPlacer");
        //UI_changewave = GameObject.FindGameObjectWithTag("UI_changeWave");
        //UI_changeGene = GameObject.Find("UI_ChanWaveGeneration");
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
                        
                        UI_changewave.SetActive(true);
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
                WaveRockPlace();
            }
            
        }
	}
    /*ウェーブ変更演出関数*/
    public bool WavePouse()
    {
        bool ret = false;
        if (cnt > playcnt)
        {
            UI_changeGene.GetComponent<Transform>().rotation = (Quaternion.Euler(0, 0, 0));
            UI_changeGene.GetComponent<ChanWave_gene>().Sub_WaveDraw();
            ret = true;
        }
        else if (cnt == 0)
        {
            UI_changeGene.GetComponent<Transform>().rotation = (Quaternion.Euler(0, 0, 0));
        }
        else if (cnt == (int)(globalField.framerate * 2.0))
        {
            UI_changeGene.GetComponent<ChanWave_gene>().Ad_WaveDraw();
            UI_changeGene.SetActive(false);

        }
        else if(cnt < globalField.framerate * 2.0)
        {
            UI_changeGene.GetComponent<Transform>().rotation = (Quaternion.Euler(90 * ((cnt / (float)(globalField.framerate * 2.0))), 0, 0));
            
        }
        
        else if (cnt == (int)(globalField.framerate * 3.0))
        {
            UI_changeGene.SetActive(true);

        }
        else if (cnt >globalField.framerate * 3.0) //回転をしたから上にしたい
        {
            UI_changeGene.GetComponent<Transform>().rotation = Quaternion.Euler(90 * ((cnt - (int)(globalField.framerate * 3.0)) /  (float)(globalField.framerate * 2.0 )) - 90, 0, 0); 
        }
        
        else
        {
            
        }
        cnt++;
        return ret;
    }
    public void WaveRockPlace()
    {
        Vector3 PlacePoint;
        AllRockDelete();
        for(int i = 0; i < globalField.spoNumRock.max; i++)
        {
            PlacePoint = Camera.main.ViewportToWorldPoint(new Vector3( Random.Range(0.0f, 0.9f), Random.Range(0.0f, 0.9f), (float)GlobalField.LEYER.ROCK));
            globalField.Rock[i] = rockPlace.GetComponent<RockPlace>().RockPlacing(i,PlacePoint);
        }
    }

    public void AllRockDelete()
    {
        GameObject[] Rock = new GameObject[globalField.spoNumRock.num];
        Rock = GameObject.FindGameObjectsWithTag("Rock");
        for (int i = 0; i < globalField.spoNumRock.num; i++)
        {
            Rock[i].GetComponent<SC_Rock>().deleteRock();
        }
    }
}