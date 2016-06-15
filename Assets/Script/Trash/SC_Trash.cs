using UnityEngine;
using System.Collections;

public class SC_Trash : MonoBehaviour
{
    GlobalField globalField;
    GameObject Trash;
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
            Move();
            Destroy();
        }

    }

    void Move()
    {
            Trash = base.gameObject;
            Trash.GetComponent<Transform>().position += new Vector3(0.0f, -trashMoveSpd, 0.0f);
    }

    void Destroy()
    {
            //tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
            //Debug.Log(base.gameObject);
            //Debug.Log(base.gameObject.GetComponent<Transform>().position.y);
            //画面上部に到達すると敵が消滅
            //if (tagViewport.y > 1)

            if (base.gameObject.GetComponent<Transform>().position.y <= globalField.destroyPoint[globalField.TRASH])
            {
                TrashDelete(base.gameObject);
                //Destroy(gameObject);
                //
            }

            //Debug.Log(fish);
    }
    public void TrashDelete(GameObject deleter)
    {
        Destroy(deleter);
        globalField.spoNumTrash.num -= 1;   //バグ発生
        Debug.Log("TrashSpownNum = " + globalField.spoNumTrash.num);
    }
}
