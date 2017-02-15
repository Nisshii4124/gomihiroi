using UnityEngine;
using System.Collections;

public class gomiget : MonoBehaviour
{
    public int sutetagomi;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (TimeandScore.gomi <= TimeandScore.gomimax)
        {
            if (other.gameObject.tag == "gomi")//tag「gomi」のついたオブジェクトにふれたら
            {
                Destroy(other.gameObject);//オブジェクトを消す
                TimeandScore.gomi += 1;
            }
        }
        if(other.gameObject.tag == "gomibako")//tag「gomibako」のついたオブジェクトにふれたら
        {
            sutetagomi = TimeandScore.gomi;
            TimeandScore.score += sutetagomi * 100;
            sutetagomi = 0;
            TimeandScore.gomi = 0;
        }
    }
}
