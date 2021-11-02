using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClick : MonoBehaviour
{
    public GameObject msgController;
    private Messaging msg;

    int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        msg = msgController.GetComponent<Messaging>();
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;

        if (frameCount % 10 == 0)
        {
            float x = (Input.mousePosition.x - 0.37f * Screen.width) / (Screen.width / 4.0f);
            float y = (Input.mousePosition.y / Screen.height);

            msg.SendMessageToChannel("coord " + x.ToString() + " " + y.ToString());

        }

        if (Input.GetMouseButtonDown(0))
        {
            float x = (Input.mousePosition.x - 0.37f * Screen.width) / (Screen.width / 4.0f);
            float y = (Input.mousePosition.y / Screen.height);

            msg.SendMessageToChannel("arr " + x.ToString() + " " + y.ToString());
        }
    }

    
}
