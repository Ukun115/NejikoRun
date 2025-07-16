using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    //追従距離
    Vector3 diff;

    //追従ターゲットパラメーター
    public GameObject target;
    //追従速度
    public float followSpeed;

    void Start()
    {
        //追従距離の計算
        diff = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //線形補間関数によるスムージング
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - diff,
            Time.deltaTime * followSpeed
         );
    }
}
