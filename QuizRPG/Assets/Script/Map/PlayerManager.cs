using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int square_num;
    public List<GameObject> SquareList = new List<GameObject>();
    private Vector3 pushMouseButtonPos = new Vector3(0.0f, 0.0f, 0.0f);

    const float CLICK_RANGE = 0.45f;

    // Use this for initialization
    void Start () {
        for (int i = 1; i < square_num + 1; i++)
        {
            SquareList.Add(GameObject.Find("square_" + i.ToString()));
        }

        transform.position = SquareList[0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        ClickObjectCheck();
    }

    private void ClickObjectCheck()
    {
        GameObject obj = null;
        // 左クリックされた場所の座標保存
        if (Input.GetMouseButtonDown(0))
        {
            pushMouseButtonPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        // クリックボタンを離したときオブジェクトのコリジョンと衝突判定し、衝突していたならオブジェクトを戻す
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                obj = collition2d.transform.gameObject;
                if ((pushMouseButtonPos.x - obj.transform.position.x) < CLICK_RANGE && (pushMouseButtonPos.x - obj.transform.position.x) > -CLICK_RANGE
                    && (pushMouseButtonPos.y - obj.transform.position.y) < CLICK_RANGE && (pushMouseButtonPos.y - obj.transform.position.y) > -CLICK_RANGE)
                {
                    transform.position = obj.transform.position;
                }
            }
        }
    }
}
