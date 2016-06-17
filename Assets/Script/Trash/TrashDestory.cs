using UnityEngine;
using System.Collections;

public class TrashDestory : MonoBehaviour
{
    Vector3 tagViewport;
    //GameObject screenCamera;
    // Use this for initialization

    void Start()
    {
        //screenCamera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            //tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
            //Debug.Log(base.gameObject);
            //Debug.Log(base.gameObject.GetComponent<Transform>().position.y);
            //画面上部に到達すると敵が消滅
            //if (tagViewport.y > 1)

            if (base.gameObject.GetComponent<Transform>().position.y <= GlobalField.globalField.destroyPoint[GlobalField.globalField.TRASH])
            {
                TrashDelete(base.gameObject);
                //Destroy(gameObject);
                //
            }

            //Debug.Log(fish);
        }
    }

    public void TrashDelete(GameObject deleter)
    {
        Destroy(deleter);
        GlobalField.globalField.spoNumTrash.num -= 1;   //バグ発生
        Debug.Log("TrashSpownNum = " + GlobalField.globalField.spoNumTrash.num);
    }
}
