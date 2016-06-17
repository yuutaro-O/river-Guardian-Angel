using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveDraw : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        base.gameObject.GetComponent<Text>().text = GlobalField.globalField.wave.ToString();
    }
}
