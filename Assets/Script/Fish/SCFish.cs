using UnityEngine;
using System.Collections;

public class SCFish : MonoBehaviour
{
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
    float defSpd;                   //魚のy軸下り移動速度、将来削除予定
    float[] yspeed = new float[2];  //魚のy軸移動速度　０…上り速度　１…下り速度

    float spd = 2.0f;               //魚の移動速度
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
        uiFishLife = GameObject.Find("SpownPoint").GetComponent<UIFishLife>();

        yspeed[0] = defSpd; //上るときの速度
        yspeed[1] = 2.0f;   //下るときの速度
        myDirecDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
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
        if (fish.transform.position.y >= GlobalField.globalField.trunPoint){
            myDirecDown = true;
        }
        */
        //rockjudge();
        {
            float distance = new float();
            Vector2[] point = new Vector2[2];
            point[1] = new Vector2(transform.position.x * transform.position.x, transform.position.y * transform.position.y);
            for (int i = 0; i < GlobalField.globalField.spoNumBite.max; i++)
            {
                
                if ((copyBite = GlobalField.globalField.Bite[i]) == null)
                {
                    continue;
                }
                //距離の設定
                point[0] = new Vector2(GlobalField.globalField.Bite[i].transform.position.x * GlobalField.globalField.Bite[i].transform.position.x, GlobalField.globalField.Bite[i].transform.position.y * GlobalField.globalField.Bite[i].transform.position.y);
                
                distance = Mathf.Pow((point[1].x - point[0].x) + (point[1].y - point[0].y), 0.5f);
                if (distance <= 600.0f)
                {
                    //角度の設定
                    tagrad = Mathf.Atan2(fish.transform.position.y - copyBite.transform.position.y, fish.transform.position.x - copyBite.transform.position.x);
                    fish.transform.position -= new Vector3(Mathf.Cos(tagrad) * spd, 0, 0);
                }
            }
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
        if (transform.position.y > GlobalField.globalField.Maincamera.transform.position.y)
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
        if (base.gameObject.transform.position.y >= GlobalField.globalField.destroyPoint[GlobalField.globalField.FISH])
        {
            FishDelete();

            GlobalField.globalField.score += 1;
        }
    }

    void HitJudge()
    {
        Fish = base.gameObject;
        fishCenterCoord = Fish.transform.position;
        //fishScale = Fish.GetComponent<BoxCollider>().size;
        fishScale = (Fish.transform.lossyScale) / GlobalField.globalField.SCALEDIFFRENCIAL;

        //Debug.Log(fishCenterCoord);
        Debug.Log("fishScale = " + fishScale);

        RockHit();
        if (GlobalField.globalField.invincible == false)
        {
            TrashHit();
        }
    }
    void RockHit()  //非常に動作が重い関数
    {
        //Debug.Log(GlobalField.globalField.rockPlaceNum);
        for (i = 0; i < GlobalField.globalField.spoNumRock.num; i++)
        {

            if (GlobalField.globalField.Rock[i] == null)
            {
                continue;
            }
            rockCenterCoord = GlobalField.globalField.Rock[i].transform.position;
            rockScale = (GlobalField.globalField.Rock[i].transform.lossyScale) / GlobalField.globalField.SCALEDIFFRENCIAL;
            //rockScale = Rock.GetComponent<BoxCollider>().size;



            //Debug.Log(rockCenterCoord);
            /*
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
                if (fishCenterCoord.x > rockCenterCoord.x)
                {
                    Fish.GetComponent<Transform>().position += new Vector3(GlobalField.globalField.avoidSpeed, 0.0f, 0.0f);
                }
                else
                {
                    Fish.GetComponent<Transform>().position += new Vector3(-GlobalField.globalField.avoidSpeed, 0.0f, 0.0f);
                }
            }
            */
        }
    }
    void TrashHit()
    {

        for (i = 0; i < GlobalField.globalField.spoNumTrash.max; i++)
        {
            if ((GlobalField.globalField.Trash[i]) == null)
            {
                continue;
            }
            trashCenterCoord = GlobalField.globalField.Trash[i].transform.position;
            //trashScale = Trash.GetComponent<BoxCollider>().size;
            trashScale = GlobalField.globalField.Trash[i].transform.lossyScale / GlobalField.globalField.SCALEDIFFRENCIAL;
            if (fishCenterCoord.x - ((fishScale.x) / 2) <= trashCenterCoord.x + ((trashScale.x) / 2) - GlobalField.globalField.grazeDist &&
                fishCenterCoord.x + ((fishScale.x) / 2) >= trashCenterCoord.x - ((trashScale.x) / 2) + GlobalField.globalField.grazeDist &&
                fishCenterCoord.y - ((fishScale.y) / 2) <= trashCenterCoord.y + ((trashScale.y) / 2) - GlobalField.globalField.grazeDist &&
                fishCenterCoord.y + ((fishScale.y) / 2) >= trashCenterCoord.y - ((trashScale.y) / 2) + GlobalField.globalField.grazeDist)
            {
                //Fish.GetComponent<fishBreak>().FishDelete(base.gameObject);
                FishDelete();
                GlobalField.globalField.Trash[i].GetComponent<SC_Trash>().TrashDelete();
                GlobalField.globalField.UILife[(GlobalField.globalField.life.num - 1)].GetComponent<SC_UILife>().LifeBreaking();
                GlobalField.globalField.life.num -= 1;
                Debug.Log("life =" + GlobalField.globalField.life.num);
            }
        }
    }
    void BookHit()
    {
        for (i = 0; i < GlobalField.globalField.spoNumBook.max; i++)
        {
            if ((Book = GameObject.Find("book" + i)) == null)
            {
                continue;
            }
            bookCenterCoord = Book.transform.position;
            bookScale = Book.GetComponent<BoxCollider>().size;
            if (fishCenterCoord.x - ((fishScale.x) / 2) <= bookCenterCoord.x + ((bookScale.x) / 2) &&
                fishCenterCoord.x + ((fishScale.x) / 2) >= bookCenterCoord.x - ((bookScale.x) / 2) &&
                fishCenterCoord.y - ((fishScale.y) / 2) <= bookCenterCoord.y + ((bookScale.y) / 2) &&
                fishCenterCoord.y + ((fishScale.y) / 2) >= bookCenterCoord.y - ((bookScale.y) / 2))

                Book.GetComponent<BookDestory>().BookDelete(Book);
        }
    }
    public void FishDelete()
    {
        Destroy(base.gameObject);
        GlobalField.globalField.spoNumFish.num -= 1;
        Debug.Log("fishSpownNum = " + GlobalField.globalField.spoNumFish.num);
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

        for (i = 0; i < GlobalField.globalField.spoNumRock.max; i++)
        {
            obj[0] = GlobalField.globalField.Rock[i];
            if(obj[0] == null)
            {
                continue;
            }
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
