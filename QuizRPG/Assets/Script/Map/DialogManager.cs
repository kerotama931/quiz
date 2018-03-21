using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ButtonFlag
{
    NONE_BUTTON = 0,
    OK_BUTTON,
    NG_BUTTON,
    UNKNOWN_BUTTON = 0xFF
}

public class DialogManager : MonoBehaviour {

    public GameObject Canvas;
    public int push_flag = 0;
    
   // enum ButtonFlag button_flag;

    [SerializeField]
    Canvas canvas;
    // Use this for initialization
    void Start () {
       Canvas = GameObject.Find("DialogCanvas");

       // Canvas.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void PushButtonOK()
    {
        canvas.GetComponent<DialogManager>().push_flag = (int)ButtonFlag.OK_BUTTON;
        canvas.enabled = false;

    }

    public void PushButtonNG()
    {
        canvas.GetComponent<DialogManager>().push_flag = (int)ButtonFlag.NG_BUTTON;

        canvas.enabled = false;
    }
}
