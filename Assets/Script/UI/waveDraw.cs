using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveDraw : MonoBehaviour {
    void Update()
    {
        base.gameObject.GetComponent<Text>().text = GlobalField.globalField.wave.ToString();
    }
}
