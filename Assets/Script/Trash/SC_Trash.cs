using UnityEngine;
using System.Collections;

public class SC_Trash : MonoBehaviour
{

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
            Move();
            Destroy();
        }

    }

    void Move()
    {
            transform.position += new Vector3(0.0f, -trashMoveSpd, 0.0f);
    }

    void Destroy()
    {
            //tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
            //Debug.Log(base.gameObject);
            //Debug.Log(base.gameObject.GetComponent<Transform>().position.y);
            //画面上部に到達すると敵が消滅
            //if (tagViewport.y > 1)

            if (base.gameObject.transform.position.y <= GlobalField.globalField.destroyPoint[GlobalField.globalField.TRASH])
            {
                TrashDelete();
                //Destroy(gameObject);
                //
            }

            //Debug.Log(fish);
    }
    public void TrashDelete()
    {
        GlobalField.globalField.spoNumTrash.num -= 1;   //バグ発生
        Debug.Log("TrashSpownNum = " + GlobalField.globalField.spoNumTrash.num);
        Destroy(base.gameObject);
    }
}
