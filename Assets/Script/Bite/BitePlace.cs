using UnityEngine;
using System.Collections;

public class BitePlace : MonoBehaviour
{
    Vector2 mousePoint;
    bool pushFlg;
    //int placeSecondCnt;
    //GameObject globalField;

    [SerializeField]
    GameObject bite;
    [SerializeField]
    GameObject tapPoint;

    GameObject UIAdress;
    bool isTouchUIActive = false;
    GameObject copyRock;
    Vector3 placePoint;

    [SerializeField]
    Transform canvas;


    public int i;
    // Use this for initialization
    void Start()
    {
        i = 0;
        pushFlg = false;
        GlobalField.globalField.placeSecondCnt = 0;
        isTouchUIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            //if (Input.GetButtonDown("Place"))
            if (Input.GetMouseButton(0) == true)
            {
                if (pushFlg == false)
                {
                    if (GlobalField.globalField.placeSecondCnt == 0)
                    {

                        UITapPlace();

                    }
                    if (GlobalField.globalField.placeSecondCnt > GlobalField.globalField.rockPlaceSecond)
                    {

                        BitePlacing();
                        
                    }
                    else
                    {
                        GlobalField.globalField.placeSecondCnt += 1;

                    }
                }

            }
            else
            {
                pushFlg = false;
                if (isTouchUIActive == true)
                {
                    GlobalField.globalField.placeSecondCnt = 0;
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
        UIAdress.transform.SetParent(canvas);
        isTouchUIActive = true;
    }
    void BitePlacing()
    {
        if (i >= GlobalField.globalField.spoNumBite.max)
        {
            i = 0;
        }
        if (GlobalField.globalField.spoNumBite.num >= GlobalField.globalField.spoNumBite.max)
        {
            GlobalField.globalField.Bite[i].GetComponent<BiteBreak>().BiteDelete();
            
        }
        Destroy(UIAdress);
        isTouchUIActive = false;

        GlobalField.globalField.Bite[i] = (GameObject)Instantiate(bite, placePoint, Quaternion.Euler(0, 0, 0));
        GlobalField.globalField.Bite[i].name = "bite" + i;
        i += 1;
        //GlobalField.globalField = GameObject.Find("GlobalField");
        //globalField.GetComponent<GlobalField>().spoNumRock.num += 1;

        GlobalField.globalField.spoNumBite.num += 1;
        pushFlg = true;
        GlobalField.globalField.placeSecondCnt = 0;
    }
}



