using UnityEngine;
using System.Collections;

public class SCFish : MonoBehaviour
{
    GameObject Fish;
    Vector3 fishCenterCoord;
    Vector3 fishScale;
    Vector3 rockCenterCoord;
    Vector3 rockScale;
    GameObject Rock;
    Vector3 trashCenterCoord;
    Vector3 trashScale;
    GameObject Trash;
    Vector3 bookCenterCoord;
    Vector3 bookScale;
    GameObject Book;
    int i;
<<<<<<< HEAD
    bool isNotFindBite;
    bool isThisFishAlive;
    [SerializeField]
    float defSpd;
    float[] yspeed = new float[2];
    float spd = 100.0f;
    int healcnt = 0;
    int healcost = 0;
    bool myDirecDown;
    short chanceFishFall = 50;
    public GameObject fish;
    GameObject copyBite;
    float tagrad;
    Rigidbody fishBody;
    [SerializeField]
    Sprite DeadTexture;
    SpriteRenderer fishRenderer;
    BoxCollider fishCollider;
    void Start()
    {
        yspeed[0] = defSpd;
        yspeed[1] = 75.0f;
=======

    bool isNotFindBite;
    bool isThisFishAlive;
    [SerializeField]
    float defSpd;                   //魚のy軸下り移動速度、将来削除予定
    float[] yspeed = new float[2];  //魚のy軸移動速度　０…上り速度　１…下り速度

    float spd = 100.0f;               //魚の移動速度
    int healcnt = 0;                //魚回復用のカウント
    int healcost = 0;               //魚が滝から落ちた際に、回復に必要とする時間
    bool myDirecDown;               //魚の進行方向が下りかどうか
    short chanceFishFall = 50;      //魚が滝から落ちない確率、整数型で、100.00%を10000として記述 //テストデータ0.5%
    public GameObject fish;         //自分自身のアドレス
    GameObject copyBite;            //エサに引き寄せる際に、えさのアドレスを持っておく
    float tagrad;                   //エサをターゲットとした、ラジアン角
    Rigidbody fishBody;
    [SerializeField]
    Sprite DeadTexture;

    SpriteRenderer fishRenderer;
    BoxCollider fishCollider;
    // Use this for initialization
    void Start()
    {
        yspeed[0] = defSpd; //上るときの速度
        yspeed[1] = 75.0f;   //下るときの速度
>>>>>>> 294da04... 完成ビルド前の作業保存
        myDirecDown = false;
        fishBody = GetComponent<Rigidbody>();
        fishRenderer = GetComponent<SpriteRenderer>();
        fishCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            Move();
            BreakJudge();
        }
        else
        {
            fishBody.velocity = new Vector3(0,0,0);
        }
    }
    void Move()
    {

        tagrad = 0.0f;
        if (myDirecDown == true)
        {
            tagrad = 270 * 3.14f / 180;
        }
        else
        {
            tagrad = 90 * 3.14f / 180;
        }

        if(isThisFishAlive == true){
            float distance = new float();
            float[] point = new float[2];
            isNotFindBite = true;
            for (int i = 0; i < GlobalField.globalField.spoNumBite.max; i++)
            {
                if (GlobalField.globalField.Bite[i] == null)
                {
                    continue;
                }
                point[0] = (GlobalField.globalField.Bite[i].transform.position.x - transform.position.x) * (GlobalField.globalField.Bite[i].transform.position.x - transform.position.x);
                point[1] = (GlobalField.globalField.Bite[i].transform.position.y - transform.position.y) * (GlobalField.globalField.Bite[i].transform.position.y - transform.position.y);
                distance = Mathf.Pow(point[1] + point[0], 0.5f);
                if ((GlobalField.globalField.Bite[i].transform.position.x - GlobalField.globalField.BiteDistance.x <= transform.position.x) &&
                    (GlobalField.globalField.Bite[i].transform.position.x + GlobalField.globalField.BiteDistance.x >= transform.position.x) &&
                    (GlobalField.globalField.Bite[i].transform.position.y - GlobalField.globalField.BiteDistance.y <= transform.position.y) &&
                    (GlobalField.globalField.Bite[i].transform.position.y + GlobalField.globalField.BiteDistance.y >= transform.position.y))
                {
                    isNotFindBite = false;
                    tagrad = Mathf.Atan2(GlobalField.globalField.Bite[i].transform.position.y - fish.transform.position.y, GlobalField.globalField.Bite[i].transform.position.x - fish.transform.position.x);
                    fish.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (tagrad * 180.0f / 3.14f) - 180));
                    fishBody.velocity = new Vector3(Mathf.Cos(tagrad) * spd, 0, 0);
                }
            }
            if (isNotFindBite == true)
            {
                fish.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                fishBody.velocity = new Vector3(0, Mathf.Sin(((myDirecDown == true) ? 270 : 90) * 3.14f / 180.0f) * ((myDirecDown == true) ? yspeed[1] : yspeed[0]), 0);
            }
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
        else
        {
            transform.position += new Vector3(0, -3.0f, 0);
        }
    }
    void BreakJudge()
    {
        if (isThisFishAlive == false)
        {
            if (transform.position.y <= GlobalField.globalField.destroyPoint[GlobalField.globalField.TRASH])
            {
                FishDelete();
            }
        }
        else if (base.gameObject.transform.position.y >= GlobalField.globalField.destroyPoint[GlobalField.globalField.FISH])
        {
            FishDelete();
            GlobalField.globalField.score += 1;
        }   
    }
    public void FishJammed()
    {
        fishCollider.enabled = false;
        myDirecDown = true;
        fishRenderer.sprite = DeadTexture;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,-30));
        FishDead();
    }
    public void FishDelete()
    {
        Destroy(base.gameObject);
        GlobalField.globalField.spoNumFish.num -= 1;
    }
    public void FishDead()
    {
        isThisFishAlive = false;
    }
    public void FishSpown()
    {
        isThisFishAlive = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (GlobalField.globalField.pouseFlg == false)
        {
            if (GlobalField.globalField.GetInvincible() == false)
            {
                if (other.gameObject.CompareTag("Rock"))
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
                {
                    GlobalField.globalField.LifeDeclane();
                    FishJammed();
                }
                else if (other.gameObject.CompareTag("Trash"))
                {
                    FishJammed();
                    GlobalField.globalField.LifeDeclane();
                    other.gameObject.GetComponent<SC_Trash>().TrashDelete();
                }
            }

        }
    }
}