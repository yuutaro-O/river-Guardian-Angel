using UnityEngine;
using System.Collections;
public class WaveManager : MonoBehaviour {
    int cnt;
    int playcnt;
    int gameoverCnt;
    int gameoverPlayCnt;
    public float playSecond;
    float gameoverSecond;
    bool pouseStats;
    public GameObject UI_changewave;
    [SerializeField]
    ChanWave_gene SC_UI_changeGene;
    [SerializeField]
    GameObject UI_changeGene;
    [SerializeField]
    RockPlace rockPlace;
    bool isgameOver;
    [SerializeField]
    Transform UI_ChangeGene;
    [SerializeField]
    GameObject UI_gameOver;
    [SerializeField]
    SceneManager sceneManager;
    [SerializeField]
    GameObject UI_ObjectiveFish;
    void Start () {
        playSecond = 5.0f;
        gameoverSecond = 5.0f;
        playcnt = (int)(playSecond * GlobalField.globalField.framerate);
        gameoverPlayCnt = (int)(gameoverSecond * GlobalField.globalField.framerate);
        cnt = 0;
        pouseStats = false;
	}
	void Update () {
        if (sceneManager.GetNowScene() == (byte)SceneManager.scene.MAINGAME)
        {
            if (pouseStats == false)
            {
                if (GlobalField.globalField.waveFish.num >= GlobalField.globalField.waveFish.max)
                {
                    if (GlobalField.globalField.spoNumFish.num <= 0)
                    {
                        if (GlobalField.globalField.spoNumTrash.num <= 0)
                        {
                            if (GlobalField.globalField.GetLife() <= 0)
                            {
                                pouseStats = true;
                                isgameOver = true;
                                UI_gameOver.SetActive(true);
                            }
                            else
                            {
                                pouseStats = true;
                                UI_changewave.SetActive(true);
                            }
                        }
                    }
                }
            }
            else
            {
                if (isgameOver == true)
                {
                    gameoverCnt++;
                    if (gameoverCnt > gameoverPlayCnt)
                    {
                        isgameOver = false;
                        UI_gameOver.SetActive(false);
                        sceneManager.changeScene(SceneManager.scene.RESULT);
                    }
                }
                else if (WavePouse() == true)
                {
                    pouseStats = false;
                    cnt = 0;
                    UI_changewave.SetActive(false);
                    UI_ObjectiveFish.SetActive(false);
                    WaveRockPlace();
                }
            }
        }
	}
    public bool WavePouse()
    {
        bool ret = false;
        if (cnt > playcnt)
        {
            UI_ChangeGene.rotation = (Quaternion.Euler(0, 0, 0));
            SC_UI_changeGene.Sub_WaveDraw();
            ret = true;
        }
        else if (cnt == 0)
        {
            UI_ChangeGene.rotation = (Quaternion.Euler(0, 0, 0));
        }
        else if (cnt == (int)(GlobalField.globalField.framerate * 2.0))
        {
            UI_changeGene.SetActive(false);
        }
        else if(cnt < GlobalField.globalField.framerate * 2.0)
        {
            UI_ChangeGene.rotation = (Quaternion.Euler(90 * ((cnt / (float)(GlobalField.globalField.framerate * 2.0))), 0, 0));
        }
        else if (cnt == (int)(GlobalField.globalField.framerate * 3.0))
        {
            UI_changeGene.SetActive(true);
            UI_ObjectiveFish.SetActive(true);
            GlobalField.globalField.WaveChange();
        }
        else if (cnt >GlobalField.globalField.framerate * 3.0)
        {
            UI_ChangeGene.rotation = Quaternion.Euler(90 * ((cnt - (int)(GlobalField.globalField.framerate * 3.0)) /  (float)(GlobalField.globalField.framerate * 2.0 )) - 90, 0, 0); 
        }
        cnt++;
        return ret;
    }
    public void WaveRockPlace()
    {
        AllRockDelete();
        rockPlace.ResetRockPoint();
        rockPlace.WaveRockPlacing();
    }
    public void AllRockDelete()
    {
        for (int i = 0; i < GlobalField.globalField.Rock.Length; i++)
        {
            if (GlobalField.globalField.Rock[i] != null)
            {
                GlobalField.globalField.Rock[i].GetComponent<SC_Rock>().deleteRock();
            }
        }
    }
    public bool GetPouseStats()
    {
        return pouseStats;
    }
}