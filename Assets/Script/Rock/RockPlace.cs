using UnityEngine;
using System.Collections;

public class RockPlace : MonoBehaviour
{
    Vector2 mousePoint;
    bool pushFlg;
    //int placeSecondCnt;
    //GameObject globalField;
    [SerializeField]
    GameObject rock;
    public GameObject tapPoint;
    GameObject UIAdress;
    bool isTouchUIActive = false;
    GameObject copyRock;
    Vector3 placePoint;

    int i;

    const string STR_ROCK = "rock";

    [SerializeField]
    int deActiveWave;
    [SerializeField]
    int reActiveWave;
    // Use this for initialization
    void Start()
    {
        i = 0;
    }
    
    public void WaveRockPlacing()
    {
        if (GlobalField.globalField.wave >= reActiveWave || GlobalField.globalField.wave <= deActiveWave)
        {
            for (int i = 0; i < GlobalField.globalField.spoNumRock.max; i++)
            {
                GlobalField.globalField.Rock[i] = RockPlacing();
            }
        }
    }
    public GameObject RockPlacing()
    {
        
        GameObject ret;
        placePoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.15f, 0.85f), Random.Range(0.2f, 0.8f), (float)GlobalField.LEYER.ROCK));

        ret = (GameObject)Instantiate(rock, placePoint, rock.transform.rotation);
        ret.transform.position = new Vector3(ret.transform.position.x, ret.transform.position.y,(float)GlobalField.LEYER.ROCK);
        return ret;
    }
}
