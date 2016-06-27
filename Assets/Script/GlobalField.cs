using UnityEngine;
using System.Collections;

public struct ObjectSpownNumber //現在の設置数と、最大設置数を記録
{
    public int num;
    public int max;
}

public class GlobalField : MonoBehaviour
{
    public int FISH;
    public int TRASH;
    //public int rockPlaceNum;              //岩を置いている数
    //public int rockPlaceMax;              //岩を置ける最大数
    public ObjectSpownNumber spoNumRock;    //岩
    public ObjectSpownNumber spoNumBite;
    //public int trashPlaceNum;             //ゴミを置いている数
    //public int trashPlaceMax;             //ゴミの最大数
    public ObjectSpownNumber spoNumTrash;
    //public int fishSpownNum;              //魚がステージ中に居る数
    //public int fishSpownMax;              //魚の最大数
    public ObjectSpownNumber spoNumFish;    //魚の設置数と最大数
    public ObjectSpownNumber spoNumBook;    //本の設置数と最大数
    public ObjectSpownNumber waveFish;      //ウェーブごとに訪れる魚の数
    public int waveAddFish;   //ウェーブごとに増える魚の数
    public float avoidDist;                 //魚が岩を避けるようになる距離
    public float avoidSpeed;                //魚が岩をよける移動速度
    public float[] destroyPoint;              //オブジェクトが消えるy座標 0.魚 1.ゴミ
    public float[] spownPointx = {
        0.2f,0.3f,0.4f,0.6f,0.8f
    };

    public float spownPoint;                //魚が生まれるy座標
    //public Vector3 fishSpownPoint;          //魚を発生させる位置、x座標は中心地点を指定
    public Vector3[] fishSpownPoint;
    public Vector3[] trashSpownPoint;         //ゴミを発生させる位置、x座標は中心地点を指定
    [SerializeField]
    float trashSpownInactiveVPy;
    public float TRASHSPOWNINACTIVEPOINT;

    public int rockPlaceSecond;             //岩を設置する為に必要な時間
    public int placeSecondCnt;              //岩を設置する際のカウント
    public float trunPoint;                 //魚が進行方向を変える場所
    public Hashtable LAYER = new Hashtable();
    public float trashMoveSpd;              //ゴミが移動する速度

    public int biteBreakCnt;                //えさが消える時間

    public float spownRangeDif;
    public float xspownCenter;// = 332.0f;
    //ライフ
    ObjectSpownNumber life;          //残機
    //public GameObject Maincamera = GameObject.Find("MainCamera");
    public GameObject Maincamera;
    //public Camera Maincamera = Camera.current;

    public float grazeDist;
    public GameObject sceneManager;
    public bool pouseFlg;

    /*Unity2Dでのポジションとスケールの差を補完するための定数
      Unity2D上では、ポジションが1に対し、スケールが8の比率で扱われているので、
      あたり判定時にはこの数値を使わないとズレが発生する*/
    public float SCALEDIFFRENCIAL = 8.0f;

    /*スプライトを持つgameObjectに必要な、z座標の情報
     実質、レイヤーの役割を果たしている*/
    
   //public float L_FISH = 1.0f;
   //public float L_TRASH = 1.1f;
   //public float L_ROCK = 2.0f;
   //public float L_UIOUTSIDE = 3.0f;
   //public float L_UIINSIDE = 4.0f;
   //public float L_UILIFE = 5.0f;
   //public float L_LINE = 6.0f;
   
    public enum LEYER
    {
        FISH = 1,
        TRASH,
        ROCK,
        BITE,
        UIOUTSIDE,
        UIINSIDE,
        UILIFE,
        LINE,
        UITEXT
    }
   
    bool invincible;

    public int wave; //ウェーブ数
    public int score; //スコア

    public float framerate;
    //public float BiteDistance = 10000.0f; //エサを感知する距離
    public Vector2 BiteDistance = new Vector2(80.0f,200.0f); //エサを感知する距離
    //メインゲームシーンのゲームオブジェクトリファレンス
    public GameObject[] Rock;
    public GameObject[] Bite;
    public GameObject[] Trash;
    public GameObject[] Fish;
    public GameObject[] UILife;
    public GameObject[] RiverLine;
    //ステージ線のスポーン数
    public ObjectSpownNumber spoNumRiverLine;


    static public GlobalField globalField;

    // Use this for initialization
    void Start()
    {
        globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        framerate = (Application.targetFrameRate = 30);
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        pouseFlg = false;
        sceneManager.GetComponent<SceneManager>().changePouse(pouseFlg);

        //オブジェクト消滅位置の設定
        destroyPoint = new float[2];
        FISH = 0;
        TRASH = 1;

        destroyPoint[FISH] = (Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.0f, 1.01f, 0.0f))).y;
        destroyPoint[TRASH] = (Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.0f, -0.01f, 0.0f))).y;
        TRASHSPOWNINACTIVEPOINT = (Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.0f, trashSpownInactiveVPy, 0.0f))).y;
        

        spownPoint = -0.002f;
        life.max = 5;
        spoNumRiverLine.max = 5;
        waveAddFish = 4;
        rockPlaceSecond = (int)(Application.targetFrameRate * 0.8); //およそ0.8秒
        biteBreakCnt = (int)(Application.targetFrameRate * 5.0);
        reset();
        /*
        LAYER["FISH"] = 1.0f;
        LAYER["ROCK"] = 2.0f;
        LAYER["TAPOUTSIDE"] = 3.0f;
        LAYER["TAPINSIDE"] = 4.0f;
        */


        xspownCenter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position.x;
        {
            ArrayList tempArray = new ArrayList();
            ArrayList tempArray2 = new ArrayList();
            //魚スポーンポイントの設定
            for (int i = 0; i < spownPointx.Length; i++)
            {
                //fishSpownPoint[i] = Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], spownPoint, L_FISH));
                tempArray.Add(Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], spownPoint,(float)LEYER.FISH)));
                tempArray2.Add(Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], 1.01f, (float)LEYER.TRASH)));
            }
            //fishSpownPoint = new Vector3(tempArray.ToArray());
            fishSpownPoint = (Vector3[])tempArray.ToArray(typeof(Vector3));
            trashSpownPoint = (Vector3[])tempArray2.ToArray(typeof(Vector3));

            //ゴミスポーンポイントの設定

        }
        Bite = new GameObject[spoNumBite.max];
        Fish = new GameObject[spoNumFish.max];
        RiverLine = new GameObject[spoNumRiverLine.max];


    }

    // Update is called once per frame
    void Update()
    {

    }
    void rockPlacing()
    {
        spoNumRock.num += 1;
    }

    public void reset()
    {
        spoNumRock.num = 0;
        spoNumRock.max = 3;
        spoNumFish.num = 0;
        spoNumFish.max = 5;
        spoNumTrash.num = 0;
        spoNumTrash.max = 5;
        spoNumBook.num = 0;
        spoNumBook.max = 1;
        spoNumBite.num = 0;
        spoNumBite.max = 3;

        waveFish.max = 5;  //1ウェーブ目の魚の数

        lifeMaxSet();
        grazeDist = 12.5f;
        avoidDist = 100.0f;
        trunPoint = (Maincamera.GetComponent<Transform>().position.y) + (Maincamera.GetComponent<Camera>().orthographicSize);
        spownRangeDif = 1.0f;
        
        placeSecondCnt = 0;
        wave = 1;
        score = 0;
        avoidSpeed = 12.0f;
        //岩配列の初期化
        Rock = new GameObject[spoNumRock.max];
        Bite = new GameObject[spoNumBite.max];
        Trash = new GameObject[spoNumTrash.max];
        UILife = new GameObject[life.max];
    }
    public void lifeMaxSet()
    {
        life.num = life.max;
    }
    public void LifeDeclane()
    {
        life.num -= 1;
    }

    public int GetLife()
    {
        return life.num;
    }

    public void DebugModeOn()
    {
        invincible = true;
    }
    public void DebugModeOff()
    {
        invincible = false;
    }

    public void WaveChange()
    {
        wave++;
        waveFish.max = waveFish.max + (waveAddFish * (wave - 1));
        waveFish.num = 0;
        life.num = life.max;


    }
    public void FishDeleteAll()
    {
        int j;

        for (j = 0; j < spoNumFish.max; j++)
        {
            if(Fish[j] == null)
            {
                continue;
            }
            Fish[j].GetComponent<SCFish>().FishDelete();
        }
    }

    public bool GetInvincible()
    {
        return invincible;
    }

    public void RockDeleteAll()
    {
        int j;

        for (j = 0; j < spoNumRock.max; j++)
        {
            if (Rock[j] == null)
            {
                continue;
            }
            Rock[j].GetComponent<SC_Rock>().deleteRock();
            
        }
    }
    public void TrashDeleteAll()
    {
        int j;

        for (j = 0; j < spoNumTrash.max; j++)
        {
            if (Trash[j] == null)
            {
                continue;
            }
            Trash[j].GetComponent<SC_Trash>().TrashDelete();
        }
    }
}
