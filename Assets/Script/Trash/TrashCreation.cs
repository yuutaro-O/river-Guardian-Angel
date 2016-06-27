using UnityEngine;
using System.Collections;

public class TrashCreation : MonoBehaviour
{
    [SerializeField]
    short basePoint;
    [SerializeField]
    int activeWave;
    bool TrashCreatable;
    int i;
    int j;
    public GameObject trash;
    SceneManager sceneManager;
<<<<<<< HEAD
=======

    // Update is called once per frame
>>>>>>> 294da04... 完成ビルド前の作業保存
    void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
    }
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
    void Update()
    {
        if (sceneManager.GetNowScene() == (byte)SceneManager.scene.MAINGAME)
        {
            TrashCreatable = true;
            if (GlobalField.globalField.pouseFlg == false)
            {
                if (Random.Range(0, 10000) >= basePoint)
                {
                    if (GlobalField.globalField.waveFish.num < GlobalField.globalField.waveFish.max)
                    {
                        if (GlobalField.globalField.spoNumTrash.num < GlobalField.globalField.spoNumTrash.max)
                        {
                            if (GlobalField.globalField.wave >= activeWave)
                            {
                                for (j = 0; j < GlobalField.globalField.Fish.Length; j++)
                                {
                                    if (GlobalField.globalField.Fish[j] == null)
                                    {
                                        continue;
                                    }
                                    if (GlobalField.globalField.Fish[j].transform.position.y > GlobalField.globalField.TRASHSPOWNINACTIVEPOINT)
                                    {
                                        TrashCreatable = false;
                                    }
                                }
                                if (TrashCreatable == true)
                                {
                                    for (i = 0; i < GlobalField.globalField.spoNumTrash.max; i++)
                                    {
                                        if (GlobalField.globalField.Trash[i] == null)
                                        {
                                            TrashCreate();
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }

    public void TrashCreate()
    {
        GlobalField.globalField.Trash[i] = (GameObject)Instantiate(trash, GlobalField.globalField.trashSpownPoint[Random.Range(0, GlobalField.globalField.trashSpownPoint.Length - 1)], Quaternion.Euler(new Vector3(0, 0, 0)));
        GlobalField.globalField.Trash[i].name = "trash" + i;
        GlobalField.globalField.spoNumTrash.num += 1;
    }
}
