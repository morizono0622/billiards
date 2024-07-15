
using UnityEngine;
 
public class Hole : MonoBehaviour
{
    public SystemMain Sm;
    void Start()
    {
        Sm = GameObject.Find("SystemMain").GetComponent<SystemMain>();
    }
 
    void OnTriggerEnter( Collider other )
    {
        if (other.gameObject.name == "Main ball")
        {
            Debug.Log("Main ballがHoleに入った Score-1");
            Sm.Score-=1;
            return;
        }
        Debug.Log( "落ちたボールの名前 : " + other.gameObject.name );
        // 穴に落ちたボールを非アクティブにする.
        other.gameObject.SetActive( false );
        Sm.Score +=1;
    }
}