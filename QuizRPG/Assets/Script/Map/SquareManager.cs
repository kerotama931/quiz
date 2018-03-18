using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class SquareType
{
    public const int SQUARE_TYPE_START = 0;
    public const int SQUARE_TYPE_ENEMY = 1;
    public const int SQUARE_TYPE_TRESURE = 2;
    public const int SQUARE_TYPE_GOAL = 3;
}

static class SquareManagerErrorCode
{
    public const int SQUARE_MANAGER_ERROR_CODE = -1;
}

public class SquareManager : MonoBehaviour {

    public int square_type;
    public int square_num;

    [SerializeField]
    private List<int> next_square;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* 移動可能マスリストのサイズ（カウント）を返す */
    public int GetNextSquareCount()
    {
        return next_square.Count;
    }

    public int GetNextSquareNum(int index)
    {
        if(next_square.Count < index)
        {
            return SquareManagerErrorCode.SQUARE_MANAGER_ERROR_CODE;
        }
        return next_square[index];
    }
}
