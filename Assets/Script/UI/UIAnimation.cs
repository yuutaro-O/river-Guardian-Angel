using UnityEngine;
using System.Collections;

public class UIAnimation : MonoBehaviour
{
    GlobalField globalField;
    float scaleBairitu;

    // Use this for initialization
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
        scaleBairitu = (float)(((base.gameObject.transform.lossyScale.x * 100) / globalField.rockPlaceSecond) * 0.01);

    }

    // Update is called once per frame
    void Update()
    {
        if (globalField.pouseFlg == false)
        {
            /*
            if (globalField.placeSecondCnt == globalField.rockPlaceSecond)
            {

            }
            else
            {
                //scaleBairitu = ((globalField.rockPlaceSecond * -1) + globalField.placeSecondCnt);
            }
            */
            //Debug.Log(base.gameObject.transform.FindChild("inside").gameObject);
            //Debug.Log(base.gameObject);
            //Debug.Log(base.gameObject.transform);
            //Debug.Log(base.gameObject.transform.FindChild("inSide"));

            (base.gameObject.transform.FindChild("inSide").gameObject.transform.localScale) = (new Vector3(globalField.placeSecondCnt * scaleBairitu, globalField.placeSecondCnt * scaleBairitu, 0));
            //scaleBairitu++;
        }
    }
}
