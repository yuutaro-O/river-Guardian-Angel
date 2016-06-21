using UnityEngine;
using System.Collections;
//[RequireComponent (typeof(Camera))]
public class fishBreak : MonoBehaviour {
    Vector3 tagViewport;
    GlobalField globalField;
    //[SerializeField]
    //GameObject fish;
    //GameObject screenCamera;
    // Use this for initialization

    void Start () {
        //screenCamera = GetComponent<Camera>();
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();

    }
	
	// Update is called once per frame
	void Update () {
        if (globalField.pouseFlg == false)
        {
            //tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
            //Debug.Log(base.gameObject);
            //Debug.Log(base.gameObject.GetComponent<Transform>().position.y);
            //画面上部に到達すると敵が消滅
            //if (tagViewport.y > 1)

            if (base.gameObject.transform.position.y >= globalField.destroyPoint[globalField.FISH])
            {
                FishDelete(base.gameObject);
                
                globalField.score += 1;
            }

            //Debug.Log(fish);
        }
    }

    public void FishDelete(GameObject deleter)
    {
        Destroy(deleter);
        globalField.spoNumFish.num -= 1;
        Debug.Log("fishSpownNum = " + globalField.spoNumFish.num);
    }
}
