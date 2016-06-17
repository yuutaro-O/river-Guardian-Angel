using UnityEngine;
using System.Collections;

public class StageLine : MonoBehaviour {
    byte lineNum = 10;
    Vector3[] Points = new Vector3[2];
    GameObject[] line = new GameObject[10];
    
    // Use this for initialization
    void Start () {
        lineNum = 10;
        for (int i = 0; i < lineNum; i++)
        {
            /*
            Line.name = "Line" + i;
            Line.AddComponent<LineRenderer>();
            Line.GetComponent<Transform>().SetParent(GameObject.Find("UILine").GetComponent<Transform>());
            Points[0] = Camera.main.ViewportToWorldPoint(new Vector3((float)(i / 10), 0.0f, GlobalField.globalField.L_LINE));
            Points[1] = Camera.main.ViewportToWorldPoint(new Vector3((float)(i / 10), 1.0f, GlobalField.globalField.L_LINE));
            Line.GetComponent<LineRenderer>().SetVertexCount(2);
            Line.GetComponent<LineRenderer>().SetWidth(0.5f, 0.5f);
            Line.GetComponent<LineRenderer>().SetPositions(Points);
            */
            line[i].name = "Line" + i;
            line[i].AddComponent<LineRenderer>();
            line[i].GetComponent<Transform>().SetParent(GameObject.Find("UILine").GetComponent<Transform>());
            //Points[0] = Camera.main.ScreenToWorldPoint(new Vector3((float)(i / 10),0.0f,GlobalField.globalField.L_LINE));
            //Points[1] = Camera.main.ScreenToWorldPoint(new Vector3((float)(i / 10), 1.0f, GlobalField.globalField.L_LINE));
            Points[0] = Camera.main.ViewportToWorldPoint(new Vector3((float)(i / 10), 0.0f, (float)GlobalField.LEYER.LINE));
            Points[1] = Camera.main.ViewportToWorldPoint(new Vector3((float)(i / 10), 1.0f, (float)GlobalField.LEYER.LINE));
            line[i].GetComponent<LineRenderer>().SetVertexCount(2);
            line[i].GetComponent<LineRenderer>().SetWidth(0.5f, 0.5f);
            line[i].GetComponent<LineRenderer>().SetPositions(Points);
            

        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
