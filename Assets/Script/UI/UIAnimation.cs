using UnityEngine;
using System.Collections;
public class UIAnimation : MonoBehaviour
{
    float scaleBairitu;
    void Start()
    {
        scaleBairitu = (float)(((base.gameObject.transform.lossyScale.x * 100) / GlobalField.globalField.rockPlaceSecond) * 0.01);
    }
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            (base.gameObject.transform.FindChild("inSide").gameObject.transform.localScale) = (new Vector3(GlobalField.globalField.placeSecondCnt * scaleBairitu, GlobalField.globalField.placeSecondCnt * scaleBairitu, 0));
        }
    }
}
