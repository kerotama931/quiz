using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    public GameObject backGround;
    public GameObject backGround_right_top;
    public GameObject backGround_left_top;
    public GameObject[] Square = new GameObject[8];

    private Vector2 MousePosDownPrev;   /* マウス押下中の座標（ひとつ前） */
    private Vector2 MousePosDown;       /* マウス押下中の座標 */

    const float DRAG_RATE = 30.0f;

	// Use this for initialization
	void Start () {
        backGround = GameObject.Find("BackImage");
        backGround_right_top = GameObject.Find("CameraRangeRightTop");

        MousePosDownPrev = new Vector2(0.0f, 0.0f);     /* マウス押下中座標(ひとつ前)の更新 */
        MousePosDown = new Vector2(0.0f, 0.0f);         /* マウス押下中座標の更新 */

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

            this.transform.position = new Vector3(Mathf.Clamp(transform.position.x - diffVec.x / DRAG_RATE, 0.0f, backGround_right_top.transform.position.x), transform.position.y, transform.position.z);

            MousePosDownPrev = Input.mousePosition;
        }
    }

    public void PushSquare()
    {

    }
}
