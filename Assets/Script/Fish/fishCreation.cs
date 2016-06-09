using UnityEngine;
using System.Collections;

public class fishCreation : MonoBehaviour
{
    [SerializeField]
    int basePoint;
    public GameObject fish;
    public GameObject copyFish;
    GlobalField globalField;
    int i;
    // Use this for initialization
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalField.pouseFlg == false)
        {
            if (UnityEngine.Random.Range(0, 100) >= basePoint)
            {
                if (globalField.spoNumFish.num < globalField.spoNumFish.max)
                {
                    /*
                    copyFish = (GameObject)Instantiate(fish, new Vector3(Random.Range(globalField.fishSpownPoint.x - globalField.spownRangeDif, globalField.fishSpownPoint.x + globalField.spownRangeDif), globalField.fishSpownPoint.y, globalField.L_FISH), Quaternion.Euler(new Vector3(0, 0, 0)));
                    globalField.spoNumFish.num += 1;
                    for (i = 0;i < globalField.spoNumFish.max;i++) {
                        if (GameObject.Find("fish" + i) == null)
                        {
                            copyFish.name = "fish" + i;
                            break;
                        }
                    }
                    Debug.Log("fishSpownNum = " + globalField.spoNumFish.num);
                    */
                    //copyFish = (GameObject)Instantiate(fish, new Vector3(globalField.fishspownPointx[(int)UnityEngine.Random.Range(0,2)], globalField.fishSpownPoint.y, globalField.L_FISH), Quaternion.Euler(new Vector3(0, 0, 0)));
                    //copyFish = (GameObject)Instantiate(fish, new Vector3(globalField.fishspownPointx[(int)UnityEngine.Random.Range(0, 2)], globalField.fishSpownPoint.y, globalField.L_FISH), Quaternion.Euler(new Vector3(0, 0, 0)));
                    copyFish = (GameObject)Instantiate(fish, globalField.fishSpownPoint[(int)(Random.Range(0, globalField.fishSpownPoint.Length - 1))], Quaternion.Euler(new Vector3(0, 0, 0)));
                    copyFish.GetComponent<Transform>().SetParent(GameObject.Find("MainGame").GetComponent<Transform>());
                    //copyFish.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    globalField.spoNumFish.num += 1;
                    for (i = 0; i < globalField.spoNumFish.max; i++)
                    {
                        if (GameObject.Find("fish" + i) == null)
                        {
                            copyFish.name = "fish" + i;
                            break;
                        }
                    }
                    Debug.Log("fishSpownNum = " + globalField.spoNumFish.num);
                }
            }

        }
    }
}
