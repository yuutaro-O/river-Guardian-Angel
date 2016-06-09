using UnityEngine;
using System.Collections;

public class TrashMove : MonoBehaviour
{
    GameObject Trash;
    GlobalField globalField;
    float trashMoveSpd = 3.0f;
    // Use this for initialization
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalField.pouseFlg == false)
        {
            Trash = base.gameObject;
            Trash.GetComponent<Transform>().position += new Vector3(0.0f, -trashMoveSpd, 0.0f);
        }
    }
}
