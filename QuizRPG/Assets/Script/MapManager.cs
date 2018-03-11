using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {


    private GameObject mainCamera;

    public GameObject player;
    public GameObject backGround;
    public GameObject backGround_right_top;
    public GameObject backGround_left_top;
    public GameObject[] Square;

    private Vector2 MousePosDownPrev;   /* マウス押下中の座標（ひとつ前） */
    private Vector2 MousePosDown;       /* マウス押下中の座標 */

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");      /* プレイヤー情報初期化 */
        backGround = GameObject.Find("BackImage");
        backGround_right_top = GameObject.Find("CameraRangeRightTop");

        MousePosDownPrev = new Vector2(0.0f, 0.0f);     /* マウス押下中座標(ひとつ前)の更新 */
        MousePosDown = new Vector2(0.0f, 0.0f);         /* マウス押下中座標の更新 */

        player.transform.position = Square[0].transform.position;

}

// Update is called once per frame
void Update () {
        Vector2 diffVec;

        /*マウス押下時処理 */
        if (Input.GetMouseButtonDown(0))
        {
            MousePosDownPrev = Input.mousePosition;
            
        }
        
        /* マウス押下中処理 */
        if (Input.GetMouseButton(0))
        {
            /* マウスポインタの座標取得 */
            MousePosDown = Input.mousePosition;

            diffVec = MousePosDown - MousePosDownPrev;

            this.transform.position = new Vector3(Mathf.Clamp(transform.position.x - diffVec.x / 20.0f, 0.0f, backGround_right_top.transform.position.x), transform.position.y, transform.position.z);

            MousePosDownPrev = Input.mousePosition;
        }
    }
}


public class Player
{
    private Vector2 vec2_Pos;

    public Player()
    {
        vec2_Pos = new Vector2(0.0f, 0.0f);
    }

    public void SetPlayerPos(Vector2 pos)
    {
        vec2_Pos = pos;
    }

};