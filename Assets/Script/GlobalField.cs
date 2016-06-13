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
    public int rockPlaceSecond;             //岩を設置する為に必要な時間
    public int placeSecondCnt;              //岩を設置する際のカウント
    public float trunPoint;                 //魚が進行方向を変える場所
    public Hashtable LAYER = new Hashtable();
    public float trashMoveSpd;              //ゴミが移動する速度

    public int biteBreakCnt;                //えさが消える時間

    public float spownRangeDif;
    public float xspownCenter;// = 332.0f;
    //ライフ
    public ObjectSpownNumber life;          //残機
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
    
   public float L_FISH = 1.0f;
   public float L_TRASH = 1.1f;
   public float L_ROCK = 2.0f;
   public float L_UIOUTSIDE = 3.0f;
   public float L_UIINSIDE = 4.0f;
   public float L_UILIFE = 5.0f;
   public float L_LINE = 6.0f;
   /*
    public enum LEYER
    {
        FISH = 1,
        TRASH,
        ROCK,
        UIOUTSIDE,
        UIINSIDE,
        UILIFE,
        LINE
    }
    */
    public bool invincible;

    public int wave; //ウェーブ数
    public int score; //スコア


    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 30;
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

        spownPoint = -0.002f;
        life.max = 5;
        waveAddFish = 7;
        rockPlaceSecond = (int)(Application.targetFrameRate * 0.8); //およそ0.8秒
        Debug.Log("rockPlaceSecond = " + rockPlaceSecond);
        biteBreakCnt = (int)(Application.targetFrameRate * 5.0);
        Debug.Log("biteBreakCnt = " + biteBreakCnt);
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
                tempArray.Add(Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], spownPoint, L_FISH)));
                tempArray2.Add(Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], 1.01f, L_TRASH)));
                Debug.Log("fishSpownPoint[" + i + "] = " + tempArray[i]);
            }
            //fishSpownPoint = new Vector3(tempArray.ToArray());
            fishSpownPoint = (Vector3[])tempArray.ToArray(typeof(Vector3));
            trashSpownPoint = (Vector3[])tempArray2.ToArray(typeof(Vector3));

            //ゴミスポーンポイントの設定

        }
        Debug.Log("spownPoint = " + spownPoint);
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
        spoNumRock.max = 4;
        spoNumFish.num = 0;
        spoNumFish.max = 5;
        spoNumTrash.num = 0;
        spoNumTrash.max = 5;
        spoNumBook.num = 0;
        spoNumBook.max = 1;

        waveFish.max = 15;  //1ウェーブ目の魚の数
        
        life.num = life.max;
        grazeDist = 12.5f;
        //avoidDist = 0.03f;
        avoidDist = 100.0f;
        //destroyPoint = 296.6f;
        //destroyPoint = (Maincamera.GetComponent<Transform>().position.y) - (Maincamera.GetComponent<Camera>().orthographicSize);
        //trunPoint = 299.1f;
        trunPoint = (Maincamera.GetComponent<Transform>().position.y) + (Maincamera.GetComponent<Camera>().orthographicSize);
        //trashSpownPoint = new Vector3(xspownCenter, 299.0f, L_TRASH);
        //trashSpownPoint = new Vector3(xspownCenter, trunPoint, L_TRASH);
        //fishSpownPoint = new Vector3(xspownCenter, 296.7f, L_FISH);
        //fishSpownPoint = new Vector3(xspownCenter, (Maincamera.GetComponent<Transform>().position.y) - (Maincamera.GetComponent<Camera>().orthographicSize) - 1, L_FISH);
        spownRangeDif = 1.0f;
        
        placeSecondCnt = 0;
        wave = 1;
        score = 0;
        //trashMoveSpd = 0.005f;

        //avoidSpeed = 0.015f;
        avoidSpeed = 12.0f;
        invincible = false;

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
        waveFish.max = waveFish.max + (waveAddFish * wave);
        waveFish.num = 0;

    }
}
