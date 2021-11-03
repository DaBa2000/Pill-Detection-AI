using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{

    /// <summary>
    /// Set text size
    /// </summary>
    /// <param name="size">size of text</param>
    public static void SetTextSize(float size)
    {
        // find all text components
        var textComponents = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI cmp in textComponents)
        {
            if (cmp.gameObject.tag != "Title")
            {
                // rescale text to normal size by dividing by current text size
                // afterwards scale to set size by multiplying by size
                cmp.fontSize = cmp.fontSize / GameController.textSize * size;
            }
        }

        GameController.textSize = size;
    }
}
