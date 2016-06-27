using UnityEngine;
using System.Collections;

public class SC_Rock : MonoBehaviour {

	public void deleteRock()
    {
        GlobalField.globalField.spoNumRock.num -= 1;
        Destroy(base.gameObject);
    }
}
