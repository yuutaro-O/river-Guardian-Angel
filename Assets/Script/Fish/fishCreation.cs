using UnityEngine;
using System.Collections;

public class fishCreation : MonoBehaviour
{
    [SerializeField]
    short basePoint;
    public GameObject fish;
    public GameObject copyFish;
    GlobalField globalField;
    [SerializeField]
    SceneManager sceneManager;
    [SerializeField]
    Transform mainGame;
    WaveManager waveManager;
    int i;
    // Use this for initialization
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
        waveManager = GameObject.FindGameObjectWithTag("SpownPoint").GetComponent<WaveManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneManager.GetNowScene() == (byte)SceneManager.scene.MAINGAME) {
            if (globalField.pouseFlg == false && waveManager.GetPouseStats() == false)
            {
                if (UnityEngine.Random.Range(0, 10000) >= basePoint)
                {
                    if (globalField.waveFish.num < globalField.waveFish.max)
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
                            //copyFish = (GameObject)Instantiate(fish, globalField.fishSpownPoint[(int)(Random.Range(0, globalField.fishSpownPoint.Length - 1))], Quaternion.Euler(new Vector3(0, 0, 0)));
                            copyFish = (GameObject)Instantiate(fish, globalField.fishSpownPoint[(int)(Random.Range(0, globalField.fishSpownPoint.Length - 1))], fish.transform.rotation);
                            copyFish.GetComponent<SCFish>().FishSpown();
                            copyFish.transform.SetParent(mainGame);
                            //copyFish.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            globalField.spoNumFish.num += 1;
                            globalField.waveFish.num += 1;
                            for (i = 0; i < globalField.spoNumFish.max; i++)
                            {
                                if (GameObject.Find("fish" + i) == null)
                                {
                                    copyFish.name = "fish" + i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void spownFish()
    {

    }
}
