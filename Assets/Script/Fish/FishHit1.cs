using UnityEngine;
using System.Collections;

public class FishHit1 : MonoBehaviour {
    GameObject Fish;
    
    //魚の座標
    Vector3 fishCenterCoord;
    Vector3 fishScale;
    //岩の座標
    Vector3 rockCenterCoord;
    Vector3 rockScale;
    GameObject Rock;
    //ゴミの座標
    Vector3 trashCenterCoord;
    Vector3 trashScale;
    GameObject Trash;
    //本の座標
    Vector3 bookCenterCoord;
    Vector3 bookScale;
    GameObject Book;
    int i;

    UIFishLife uiFishLife; //スポナースクリプト
	// Use this for initialization
	void Start () {
        uiFishLife = GameObject.Find("SpownPoint").GetComponent<UIFishLife>();
	}

    // Update is called once per frame
    void Update()
    {

        Fish = base.gameObject;
        fishCenterCoord = Fish.GetComponent<Transform>().position;
        //fishScale = Fish.GetComponent<BoxCollider>().size;
        fishScale = (Fish.GetComponent<Transform>().lossyScale) / GlobalField.globalField.SCALEDIFFRENCIAL;

        //Debug.Log(fishCenterCoord);
        Debug.Log("fishScale = "+fishScale);

        //Debug.Log(GlobalField.globalField.rockPlaceNum);
        for (i = 0; i < GlobalField.globalField.spoNumRock.num; i++)
        {

            if((Rock = GameObject.Find("rock" + i)) == null) {
                continue;
            }
            rockCenterCoord = Rock.GetComponent<Transform>().position;
            rockScale = (Rock.GetComponent<Transform>().lossyScale) / GlobalField.globalField.SCALEDIFFRENCIAL;
            //rockScale = Rock.GetComponent<BoxCollider>().size;



            //Debug.Log(rockCenterCoord);
            Debug.Log("RockScale = "+rockScale);

            if (fishCenterCoord.x - ((fishScale.x) / 2) <= rockCenterCoord.x + ((rockScale.x) / 2) &&
                fishCenterCoord.x + ((fishScale.x) / 2) >= rockCenterCoord.x - ((rockScale.x) / 2) &&
                fishCenterCoord.y - ((fishScale.y) / 2) <= rockCenterCoord.y + ((rockScale.y) / 2) &&
                fishCenterCoord.y + ((fishScale.y) / 2) >= rockCenterCoord.y - ((rockScale.y) / 2) + GlobalField.globalField.avoidDist)
            ////if (fishCenterCoord.x <= rockCenterCoord.x + (Rock.transform.lossyScale.x) &&
            ////    fishCenterCoord.x + (Fish.transform.lossyScale.x) >= rockCenterCoord.x &&
            ////    fishCenterCoord.y - (Fish.transform.lossyScale.y) <= rockCenterCoord.y &&
            ////    fishCenterCoord.y >= rockCenterCoord.y - (Rock.transform.lossyScale.y))

            {
                Debug.Log("Hit " + Fish + " to " + Rock);
                if (fishCenterCoord.x > rockCenterCoord.x) {
                    Fish.GetComponent<Transform>().position += new Vector3(GlobalField.globalField.avoidSpeed, 0.0f, 0.0f);
                }
                else
                {
                    Fish.GetComponent<Transform>().position += new Vector3(-(GlobalField.globalField.avoidSpeed), 0.0f, 0.0f);
                }
            }

        }
        if (GlobalField.globalField.invincible == false)
        {
            for (i = 0; i < GlobalField.globalField.spoNumTrash.max; i++)
            {
                if ((Trash = GameObject.Find("trash" + i)) == null)
                {
                    continue;
                }
                trashCenterCoord = Trash.GetComponent<Transform>().position;
                //trashScale = Trash.GetComponent<BoxCollider>().size;
                trashScale = Trash.GetComponent<Transform>().lossyScale / GlobalField.globalField.SCALEDIFFRENCIAL;
                if (fishCenterCoord.x - ((fishScale.x) / 2) <= trashCenterCoord.x + ((trashScale.x) / 2) - GlobalField.globalField.grazeDist &&
                    fishCenterCoord.x + ((fishScale.x) / 2) >= trashCenterCoord.x - ((trashScale.x) / 2) + GlobalField.globalField.grazeDist &&
                    fishCenterCoord.y - ((fishScale.y) / 2) <= trashCenterCoord.y + ((trashScale.y) / 2) - GlobalField.globalField.grazeDist &&
                    fishCenterCoord.y + ((fishScale.y) / 2) >= trashCenterCoord.y - ((trashScale.y) / 2) + GlobalField.globalField.grazeDist)
                {
                    Fish.GetComponent<fishBreak>().FishDelete(Fish);
                    Trash.GetComponent<TrashDestory>().TrashDelete(Trash);
                    //uiFishLife.LifeBreaking(GlobalField.globalField.life.num - 1);
                    GlobalField.globalField.UILife[GlobalField.globalField.life.num - 1].GetComponent<SCFish>().FishDelete();
                    GlobalField.globalField.life.num -= 1;
                    Debug.Log("life =" + GlobalField.globalField.life.num);
                }
            }
        }

        for(i = 0;i < GlobalField.globalField.spoNumBook.max; i++)
        {
            if ((Book = GameObject.Find("book" + i)) == null){
                continue;
            }
            bookCenterCoord = Book.GetComponent<Transform>().position;
            bookScale = Book.GetComponent<BoxCollider>().size;
            if (fishCenterCoord.x - ((fishScale.x) / 2) <= bookCenterCoord.x + ((bookScale.x) / 2) &&
                fishCenterCoord.x + ((fishScale.x) / 2) >= bookCenterCoord.x - ((bookScale.x) / 2) &&
                fishCenterCoord.y - ((fishScale.y) / 2) <= bookCenterCoord.y + ((bookScale.y) / 2) &&
                fishCenterCoord.y + ((fishScale.y) / 2) >= bookCenterCoord.y - ((bookScale.y) / 2))
                
            Book.GetComponent<BookDestory>().BookDelete(Book);
        }
    }
}


