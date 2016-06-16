﻿using UnityEngine;
using System.Collections;

public class BitePlace : MonoBehaviour
{
    Vector2 mousePoint;
    bool pushFlg;
    //int placeSecondCnt;
    //GameObject globalField;

    public GameObject bite;
    public GameObject tapPoint;
    GameObject UIAdress;
    bool isTouchUIActive = false;
    GameObject copyRock;
    GlobalField globalField;
    Vector3 placePoint;

    public int i;
    // Use this for initialization
    void Start()
    {
        i = 0;
        pushFlg = false;
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
        globalField.placeSecondCnt = 0;
        isTouchUIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalField.pouseFlg == false)
        {
            //if (Input.GetButtonDown("Place"))
            if (Input.GetMouseButton(0) == true)
            {
                if (pushFlg == false)
                {
                    if (globalField.placeSecondCnt == 0)
                    {

                        UITapPlace();

                    }
                    if (globalField.placeSecondCnt > globalField.rockPlaceSecond)
                    {

                        BitePlacing();
                        
                    }
                    else
                    {
                        globalField.placeSecondCnt += 1;

                    }
                }

            }
            else
            {
                pushFlg = false;
                if (isTouchUIActive == true)
                {
                    globalField.placeSecondCnt = 0;
                    Destroy(UIAdress);
                    isTouchUIActive = false;
                }
            }
        }
    }
    void UITapPlace()
    {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        placePoint = new Vector3(mousePoint.x, mousePoint.y, (float)(GlobalField.LEYER.BITE));
        UIAdress = (GameObject)Instantiate(tapPoint, placePoint, Quaternion.Euler(0, 0, 0));
        UIAdress.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        isTouchUIActive = true;
    }
    void BitePlacing()
    {
        if (i > 3)
        {
            i = 0;
        }
        if (globalField.spoNumBite.num >= globalField.spoNumBite.max)
        {
            Destroy(GameObject.Find("bite" + i));
            globalField.spoNumBite.num -= 1;
        }
        Destroy(UIAdress);
        isTouchUIActive = false;

        copyRock = (GameObject)Instantiate(bite, placePoint, Quaternion.Euler(0, 0, 0));
        copyRock.name = "bite" + i;
        i += 1;
        //globalField = GameObject.Find("GlobalField");
        //globalField.GetComponent<GlobalField>().spoNumRock.num += 1;

        globalField.spoNumBite.num += 1;
        pushFlg = true;
        Debug.Log("biteplaceNum = " + globalField.spoNumBite.num);
        globalField.placeSecondCnt = 0;
    }
}
