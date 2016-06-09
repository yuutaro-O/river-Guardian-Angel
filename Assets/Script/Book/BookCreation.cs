using UnityEngine;
using System.Collections;

public class BookCreation : MonoBehaviour {
    [SerializeField]
    int basePoint;
    int i;
    public GameObject book;
    GameObject copyBook;
    GlobalField globalField;
    // Use this for initialization
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalField.pouseFlg == false)
        {
            if (Random.Range(0, 100) >= basePoint)
            {
                if (globalField.spoNumBook.num < globalField.spoNumBook.max)
                {
                    copyBook = (GameObject)Instantiate(book, globalField.trashSpownPoint[Random.Range(0, globalField.trashSpownPoint.Length - 1)], Quaternion.Euler(new Vector3(0, 0, 0)));
                    for (i = 0; i < globalField.spoNumBook.max; i++)
                    {
                        if (GameObject.Find("book" + i) == null)
                        {
                            copyBook.name = "book" + i;
                            break;
                        }
                    }
                    globalField.spoNumBook.num += 1;
                    Debug.Log("trashSpownNum = " + globalField.spoNumBook.num);
                }
            }
        }
    }
}
