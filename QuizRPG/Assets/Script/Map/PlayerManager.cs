using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int square_num;                                                  /* ステージのマス数 */
    public List<GameObject> SquareList = new List<GameObject>();            /* マスマネージャ格納リスト */
    private Vector3 pushMouseButtonPos = new Vector3(0.0f, 0.0f, 0.0f);     /* マウス押下時座標 */

    private Vector3 buf_player_vec;
    int buf_square_num;
    int buf_count;
    private List<int> buf_next_square_list = new List<int>();                   /* 次移動可能マス番号 */

    public GameObject OkButton;
    public GameObject NgButton;

    public int current_square_num;                                          /* 現在のマス位置 */
    [SerializeField]
    private List<int> next_square_list = new List<int>();                   /* 次移動可能マス番号 */

    [SerializeField]
    Canvas DialogCanvas;

    const float CLICK_RANGE = 0.45f;                                        /* クリック判定範囲　*/

    // Use this for initialization
    void Start () {
        for (int i = 1; i < square_num + 1; i++)
        {
            SquareList.Add(GameObject.Find("square_" + i.ToString()));
        }

        DialogCanvas.enabled = false;
        OkButton = GameObject.Find("OKButton");
        NgButton = GameObject.Find("NGButton");

        transform.position = SquareList[0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        switch ((ButtonFlag)DialogCanvas.GetComponent<DialogManager>().push_flag)
        {
            case ButtonFlag.NONE_BUTTON:
                break;
            case ButtonFlag.OK_BUTTON:
                MovePlayer();
                DialogCanvas.GetComponent<DialogManager>().push_flag = (int)ButtonFlag.NONE_BUTTON;
                break;
            case ButtonFlag.NG_BUTTON:
            case ButtonFlag.UNKNOWN_BUTTON:
            default:
                DialogCanvas.GetComponent<DialogManager>().push_flag = (int)ButtonFlag.NONE_BUTTON;
                return;
        }

        if (DialogCanvas.enabled == false)
        {
            buf_player_vec = ClickObjectCheck();

        }
    }

    /* クリック時オブジェクトがあるかチェック */
    private Vector3 ClickObjectCheck()
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
                    int i, j;
                    /* 移動可能マスチェック */
                    for (i = 0; i < next_square_list.Count; i++)
                    {
                        if (next_square_list[i] == obj.GetComponent<SquareManager>().square_num)
                        {
                            break;
                        }
                    }


                    /* もし一致するものがあるならば */
                    if (i < next_square_list.Count)
                    {
                        buf_square_num = obj.GetComponent<SquareManager>().square_num;
                        buf_count = obj.GetComponent<SquareManager>().GetNextSquareCount();

                        buf_next_square_list.Clear();
                        for (j = 0; j < buf_count; j++)
                        {
                            buf_next_square_list.Add(obj.GetComponent<SquareManager>().GetNextSquareNum(j));
                        }

                        DialogCanvas.enabled = true;

                        return obj.transform.position;
                    }
                }
            }
        }
        return transform.position;
    }

    private void MovePlayer()
    {
        int i;
        transform.position = buf_player_vec;
        current_square_num = buf_square_num;

        next_square_list.Clear();
        for (i = 0; i < buf_next_square_list.Count; i++)
        {
            next_square_list.Add(buf_next_square_list[i]);
        }
    }
}
