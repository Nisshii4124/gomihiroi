using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{
    //キャラクターコントローラーへの参照
    CharacterController characterController;

    //アニメーターへの参照
    public Animator animator;
    //重力
    private float gravity = 20.0f;
    //移動スピード
    private float speed = 5.0f;

    //移動ベクトル
    Vector3 moveDirection = new Vector3(0.0f, 0.0f, 1.0f);

    public void Playermove()
    {
        moveDirection.x = Input.GetAxis("Horizontal") * speed;
        moveDirection.z = Input.GetAxis("Vertical") * speed;
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            //走るアニメーションを再生する
            animator.SetBool("run", true);
            //進行方向を向く
            transform.LookAt(transform.position + new Vector3(moveDirection.x, 0, moveDirection.z));
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //接地しているときの処理
        if (characterController.isGrounded)
        {
            switch (TimeandScore.gomi)
            {
                case 0:
                    speed = 5;
                    Playermove();
                    break;
                case 1:
                    speed = 5;
                    Playermove();
                    break;
                case 2:
                    speed = 5;
                    Playermove();
                    break;
                case 3:
                    speed = 5;
                    Playermove();
                    break;
                case 4:
                    speed = 4;
                    Playermove();
                    break;
                case 5:
                    speed = 3;
                    Playermove();
                    break;
            }
        }
        //重力を反映
        moveDirection.y -= gravity * Time.deltaTime;

        //移動実行
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
