
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //「MainBall」ゲームオブジェクト
    [SerializeField] GameObject mainBall = null;
    //打つ力
    [SerializeField] float power = 0.1f;
    //方向表示用オブジェクトのトランスフォーム
    [SerializeField] Transform arrow = null;
    //ボールリスト
    [SerializeField] List<ColorBall> ballList = new List<ColorBall>();
    
    //マウス位置保管用
    Vector3 mousePosition = new Vector3();
    //「MainBall」のリジッドボディ
    Rigidbody mainRigid = null;
    //リセット時のためメインボールの初期位置を保存
    Vector3 mainBallDefaultPosition = new Vector3();
    // Start is called before the first frame update
    
    public SystemMain Sm;
    void Start()
    {
        //「MainBall」のリジッドボディを取得
        mainRigid = mainBall.GetComponent<Rigidbody>();
        mainBallDefaultPosition = mainBall.transform.localPosition;
        arrow.gameObject.SetActive( false );
        Sm = GameObject.Find("SystemMain").GetComponent<SystemMain>();
    }

    // Update is called once per frame
    void Update()
    {
        //メインボールがアクティブな時
        if(mainBall.activeSelf == true )
        {
            //マウスクリック開始時
            if( Input.GetMouseButtonDown(0) == true)
            {
                //開始位置を保管
                mousePosition = Input.mousePosition;
                //方向線を表示
                arrow.gameObject.SetActive(true);
                Debug.Log("クリック開始");
            }
            //マウスクリック中
            if(Input.GetMouseButton(0)==true)
            {
                //現在の位置を随時保管
                Vector3 position = Input.mousePosition;
                //角度を算出
                Vector3 def = mousePosition - position;
                float rad = Mathf.Atan2(def.x,def.y);
                float angle = rad * Mathf.Rad2Deg;
                Vector3 rot = new Vector3(0,angle,0);
                Quaternion qua = Quaternion.Euler(rot);
                //方向線の位置角度を設定
                arrow.localRotation = qua;
                arrow.transform.position = mainBall.transform.position;
            }
            //マウスクリック終了時
            if(Input.GetMouseButtonUp(0)==true)
            {
                //終了時の位置を保管
                Vector3 upPosition = Input.mousePosition;
                //開始位置と終了位置のベクトル計算から打ち出す方向を算出
                Vector3 def = mousePosition - upPosition;
                Vector3 add = new Vector3(def.x,0,def.y);
                mainRigid.AddForce(add * power);
                //方向線を非表示に
                arrow.gameObject.SetActive(false);

                Debug.Log("クリック終了");
            }

            if (IsOutBoundary())
            {
                WhiteReset();
            }
            
        }
    }
    // ---------------------------------------------------------------------
    /// <summary> 
    /// リセットボタンクリックコールバック. 
    /// </summary> 
    // --------------------------------------------------------------------- 
    void WhiteReset()
    {
        mainBall.SetActive(true);
        mainRigid.velocity = Vector3.zero;
        mainRigid.angularVelocity = Vector3.zero;
        mainBall.transform.localPosition = mainBallDefaultPosition;
    }
    public void OnResetButtonClicked()
    {
        WhiteReset();
        foreach(ColorBall ball in ballList)
        {
            ball.Reset();
        }
        Sm.Score = 0;
    }

    bool IsOutBoundary()
    {
        return mainBall.transform.position.x > 1.45 || mainBall.transform.position.x<-1.45||
        mainBall.transform.position.z>0.85 || mainBall.transform.position.z<-0.85;
    }
}