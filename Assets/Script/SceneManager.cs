﻿using UnityEngine;
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
    const byte TITLE = 0;
    const byte MAINGAME = 1;
    const byte RESULT = 2;

    byte nowScene;

    public GlobalField globalFleld;
    GameObject spownPoint;

    // Use this for initialization
    void Start()
    {
        /*
        gameMode[TITLE] = GameObject.Find("Title");
        gameMode[MAINGAME] = GameObject.Find("MainGame");
        gameMode[RESULT] = GameObject.Find("Result");
        */
        globalFleld = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        spownPoint = GameObject.Find("SpownPoint");
        mainGameTags.Add("Fish");
        mainGameTags.Add("Bite");
        mainGameTags.Add("Rock");
        mainGameTags.Add("UILife");
        mainGameTags.Add("Trash");
        
        nowScene = TITLE;
        changeScene(TITLE);
        for (int i = 0; i < mainGameTags.Count; i++)
        {
            Debug.Log("gameTag[0] = " + mainGameTags[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            globalFleld.pouseFlg = changePouse(!(pouseMenu.activeInHierarchy));

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
                spownPoint.GetComponent<UIFishLife>().LifeInstanciate();
                break;
            default:
                break;
        }
        nowScene = (byte)orderScene;


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
        for (k = 0; k < mainGameTags.Count; k++)
        {
          GameObject[] deleteObject = (GameObject.FindGameObjectsWithTag(mainGameTags[k]));
            
            //gameobject[] deleteobject = gameobject.findgameobjectswithtag("fish");
            for (i = 0; i < deleteObject.Length; i++)
            {
                Destroy(deleteObject[i]);
            }
        }
        
        /*
        GameObject[] deleteObject = GameObject.FindGameObjectsWithTag(mainGameTags[0]);
        for(int i = 0; i < deleteObject.Length; i++)
        {
            Destroy(deleteObject[i]);
        }
        deleteObject = GameObject.FindGameObjectsWithTag(mainGameTags[1]);
        for (int i = 0; i < deleteObject.Length; i++)
        {
            Destroy(deleteObject[i]);
        }
        deleteObject = GameObject.FindGameObjectsWithTag(mainGameTags[2]);
        for (int i = 0; i < deleteObject.Length; i++)
        {
            Destroy(deleteObject[i]);
        }
        deleteObject = GameObject.FindGameObjectsWithTag(mainGameTags[3]);
        for (int i = 0; i < deleteObject.Length; i++)
        {
            Destroy(deleteObject[i]);
        }
        deleteObject = GameObject.FindGameObjectsWithTag(mainGameTags[4]);
        for (int i = 0; i < deleteObject.Length; i++)
        {
            Destroy(deleteObject[i]);
        }
        */
    }
}