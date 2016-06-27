using UnityEngine;
using System.Collections;

public class SC_Trash : MonoBehaviour
{
    Rigidbody trashBody;
    float tagrad;
    float trashMoveSpd = 100.0f;
    void Start()
    {
        trashBody = base.gameObject.GetComponent<Rigidbody>();
    }
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
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
    }
    void Move()
    {
        trashBody.velocity = new Vector3(0.0f, -trashMoveSpd, 0.0f);
    }
    void Destroy()
    {
            if (base.gameObject.transform.position.y <= GlobalField.globalField.destroyPoint[GlobalField.globalField.TRASH])
            {
                TrashDelete();
            }
    }
    public void TrashDelete()
    {
        GlobalField.globalField.spoNumTrash.num -= 1;

        Destroy(base.gameObject);
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            tagrad = Mathf.Atan2(other.gameObject.transform.position.y - transform.position.y, other.gameObject.transform.position.x - transform.position.x);
            transform.position += new Vector3(3.0f, 0, 0);
<<<<<<< HEAD
=======
            //trashBody.velocity = new Vector3((Mathf.Cos(tagrad) * trashMoveSpd) * -1, 0, 0);
            //trashBody.AddForce(new Vector3((Mathf.Cos(tagrad) * trashMoveSpd), 0, 0));
>>>>>>> 294da04... 完成ビルド前の作業保存
        }
    }
}
