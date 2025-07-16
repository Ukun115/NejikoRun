using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public NejikoController nejiko;
    public Text scoreLabel;
    public LifePanel lifePanel;

    public void Update()
    {
        //�X�R�A���x�����X�V
        int score = CalcScore();
        scoreLabel.text = "Score : " + score + "m";

        //���C�t�p�l�����X�V
        lifePanel.UpdateLife(nejiko.Life());

        //�˂��q�̃��C�t��0�ɂȂ�����Q�[���I�[�o�[
        if(nejiko.Life() <= 0)
        {
            //����ȍ~��Update�͎~�߂�
            enabled = false;

            //�n�C�X�R�A���X�V
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            //2�b���ReturnToTitle���Ăяo��
            Invoke("ReturnToTitle", 2.0f);
        }
    }

    int CalcScore()
    {
        //�˂��q�̑��s�������X�R�A�Ƃ���
        return (int)nejiko.transform.position.z;
    }

    void ReturnToTitle()
    {
        //�^�C�g���V�[���ɐ؂�ւ�
        Application.LoadLevel("Title");
    }
}
