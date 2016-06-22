using UnityEngine;
using System.Collections;

public class SC_UILife : MonoBehaviour
{
    void Start()
    {

    }
    public void LifeBreaking()
    {
        Destroy(base.gameObject);
    }
}
