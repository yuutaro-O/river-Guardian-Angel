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
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
        waveManager = GameObject.FindGameObjectWithTag("SpownPoint").GetComponent<WaveManager>();
    }
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
                            copyFish = (GameObject)Instantiate(fish, globalField.fishSpownPoint[(int)(Random.Range(0, globalField.fishSpownPoint.Length - 1))], fish.transform.rotation);
                            copyFish.GetComponent<SCFish>().FishSpown();
                            copyFish.transform.SetParent(mainGame);
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
}
