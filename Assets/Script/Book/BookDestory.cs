using UnityEngine;
using System.Collections;

public class BookDestory : MonoBehaviour {
    Vector3 tagViewport;
    GlobalField globalField;
    //GameObject screenCamera;
    // Use this for initialization

    void Start()
    {
        //screenCamera = GetComponent<Camera>();
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();

    }

    // Update is called once per frame
    void Update()
    {

        //tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
        //Debug.Log(base.gameObject);
        //Debug.Log(base.gameObject.GetComponent<Transform>().position.y);
        //画面上部に到達すると敵が消滅
        //if (tagViewport.y > 1)

        if (base.gameObject.GetComponent<Transform>().position.y <= globalField.destroyPoint[globalField.TRASH])
        {
            BookDelete(base.gameObject);
            //Destroy(gameObject);
            //
        }

        //Debug.Log(fish);
    }
    public void BookDelete(GameObject deleter)
    {
        Destroy(deleter);
        globalField.spoNumBook.num -= 1;
        Debug.Log("bookSpownNum = " + globalField.spoNumBook.num);
    }
}
