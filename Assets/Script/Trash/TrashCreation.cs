using UnityEngine;
using System.Collections;

public class TrashCreation : MonoBehaviour
{
    [SerializeField]
    int basePoint;
    int i;
    public GameObject trash;
    GameObject copyTrash;
    GlobalField globalField;
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
            if (Random.Range(0, 100) >= basePoint)
            {
                if (globalField.waveFish.num < globalField.waveFish.max)
                {
                    if (globalField.spoNumTrash.num < globalField.spoNumTrash.max)
                    {
                        copyTrash = (GameObject)Instantiate(trash, globalField.trashSpownPoint[Random.Range(0, globalField.trashSpownPoint.Length - 1)], Quaternion.Euler(new Vector3(0, 0, 0)));
                        for (i = 0; i < globalField.spoNumTrash.max; i++)
                        {
                            if (GameObject.Find("trash" + i) == null)
                            {
                                copyTrash.name = "trash" + i;
                                break;
                            }
                        }
                        globalField.spoNumTrash.num += 1;
                        Debug.Log("trashSpownNum = " + globalField.spoNumTrash.num);
                    }
                }
            }
        }
    }
}
