using UnityEngine;
using System.Collections;



public class fishMove : MonoBehaviour
{
    [SerializeField] float defSpd;  //魚のy軸下り移動速度、将来削除予定
    float[] yspeed = new float[2];  //魚のy軸移動速度　０…上り速度　１…下り速度
    
    float xspd = 0.02f;             //魚のx軸移動速度
    int healcnt = 0;                //魚回復用のカウント
    int healcost = 0;               //魚が滝から落ちた際に、回復に必要とする時間
    bool myDirecDown;               //魚の進行方向が下りかどうか
    short chanceFishFall = 50;      //魚が滝から落ちない確率、整数型で、100.00%を10000として記述 //テストデータ0.5%
    public GameObject fish;         //自分自身のアドレス
    GlobalField globalField;
    // Use this for initialization
    void Start(){
        yspeed[0] = defSpd; //上るときの速度
        yspeed[1] = 2.0f;   //下るときの速度
        myDirecDown = false;
        globalField = GameObject.Find("GlobalField").GetComponent<GlobalField>();
    }

    // Update is called once per frame
    void Update(){
        if (globalField.pouseFlg == false)
        {
            /*
            //画面上部に行った時、方向転換
            if (fish.transform.position.y >= globalField.trunPoint){
                myDirecDown = true;
            }
            */
            rockjudge();
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
    }
    //岩の位置の判定
    void rockjudge(){
        Vector3[] objPosition = new Vector3[2];
        Vector3[] objScale = new Vector3[2];
        GameObject[] obj = new GameObject[2];
        int i;

        objPosition[1] = (base.gameObject).transform.position;
        objScale[1] = (base.gameObject).transform.localScale;

        for (i = 0;i < 4; i++)
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
