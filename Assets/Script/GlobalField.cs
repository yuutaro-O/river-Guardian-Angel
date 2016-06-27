using UnityEngine;
using System.Collections;

public struct ObjectSpownNumber
{
    public int num;
    public int max;
}

public class GlobalField : MonoBehaviour
{
    public int FISH;
    public int TRASH;
    public ObjectSpownNumber spoNumRock;
    public ObjectSpownNumber spoNumBite;
    public ObjectSpownNumber spoNumTrash;
    public ObjectSpownNumber spoNumFish;
    public ObjectSpownNumber spoNumBook;
    public ObjectSpownNumber waveFish;
    public int waveAddFish;
    public float avoidDist;
    public float avoidSpeed;
    public float[] destroyPoint;
    public float[] spownPointx = {
        0.2f,0.3f,0.4f,0.6f,0.8f
    };
    public float spownPoint;
    public Vector3[] fishSpownPoint;
    public Vector3[] trashSpownPoint;
    [SerializeField]
    float trashSpownInactiveVPy;
    public float TRASHSPOWNINACTIVEPOINT;
    public int rockPlaceSecond;
    public int placeSecondCnt;
    public float trunPoint;
    public Hashtable LAYER = new Hashtable();
    public float trashMoveSpd;
    public int biteBreakCnt;
    public float spownRangeDif;
    public float xspownCenter;
    ObjectSpownNumber life;
    public GameObject Maincamera;
    public float grazeDist;
    public GameObject sceneManager;
    public bool pouseFlg;
    public float SCALEDIFFRENCIAL = 8.0f;
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
    public int wave;
    public int score;
    public float framerate;
    public Vector2 BiteDistance = new Vector2(80.0f,200.0f);
    public GameObject[] Rock;
    public GameObject[] Bite;
    public GameObject[] Trash;
    public GameObject[] Fish;
    public GameObject[] UILife;
    public GameObject[] RiverLine;
    public ObjectSpownNumber spoNumRiverLine;
    static public GlobalField globalField;
    void Start()
    {
        globalField = GameObject.FindGameObjectWithTag("GlobalField").GetComponent<GlobalField>();
        framerate = (Application.targetFrameRate = 30);
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        pouseFlg = false;
        sceneManager.GetComponent<SceneManager>().changePouse(pouseFlg);
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
        rockPlaceSecond = (int)(Application.targetFrameRate * 0.8);
        biteBreakCnt = (int)(Application.targetFrameRate * 5.0);
        reset();
        xspownCenter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position.x;
        {
            ArrayList tempArray = new ArrayList();
            ArrayList tempArray2 = new ArrayList();
            for (int i = 0; i < spownPointx.Length; i++)
            {
                tempArray.Add(Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], spownPoint,(float)LEYER.FISH)));
                tempArray2.Add(Maincamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(spownPointx[i], 1.01f, (float)LEYER.TRASH)));
            }
            fishSpownPoint = (Vector3[])tempArray.ToArray(typeof(Vector3));
            trashSpownPoint = (Vector3[])tempArray2.ToArray(typeof(Vector3));
        }
        Bite = new GameObject[spoNumBite.max];
        Fish = new GameObject[spoNumFish.max];
        RiverLine = new GameObject[spoNumRiverLine.max];
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
<<<<<<< HEAD
        waveFish.max = 5;
=======

        waveFish.max = 5;  //1ウェーブ目の魚の数

>>>>>>> 294da04... 完成ビルド前の作業保存
        lifeMaxSet();
        grazeDist = 12.5f;
        avoidDist = 100.0f;
        trunPoint = (Maincamera.GetComponent<Transform>().position.y) + (Maincamera.GetComponent<Camera>().orthographicSize);
        spownRangeDif = 1.0f;
        placeSecondCnt = 0;
        wave = 1;
        score = 0;
        avoidSpeed = 12.0f;
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
<<<<<<< HEAD
    public void RockDeleteAll()
    {
        int j;
=======

    public void RockDeleteAll()
    {
        int j;

>>>>>>> 294da04... 完成ビルド前の作業保存
        for (j = 0; j < spoNumRock.max; j++)
        {
            if (Rock[j] == null)
            {
                continue;
            }
            Rock[j].GetComponent<SC_Rock>().deleteRock();
<<<<<<< HEAD
=======
            
>>>>>>> 294da04... 完成ビルド前の作業保存
        }
    }
    public void TrashDeleteAll()
    {
        int j;
<<<<<<< HEAD
=======

>>>>>>> 294da04... 完成ビルド前の作業保存
        for (j = 0; j < spoNumTrash.max; j++)
        {
            if (Trash[j] == null)
            {
                continue;
            }
            Trash[j].GetComponent<SC_Trash>().TrashDelete();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 294da04... 完成ビルド前の作業保存
