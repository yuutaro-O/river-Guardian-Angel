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
    GlobalField globalField;
    Vector3 placePoint;

    public int i;

    const string STR_ROCK = "rock";
    // Use this for initialization
    void Start()
    {
        i = 0;
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
    }
    
    public GameObject RockPlacing(int index,Vector3 tPlacePoint)
    {
        if (index >= 0  && index < globalField.spoNumRock.max)
        {
            if (GameObject.Find(STR_ROCK + index) != null)
            {
                for (int l = 0; l < globalField.spoNumRock.max; l++)
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

            globalField.spoNumRock.num += 1;
            Debug.Log("rockplaceNum = " + globalField.spoNumRock.num);
            
        }
        return copyRock;
    }

}
