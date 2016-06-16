using UnityEngine;
using System.Collections;

public class UIFishLife : MonoBehaviour {
    public GlobalField globalField;
    public int MaxLife;
    Vector3 tagViewport;
    public GameObject Life;
    public GameObject[] copyLife;

    UIFishLife()
    {
        
        //copyLife = new GameObject[globalField.life.max];

    }
    
	// Use this for initialization
	void Start () {
        
        
        Debug.Log(globalField);
    }
	
	// Update is called once per frame
	void Update () {
        
            tagViewport = Camera.main.WorldToViewportPoint(base.transform.position);
            /*
            for (i = globalField.life.num;i > 0; i--)
            {
                Camera.main.ViewportToWorldPoint(new Vector3((float)(0.96 - (i * 0.03)), 0.95f, globalField.L_UILIFE));
            }
            */
    }

    public void LifeInstanciate()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
        //copyLife = new GameObject[globalField.life.num];
        for (int i = 0; i < globalField.life.num;i++)
        {
            copyLife[i] = (GameObject)Instantiate(Life, Camera.main.ViewportToWorldPoint(new Vector3((float)(0.985 - (i * 0.035)), 0.05f, (float)GlobalField.LEYER.UILIFE)), Quaternion.Euler(0, 0, 0));
           Debug.Log("copyLifePosition" + copyLife[i].GetComponent<Transform>().position);
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
