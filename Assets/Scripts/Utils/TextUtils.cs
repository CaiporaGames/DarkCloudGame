using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace DarkCloudGame
{
    public static class TextUtils
    {
        public static TextMeshPro CreateText(Transform parent, string _text = "", int fontSize = 40, Color? fontColor = null, int sortingOrder = 1)
        {
            if (fontColor == null)
            {
                fontColor = Color.white;
            }
            GameObject textGO = new GameObject("Text", typeof(TextMeshPro));
            TextMeshPro text = textGO.GetComponent<TextMeshPro>();
            textGO.transform.SetParent(parent);
            textGO.transform.position = parent.transform.position;
            text.fontSize = fontSize;
            text.color = (Color)fontColor;
            text.text = _text;
            text.sortingOrder = sortingOrder;
            text.alignment = TextAlignmentOptions.Center;
            return text;
        }
    }
}
