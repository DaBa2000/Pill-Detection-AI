using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetTextSize(float size)
    {
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                cmp.fontSize = cmp.fontSize / GameController.textSize * size;
            }
        }

        GameController.textSize = size;
    }
}
