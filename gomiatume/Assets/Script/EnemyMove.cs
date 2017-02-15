using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{

    public Transform player;    //プレイヤーを代入
    public float speed = 3; //移動速度
    public bool enemymove = true;
    float a = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemymove == true)
        {
            Vector3 playerPos = player.position;    //プレイヤーの位置
            Vector3 direction = playerPos - transform.position; //方向
            direction = direction.normalized;   //単位化（距離要素を取り除く）
            transform.position = transform.position + (direction * speed * Time.deltaTime);
            transform.LookAt(player);   //プレイヤーの方を向く
        }
        if(enemymove == false)
        {
            Vector3 playerPos = player.position;    //プレイヤーの位置
            Vector3 direction = playerPos - transform.position; //方向
            direction = direction.normalized;   //単位化（距離要素を取り除く）
            transform.position = transform.position - (direction * speed * Time.deltaTime);
            transform.LookAt(player);   //プレイヤーの方を向く
        }
        if(enemymove == false)
        {
            a = a + Time.deltaTime;
            if(a >= 2)
            {
                enemymove = true;
                a = 0;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "field")
        {
            enemymove = false;
        }

        if (other.gameObject.tag == "Player")
        {
            enemymove = false;
            if (TimeandScore.gomi > 0)
            {
                TimeandScore.gomi--;
            }
        }
    }
}