using UnityEngine;
using System.Collections;

public class RockPlace_old : MonoBehaviour
{
    Vector2 mousePoint;
    bool pushFlg;
    //int placeSecondCnt;
    //GameObject globalField;

    public GameObject rock;
    public GameObject tapPoint;
    GameObject UIAdress;
    bool isTouchUIActive = false;
    GameObject copyRock;
    GlobalField globalField;
    Vector3 placePoint;

    public int i;

    const string STR_ROCK = "rock";
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
            if (Input.GetMouseButton(0))
            {
                if (pushFlg == false)
                {
                    if (globalField.placeSecondCnt == 0)
                    {

                        UITouchPlace();

                    }
                    if (globalField.placeSecondCnt > globalField.rockPlaceSecond)
                    {

                        //RockPlacing();
                        
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
    void UITouchPlace()
    {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        placePoint = new Vector3(mousePoint.x, mousePoint.y, 1);
        UIAdress = (GameObject)Instantiate(tapPoint, placePoint, Quaternion.Euler(0, 0, 0));
        UIAdress.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        isTouchUIActive = true;
    }
    /*
     旧版岩の設置
     マウスでクリックすると岩を設置する
    */
    /*
    void RockPlaceing_Old()
    {
        if (i > 3)
        {
            i = 0;
        }
        if (globalField.spoNumRock.num >= globalField.spoNumRock.max)
        {
            Destroy(GameObject.Find("rock" + i));
            globalField.spoNumRock.num -= 1;
        }
        Destroy(UIAdress);
        isTouchUIActive = false;

        copyRock = (GameObject)Instantiate(rock, placePoint, Quaternion.Euler(0, 0, 0));
        copyRock.name = "rock" + i;
        i += 1;
        //globalField = GameObject.Find("GlobalField");
        //globalField.GetComponent<GlobalField>().spoNumRock.num += 1;

        globalField.spoNumRock.num += 1;
        pushFlg = true;
        Debug.Log("rockplaceNum = " + globalField.spoNumRock.num);
        globalField.placeSecondCnt = 0;
    }
    */
    public void RockPlacing(int index,Vector3 tPlacePoint)
    {
        if (index > globalField.spoNumRock.max)
        {
            return;
        }
        if(GameObject.Find(STR_ROCK + index) != null)
        {
            for(int l = 0;l < globalField.spoNumRock.max;l++)
            {
                if(GameObject.Find(STR_ROCK + i) == null)
                {
                    RockPlacing(i,tPlacePoint);
                }
            }
            
            return;
        }
        copyRock = (GameObject)Instantiate(rock, tPlacePoint, Quaternion.Euler(0, 0, 0));
        copyRock.name = STR_ROCK + index;
        
        //globalField = GameObject.Find("GlobalField");
        //globalField.GetComponent<GlobalField>().spoNumRock.num += 1;

        globalField.spoNumRock.num += 1;
        Debug.Log("rockplaceNum = " + globalField.spoNumRock.num);
    }
}
