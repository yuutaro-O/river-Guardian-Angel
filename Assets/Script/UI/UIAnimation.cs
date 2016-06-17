using UnityEngine;
using System.Collections;

public class UIAnimation : MonoBehaviour
{
    float scaleBairitu;

    // Use this for initialization
    void Start()
    {
        scaleBairitu = (float)(((base.gameObject.transform.lossyScale.x * 100) / GlobalField.globalField.rockPlaceSecond) * 0.01);

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            /*
            if (GlobalField.globalField.placeSecondCnt == GlobalField.globalField.rockPlaceSecond)
            {

            }
            else
            {
                //scaleBairitu = ((GlobalField.globalField.rockPlaceSecond * -1) + GlobalField.globalField.placeSecondCnt);
            }
            */
            //Debug.Log(base.gameObject.transform.FindChild("inside").gameObject);
            //Debug.Log(base.gameObject);
            //Debug.Log(base.gameObject.transform);
            //Debug.Log(base.gameObject.transform.FindChild("inSide"));

            (base.gameObject.transform.FindChild("inSide").gameObject.transform.localScale) = (new Vector3(GlobalField.globalField.placeSecondCnt * scaleBairitu, GlobalField.globalField.placeSecondCnt * scaleBairitu, 0));
            //scaleBairitu++;
        }
    }
}
