using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    //ブロック生成タイマー
    float waitTimer;
    //総経過時間
    public float totalTimer;
    //最初は停止
    public bool isStop;

    void Start()
    {
        isStop = true;
    }

    void Update()
    {
        if (isStop) return;

        waitTimer -= Time.deltaTime;
        totalTimer += Time.deltaTime;

        //ブロック生成
        if (0 > waitTimer)
        {
            Vector3 pos = transform.position;
            
            pos.y = Random.Range(-5, 5);
            //プレファブを生成
            GameObject obj = Instantiate(enemyPrefab, pos, Quaternion.identity);
            EnemyManager ctrl = obj.GetComponent<EnemyManager>();

            ctrl.moveSpeed = -(300 + (totalTimer * 1.5f));

            float min = 2 - (totalTimer / 100);
            if (0.01f > min) min = 0.01f;
            float max = 2 * min;

            waitTimer = Random.Range(min, max);
        }
    }
}
