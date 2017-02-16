using UnityEngine;
using System.Collections;

public class testmove : MonoBehaviour
{
    //キャラクターコントローラーへの参照
    CharacterController characterController;

    //アニメーターへの参照
    public Animator animator;

    //重力
    private float gravity = 20.0f;

    //移動スピード
    private float speed = 5.0f;

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed = 3f;

    public void Playermove()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            //走るアニメーションを再生する
            animator.SetBool("run", true);
            //進行方向を向く
            transform.LookAt(transform.position + new Vector3(inputHorizontal, 0, inputVertical));
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

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
            inputHorizontal = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputHorizontal = -1;
        }
        else
        {
            inputHorizontal = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            inputVertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputVertical = -1;
        }
        else
        {
            inputVertical = 0;
        }
        Playermove();
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