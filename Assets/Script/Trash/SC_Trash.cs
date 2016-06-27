using UnityEngine;
using System.Collections;

public class SC_Trash : MonoBehaviour
{
    Rigidbody trashBody;
    float tagrad;
    float trashMoveSpd = 100.0f;
    // Use this for initialization
    void Start()
    {
        trashBody = base.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            Move();
            Destroy();
        }
        else
        {
            trashBody.velocity = new Vector3(0, 0, 0);
        }

    }

    void Move()
    {
        //transform.position += new Vector3(0.0f, -trashMoveSpd, 0.0f);
        trashBody.velocity = new Vector3(0.0f, -trashMoveSpd, 0.0f);
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

        Destroy(base.gameObject);
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            tagrad = Mathf.Atan2(other.gameObject.transform.position.y - transform.position.y, other.gameObject.transform.position.x - transform.position.x);
            transform.position += new Vector3(3.0f, 0, 0);
            //trashBody.velocity = new Vector3((Mathf.Cos(tagrad) * trashMoveSpd) * -1, 0, 0);
            //trashBody.AddForce(new Vector3((Mathf.Cos(tagrad) * trashMoveSpd), 0, 0));
        }
    }
}
