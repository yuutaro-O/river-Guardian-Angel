using UnityEngine;
using System.Collections;

public class SCFish : MonoBehaviour
{
    GlobalField globalField;
    //from FishHit
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
    //fromMove
    [SerializeField]
    float defSpd;  //魚のy軸下り移動速度、将来削除予定
    float[] yspeed = new float[2];  //魚のy軸移動速度　０…上り速度　１…下り速度

    float spd = 2.0f;             //魚の移動速度
    int healcnt = 0;                //魚回復用のカウント
    int healcost = 0;               //魚が滝から落ちた際に、回復に必要とする時間
    bool myDirecDown;               //魚の進行方向が下りかどうか
    short chanceFishFall = 50;      //魚が滝から落ちない確率、整数型で、100.00%を10000として記述 //テストデータ0.5%
    public GameObject fish;         //自分自身のアドレス
    GameObject copyBite;            //エサに引き寄せる際に、えさのアドレスを持っておく
    float tagrad;            //エサをターゲットとした、ラジアン角
    // Use this for initialization
    void Start()
    {
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
        uiFishLife = GameObject.Find("SpownPoint").GetComponent<UIFishLife>();

        yspeed[0] = defSpd; //上るときの速度
        yspeed[1] = 2.0f;   //下るときの速度
        myDirecDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalField.pouseFlg == false)
        {
            HitJudge();
            Move();
            BreakJudge();
        }
    }
    void Move()
    {
        tagrad = 0.0f;
        /*
        //画面上部に行った時、方向転換
        if (fish.transform.position.y >= globalField.trunPoint){
            myDirecDown = true;
        }
        */
        //rockjudge();
        for (int i = 0; i < globalField.spoNumBite.max; i++)
        {

            if ((copyBite = GameObject.Find("bite" + i)) == null)
            {
                continue;
            }

            copyBite = GameObject.Find("bite" + i);
            tagrad = Mathf.Atan2(fish.GetComponent<Transform>().position.y - copyBite.GetComponent<Transform>().position.y, fish.GetComponent<Transform>().position.x - copyBite.GetComponent<Transform>().position.x);
            fish.GetComponent<Transform>().position -= new Vector3(Mathf.Cos(tagrad) * spd, 0, 0);
        }

        //移動
        if (myDirecDown == true)
        {
            fish.transform.position += new Vector3(0, -yspeed[1], 0);
        }
        else
        {
            fish.transform.position += new Vector3(0, yspeed[0], 0);
        }
        //まれに魚が滝を登れずに、少し落ちる
        if (GetComponent<Transform>().position.y > globalField.Maincamera.GetComponent<Transform>().position.y)
        {
            if (Random.Range(0, 10000) < chanceFishFall)
            {
                myDirecDown = true;
                healcost = Random.Range(30, 90);
            }
        }
        if (myDirecDown == true)
        {
            healcnt++;
            if (healcnt > healcost)
            {
                myDirecDown = false;
                healcnt = 0;
            }
        }
    }
    void BreakJudge()
    {
        if (base.gameObject.GetComponent<Transform>().position.y >= globalField.destroyPoint[globalField.FISH])
        {
            FishDelete(base.gameObject);

            globalField.score += 1;
        }
    }

    void HitJudge()
    {
        Fish = base.gameObject;
        fishCenterCoord = Fish.GetComponent<Transform>().position;
        //fishScale = Fish.GetComponent<BoxCollider>().size;
        fishScale = (Fish.GetComponent<Transform>().lossyScale) / globalField.SCALEDIFFRENCIAL;

        //Debug.Log(fishCenterCoord);
        Debug.Log("fishScale = " + fishScale);

        RockHit();
        if (globalField.invincible == false)
        {
            TrashHit();
        }
    }
    void RockHit()  //非常に動作が重い関数
    {
        //Debug.Log(globalField.rockPlaceNum);
        for (i = 0; i < globalField.spoNumRock.num; i++)
        {

            if (globalField.Rock[i] == null)
            {
                continue;
            }
            rockCenterCoord = globalField.Rock[i].transform.position;
            rockScale = (globalField.Rock[i].transform.lossyScale) / globalField.SCALEDIFFRENCIAL;
            //rockScale = Rock.GetComponent<BoxCollider>().size;



            //Debug.Log(rockCenterCoord);
            /*
            if (fishCenterCoord.x - ((fishScale.x) / 2) <= rockCenterCoord.x + ((rockScale.x) / 2) &&
                fishCenterCoord.x + ((fishScale.x) / 2) >= rockCenterCoord.x - ((rockScale.x) / 2) &&
                fishCenterCoord.y - ((fishScale.y) / 2) <= rockCenterCoord.y + ((rockScale.y) / 2) &&
                fishCenterCoord.y + ((fishScale.y) / 2) >= rockCenterCoord.y - ((rockScale.y) / 2) + globalField.avoidDist)
            ////if (fishCenterCoord.x <= rockCenterCoord.x + (Rock.transform.lossyScale.x) &&
            ////    fishCenterCoord.x + (Fish.transform.lossyScale.x) >= rockCenterCoord.x &&
            ////    fishCenterCoord.y - (Fish.transform.lossyScale.y) <= rockCenterCoord.y &&
            ////    fishCenterCoord.y >= rockCenterCoord.y - (Rock.transform.lossyScale.y))

            {
                Debug.Log("Hit " + Fish + " to " + Rock);
                if (fishCenterCoord.x > rockCenterCoord.x)
                {
                    Fish.GetComponent<Transform>().position += new Vector3(globalField.avoidSpeed, 0.0f, 0.0f);
                }
                else
                {
                    Fish.GetComponent<Transform>().position += new Vector3(-globalField.avoidSpeed, 0.0f, 0.0f);
                }
            }
            */
        }
    }
    void TrashHit()
    {

        for (i = 0; i < globalField.spoNumTrash.max; i++)
        {
            if ((Trash = GameObject.Find("trash" + i)) == null)
            {
                continue;
            }
            trashCenterCoord = Trash.GetComponent<Transform>().position;
            //trashScale = Trash.GetComponent<BoxCollider>().size;
            trashScale = Trash.GetComponent<Transform>().lossyScale / globalField.SCALEDIFFRENCIAL;
            if (fishCenterCoord.x - ((fishScale.x) / 2) <= trashCenterCoord.x + ((trashScale.x) / 2) - globalField.grazeDist &&
                fishCenterCoord.x + ((fishScale.x) / 2) >= trashCenterCoord.x - ((trashScale.x) / 2) + globalField.grazeDist &&
                fishCenterCoord.y - ((fishScale.y) / 2) <= trashCenterCoord.y + ((trashScale.y) / 2) - globalField.grazeDist &&
                fishCenterCoord.y + ((fishScale.y) / 2) >= trashCenterCoord.y - ((trashScale.y) / 2) + globalField.grazeDist)
            {
                //Fish.GetComponent<fishBreak>().FishDelete(base.gameObject);
                FishDelete(base.gameObject);
                Trash.GetComponent<SC_Trash>().TrashDelete(Trash);
                uiFishLife.LifeBreaking(globalField.life.num - 1);
                globalField.life.num -= 1;
                Debug.Log("life =" + globalField.life.num);
            }
        }
    }
    void BookHit()
    {
        for (i = 0; i < globalField.spoNumBook.max; i++)
        {
            if ((Book = GameObject.Find("book" + i)) == null)
            {
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
    public void FishDelete(GameObject deleter)
    {
        Destroy(deleter);
        globalField.spoNumFish.num -= 1;
        Debug.Log("fishSpownNum = " + globalField.spoNumFish.num);
    }
    //岩の位置の判定
    void rockjudge()
    {
        Vector3[] objPosition = new Vector3[2];
        Vector3[] objScale = new Vector3[2];
        GameObject[] obj = new GameObject[2];
        int i;

        objPosition[1] = (base.gameObject).transform.position;
        objScale[1] = (base.gameObject).transform.localScale;

        for (i = 0; i < globalField.spoNumRock.max; i++)
        {
            obj[0] = GameObject.Find("rock" + i);
            //objPosition[0] = .transform.position;
            //objScale[0] = .transform.localScale;
            /*
            if (((objPosition[1].x - objPosition[0].x) * (objPosition[1].x - objPosition[0].x)) +
                ((objPosition[1].y - objPosition[0].y) * (objPosition[1].y - objPosition[0].y)) <=
                ((objScale[0].x / 2) * (objScale[0].x / 2)) + ((objScale[1].x / 2) * (objScale[1].x / 2)))
            {
                Debug.Log("hit Rock" + i);
            }
            */
        }
    }
}
