using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
    int cnt;                            //再生カウント
    int playcnt;                        //再生時間
    public float playSecond;            //再生時間（秒単位）
    public bool pouseStats;             //演出を再生中かどうか？
    public GameObject UI_changewave;    //ウェーブチェンジのタイミングで表示されるテキスト
    public GameObject UI_changeGene;
    public GameObject rockPlace;
	// Use this for initialization
	void Start () {
        rockPlace = GameObject.FindGameObjectWithTag("RockPlacer");
        //UI_changewave = GameObject.FindGameObjectWithTag("UI_changeWave");
        //UI_changeGene = GameObject.Find("UI_ChanWaveGeneration");
        Debug.Log("UI_ChangeWave = " + UI_changewave);
        Debug.Log("globalField = " + GlobalField.globalField);
        playSecond = 5.0f;
        playcnt = (int)(playSecond * GlobalField.globalField.framerate);
        cnt = 0;
        pouseStats = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("waveManager.sponumfish" + GlobalField.globalField.spoNumFish);
        Debug.Log("waveManager.sponumtrash" + GlobalField.globalField.spoNumTrash);
        Debug.Log("UI_ChangeWave = " + UI_changewave);
        if (pouseStats == false)
        {
            if (GlobalField.globalField.waveFish.num >= GlobalField.globalField.waveFish.max)
            {
                if (GlobalField.globalField.spoNumFish.num <= 0)
                {
                    if (GlobalField.globalField.spoNumTrash.num <= 0)
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
                GlobalField.globalField.WaveChange();
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
        else if (cnt == (int)(GlobalField.globalField.framerate * 2.0))
        {
            UI_changeGene.GetComponent<ChanWave_gene>().Ad_WaveDraw();
            UI_changeGene.SetActive(false);

        }
        else if(cnt < GlobalField.globalField.framerate * 2.0)
        {
            UI_changeGene.GetComponent<Transform>().rotation = (Quaternion.Euler(90 * ((cnt / (float)(GlobalField.globalField.framerate * 2.0))), 0, 0));
            
        }
        
        else if (cnt == (int)(GlobalField.globalField.framerate * 3.0))
        {
            UI_changeGene.SetActive(true);

        }
        else if (cnt >GlobalField.globalField.framerate * 3.0) //回転をしたから上にしたい
        {
            UI_changeGene.GetComponent<Transform>().rotation = Quaternion.Euler(90 * ((cnt - (int)(GlobalField.globalField.framerate * 3.0)) /  (float)(GlobalField.globalField.framerate * 2.0 )) - 90, 0, 0); 
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
        for(int i = 0; i < GlobalField.globalField.spoNumRock.max; i++)
        {
            PlacePoint = Camera.main.ViewportToWorldPoint(new Vector3( Random.Range(0.0f, 0.9f), Random.Range(0.0f, 0.9f), (float)GlobalField.LEYER.ROCK));
            GlobalField.globalField.Rock[i] = rockPlace.GetComponent<RockPlace>().RockPlacing(i,PlacePoint);
        }
    }

    public void AllRockDelete()
    {
        GameObject[] Rock = new GameObject[GlobalField.globalField.spoNumRock.num];
        Rock = GameObject.FindGameObjectsWithTag("Rock");
        for (int i = 0; i < GlobalField.globalField.spoNumRock.num; i++)
        {
            Rock[i].GetComponent<SC_Rock>().deleteRock();
        }
    }
}