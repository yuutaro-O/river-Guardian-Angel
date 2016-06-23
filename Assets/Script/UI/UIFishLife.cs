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
        for (int i = 0; i < GlobalField.globalField.GetLife();i++)
        {
            GlobalField.globalField.UILife[i] = (GameObject)Instantiate(Life, Camera.main.ViewportToWorldPoint(new Vector3((float)(0.97 - (i * 0.045)), 0.05f, (float)GlobalField.LEYER.UILIFE)), Quaternion.Euler(0, 0, 0));
        }
    }
    

    public void AllLifeBreaking()
    {
        //GameObject[] UI_Life = new GameObject[GlobalField.globalField.life.max];

        //UI_Life = GameObject.FindGameObjectsWithTag("UILife");

        //for(int i = 0;i < UI_Life.Length; i++)
        for(int i = 0; i < GlobalField.globalField.UILife.Length; i++) 
        {
            //Destroy(UI_Life[i].gameObject);
            Destroy(GlobalField.globalField.UILife[i]);
        }
    }
    
}
