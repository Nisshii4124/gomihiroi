using UnityEngine;
using System.Collections;

public class maincamera : MonoBehaviour
{

    //プレイヤートランスフォームへの参照
    Transform playerTransform;
    //プレイヤーからの距離
    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            playerTransform.position.x + offset.x,
            transform.position.y,
            playerTransform.position.z + offset.z
            );
    }
}
