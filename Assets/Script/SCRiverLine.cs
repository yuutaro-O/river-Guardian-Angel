using UnityEngine;
using System.Collections;

public class SCRiverLine : MonoBehaviour {
    [SerializeField]
    float defspd;       //元々持つスピード値
    float randspd;      //乱数で持つ追加のスピード値

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalField.globalField.pouseFlg == false)
        {
            transform.position += new Vector3(0, -(defspd + randspd), 0);
            if (transform.position.y < GlobalField.globalField.destroyPoint[GlobalField.globalField.TRASH] - (transform.lossyScale.y / GlobalField.globalField.SCALEDIFFRENCIAL))
            {
                Reroute();
            }
        }
	}

    void Reroute()
    {
        transform.position = new Vector3(transform.position.x, GlobalField.globalField.destroyPoint[GlobalField.globalField.FISH] + (transform.lossyScale.y / GlobalField.globalField.SCALEDIFFRENCIAL),(float)GlobalField.LEYER.LINE);
    }

    public void DeleteObject()
    {
        Destroy(base.gameObject);
    }

    public void SetRandSpd(float tRndSpd)
    {
        randspd = tRndSpd;
    }
}
