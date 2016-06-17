using UnityEngine;
using System.Collections;

public class UIFishLife : MonoBehaviour {
    public int MaxLife;
    Vector3 tagViewport;
    public GameObject Life;
    public GameObject[] copyLife;

    UIFishLife()
    {
        
        //copyLife = new GameObject[GlobalField.globalField.life.max];

    }
    

    public void LifeInstanciate()
    {
        tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
        //copyLife = new GameObject[GlobalField.globalField.life.num];
        for (int i = 0; i < GlobalField.globalField.life.num;i++)
        {
            copyLife[i] = (GameObject)Instantiate(Life, Camera.main.ViewportToWorldPoint(new Vector3((float)(0.97 - (i * 0.045)), 0.05f, (float)GlobalField.LEYER.UILIFE)), Quaternion.Euler(0, 0, 0));
        }
    }
    public void LifeBreaking(int index)
    {
        if (index >= 0)
        {
            Debug.Log("copylife[" + index + "] = "  + copyLife[index]);

            Destroy(copyLife[index]);
        }
    }
    
}
