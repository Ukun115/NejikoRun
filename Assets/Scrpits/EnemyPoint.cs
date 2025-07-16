using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        //�v���t�@�u�𓯃|�W�V�����ɐ���
        GameObject go = (GameObject)Instantiate(
            prefab,
            Vector3.zero,
            Quaternion.identity
            );

        //�ꏏ�ɍ폜�����悤�ɐ��������G�I�u�W�F�N�g���q�ɐݒ�
        go.transform.SetParent(transform, false);
    }

    //�X�e�[�W�G�f�B�b�g���̂��߂ɃV�[���ɃM�Y����\��
    void OnDrawGizmos()
    {
        //�M�Y���̒�ӂ��n�ʂƓ��������ɂȂ�悤�ɃI�t�Z�b�g��ݒ�
        Vector3 offset = new Vector3(0, 0.5f, 0);

        //����\��
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

        //�v���t�@�u���̃A�C�R����\��
        if(prefab != null)
        {
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
        }
    }
}
