using UnityEngine;
using System.Collections;
public class RockPlace : MonoBehaviour
{
    Vector2 mousePoint;
    bool pushFlg;
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
    bool[] RockPlacexflg;
    void Start()
    {
        i = 0;
        RockPlacexflg = new bool[GlobalField.globalField.spownPointx.Length];
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
        int placePointx = Random.Range(0, GlobalField.globalField.spownPointx.Length);
        if(RockPlacexflg[placePointx] == true)
        {
            for(int i = 0;i < RockPlacexflg.Length; i++)
            {
                if (RockPlacexflg[i] == false) {
                    placePointx = i;
                    break;
                }
            }
        }
        GameObject ret;
        placePoint = Camera.main.ViewportToWorldPoint(new Vector3(GlobalField.globalField.spownPointx[placePointx], Random.Range(0.2f, 0.8f), (float)GlobalField.LEYER.ROCK));
        ret = (GameObject)Instantiate(rock, placePoint, rock.transform.rotation);
        ret.transform.position = new Vector3(ret.transform.position.x, ret.transform.position.y,(float)GlobalField.LEYER.ROCK);
        RockPlacexflg[placePointx] = true;
        return ret;
    }
    public void ResetRockPoint()
    {
        for(int i = 0;i < RockPlacexflg.Length; i++)
        {
            RockPlacexflg[i] = false;
        }
    }
}