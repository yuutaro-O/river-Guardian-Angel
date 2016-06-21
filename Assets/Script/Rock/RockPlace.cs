using UnityEngine;
using System.Collections;

public class RockPlace : MonoBehaviour
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
    Vector3 placePoint;

    public int i;

    const string STR_ROCK = "rock";
    // Use this for initialization
    void Start()
    {
        i = 0;
    }
    
    public GameObject RockPlacing(int index,Vector3 tPlacePoint)
    {
        if (index >= 0  && index < GlobalField.globalField.spoNumRock.max)
        {
            if (GameObject.Find(STR_ROCK + index) != null)  //スタックオーバーフローエラー
            {
                for (int l = 0; l < GlobalField.globalField.spoNumRock.max; l++)
                {
                    if (GameObject.Find(STR_ROCK + l) == null)
                    {
                        RockPlacing(i, tPlacePoint);
                        break;
                    }
                }
                return null;
            }
            copyRock = (GameObject)Instantiate(rock, tPlacePoint, Quaternion.Euler(0, 0, 0));
            copyRock.name = STR_ROCK + index;

            //globalField = GameObject.Find("GlobalField");
            //globalField.GetComponent<GlobalField>().spoNumRock.num += 1;

            GlobalField.globalField.spoNumRock.num += 1;
            Debug.Log("rockplaceNum = " + GlobalField.globalField.spoNumRock.num);
            
        }
        return copyRock;
    }

}
