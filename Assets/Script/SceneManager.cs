using UnityEngine;
using System.Collections;
using System.Collections.Generic; //List<>型を使用するための定義

public class SceneManager : MonoBehaviour
{
    public GameObject[] gameMode;
    public GameObject pouseMenu;
    public enum scene
    {
        TITLE = 0,
        MAINGAME,
        RESULT
    }
    public List<string> mainGameTags = new List<string>(); //MainGameにて使用するオブジェクトのTagを格納
    //public const byte TITLE = 0;
    //public const byte MAINGAME = 1;
    //public const byte RESULT = 2;

    byte nowScene;

    GameObject spownPoint;
    WaveManager waveManager;

    // Use this for initialization
    void Start()
    {
        spownPoint = GameObject.Find("SpownPoint");
        mainGameTags.Add("Fish");
        mainGameTags.Add("Bite");
        mainGameTags.Add("Rock");
        mainGameTags.Add("UILife");
        mainGameTags.Add("Trash");
        
        nowScene = (int)scene.TITLE;
        spownPoint.GetComponent<RiverLineSpowner>().SpownRiverLine();
        changeScene(nowScene);
        GameObject.FindGameObjectWithTag("SpownPoint").GetComponent<WaveManager>().AllRockDelete();

    }

    // Update is called once per frame
    void Update()
    {
        if (nowScene == (int)scene.MAINGAME)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GlobalField.globalField.pouseFlg = changePouse(!(pouseMenu.activeInHierarchy));

            }
        }
        
    }

    public void changeScene(int orderScene)
    {
        switch (nowScene)
        {

            case (int)scene.MAINGAME:
                exitMainGame();

                break;

            default:
                break;

        }

        for (int i = 0; i < gameMode.Length; i++)
        {
            gameMode[i].SetActive(false);
        }
        gameMode[orderScene].SetActive(true);
        switch(orderScene){
            case (int)scene.MAINGAME:
                GlobalField.globalField.reset();
                break;
            default:
                break;
        }
        nowScene = (byte)orderScene;


    }
    public void changeScene(scene orderScene){
        changeScene((int)orderScene);
    }

    public bool changePouse(bool isPouse)
    {
        pouseMenu.SetActive(isPouse);
        return isPouse;
    }

    void exitMainGame()
    {
        
        
        int i;
        int k = 0;

        GlobalField.globalField.FishDeleteAll();
        GlobalField.globalField.TrashDeleteAll();
        GlobalField.globalField.RockDeleteAll();
    }

    public byte GetNowScene()
    {
        return nowScene;
    }
}
