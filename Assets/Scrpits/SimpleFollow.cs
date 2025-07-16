using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    //�Ǐ]����
    Vector3 diff;

    //�Ǐ]�^�[�Q�b�g�p�����[�^�[
    public GameObject target;
    //�Ǐ]���x
    public float followSpeed;

    void Start()
    {
        //�Ǐ]�����̌v�Z
        diff = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //���`��Ԋ֐��ɂ��X���[�W���O
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - diff,
            Time.deltaTime * followSpeed
         );
    }
}
