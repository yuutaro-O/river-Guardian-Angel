using UnityEngine;
using System.Collections;

public class TrashMove : MonoBehaviour
{
    GameObject Trash;
    float trashMoveSpd = 3.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            Trash = base.gameObject;
            Trash.transform.position += new Vector3(0.0f, -trashMoveSpd, 0.0f);
        }
    }
}
