using UnityEngine;
using System.Collections;

public class testmove : MonoBehaviour
{

    //キャラクターコントローラーへの参照
    CharacterController characterController;

    //移動ベクトル
    Vector3 moveDirection = new Vector3(0.0f, 0.0f, 1.0f);

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //inputHorizontal = Input.GetAxisRaw("Horizontal");
        //inputVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.D))
        {
            inputHorizontal = 10 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputHorizontal = -10 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            inputVertical = 10 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVertical = -10 * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}