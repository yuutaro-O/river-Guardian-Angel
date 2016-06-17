using UnityEngine;
using System.Collections;

public class TrashCreation : MonoBehaviour
{
    [SerializeField]
    int basePoint;
    int i;
    public GameObject trash;

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            if (Random.Range(0, 100) >= basePoint)
            {
                if (GlobalField.globalField.waveFish.num < GlobalField.globalField.waveFish.max)
                {
                    if (GlobalField.globalField.spoNumTrash.num < GlobalField.globalField.spoNumTrash.max)
                    {
                        for (i = 0; i < GlobalField.globalField.spoNumTrash.max; i++)
                        {
                            if (GlobalField.globalField.Trash[i] == null)
                            {
                                GlobalField.globalField.Trash[i] = (GameObject)Instantiate(trash, GlobalField.globalField.trashSpownPoint[Random.Range(0, GlobalField.globalField.trashSpownPoint.Length - 1)], Quaternion.Euler(new Vector3(0, 0, 0)));
                                GlobalField.globalField.Trash[i].name = "trash" + i;

                                GlobalField.globalField.spoNumTrash.num += 1;
                                Debug.Log("trashSpownNum = " + GlobalField.globalField.spoNumTrash.num);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
