﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    public List<string> mainGameTags = new List<string>();
    byte nowScene;
    GameObject spownPoint;
    WaveManager waveManager;
<<<<<<< HEAD
=======

    // Use this for initialization
>>>>>>> 294da04... 完成ビルド前の作業保存
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
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
    }
    void Update()
    {
        if (nowScene == (int)scene.MAINGAME)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GlobalField.globalField.pouseFlg = changePouse(!(pouseMenu.activeInHierarchy));
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
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
<<<<<<< HEAD
=======
        
        
        int i;
        int k = 0;

>>>>>>> 294da04... 完成ビルド前の作業保存
        GlobalField.globalField.FishDeleteAll();
        GlobalField.globalField.TrashDeleteAll();
        GlobalField.globalField.RockDeleteAll();
    }
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
    public byte GetNowScene()
    {
        return nowScene;
    }
}