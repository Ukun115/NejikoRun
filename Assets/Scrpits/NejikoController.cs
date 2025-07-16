using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;
    int targetLane;
    int life = DefaultLife;
    float recoverTime = 0.0f;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    //���C�t�擾�p�֐�
    public int Life()
    {
        return life;
    }

    //�C�┻��
    public bool IsStan()
    {
        return recoverTime > 0.0f || life <= 0;
    }

    void Start()
    {
        //�K�v�ȃR���|�[�l���g�������擾
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ////�f�o�b�N�p
        //if (Input.GetKeyDown("left")) MoveToLeft();
        //if (Input.GetKeyDown("right")) MoveToRight();
        //if (Input.GetKeyDown("space")) Jump();

        //�C�⎞
        if (IsStan())
        {
            //�������~�ߋC���Ԃ���̕��A�J�E���g��i�߂�
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            //���X�ɉ�����Z�����ɏ�ɑO�i������
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            //X�����͖ڕW�̃|�W�V�����܂ł̍����̊����ő��x���v�Z
            float ratioX = (targetLane * LaneWidth - transform.transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

        }

        //�d�͕��̗͂��}�C�t���[���ǉ�
        moveDirection.y -= gravity * Time.deltaTime;

        //�ړ����s
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        //�ړ���ڒn���Ă���Y�����̑��x�̓��Z�b�g����
        if (controller.isGrounded) moveDirection.y = 0;

        //���x��0�ȏ�Ȃ瑖���Ă���t���O��true�ɂ���
        animator.SetBool("run", moveDirection.z > 0.0f);
    }

    //���̃��[���Ɉړ����J�n
    public void MoveToLeft()
    {
        //�C�⎞�̓��̓L�����Z��
        if (IsStan()) return;

        if (controller.isGrounded && targetLane > MinLane) targetLane--;
    }

    //�E�̃��[���Ɉړ����J�n
    public void MoveToRight()
    {
        //�C�⎞�̓��̓L�����Z��
        if (IsStan()) return;

        if (controller.isGrounded && targetLane < MaxLane) targetLane++;
    }

    public void Jump()
    {
        //�C�⎞�̓��̓L�����Z��
        if (IsStan()) return;

        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;

            //�W�����v�g���K�[��ݒ�
            animator.SetTrigger("jump");
        }
    }

    //CharacterController�ɃR���W���������������̏���
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //�C�⎞�̓��̓L�����Z��
        if (IsStan()) return;

        //�Ԃ������I�u�W�F�N�g�̃^�O��Robo��������A
        if(hit.gameObject.tag == "Robo")
        {
            //���C�t�����炵�ċC���ԂɈڍs
            life--;
            recoverTime = StunDuration;

            //�_���[�W�g���K�[��ݒ�
            animator.SetTrigger("damage");

            //�q�b�g�����I�u�W�F�N�g�͍폜
            Destroy(hit.gameObject);

            //�f�o�b�N���O
            Debug.Log("�_���[�W���󂯂��I");
        }
    }
}
