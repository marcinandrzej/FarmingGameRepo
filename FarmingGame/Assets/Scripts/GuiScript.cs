using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiScript : MonoBehaviour
{
    public static GuiScript instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public GameObject CreateButton(string name, Transform parent, Vector2 _sizeDelta, Vector2 _anchorMin, Vector2 _anchorMax,
        Vector3 _localScale, Vector2 _pivot, Vector2 _anchoredPosition, Sprite _sprite, Image.Type type)
    {
        GameObject button = new GameObject(name);
        button.transform.SetParent(parent);

        button.AddComponent<RectTransform>();
        button.AddComponent<Image>();
        button.AddComponent<Button>();

        //Set RectTransform
        button.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
        button.GetComponent<RectTransform>().anchorMin = _anchorMin;
        button.GetComponent<RectTransform>().anchorMax = _anchorMax;
        button.GetComponent<RectTransform>().localScale = _localScale;
        button.GetComponent<RectTransform>().pivot = _pivot;
        button.GetComponent<RectTransform>().anchoredPosition = _anchoredPosition;

        //Set Image
        button.GetComponent<Image>().sprite = _sprite;
        button.GetComponent<Image>().type = type;
        return button;
    }

    public GameObject[] FillWithButtons(GameObject panel, int buttonsInRow, Sprite[] buttonsSprites)
    {
        int buttonsCount = buttonsSprites.Length;
        GameObject[] buttons = new GameObject[buttonsCount];

        int currentButtons = 0;
        int rowsCount = Mathf.CeilToInt((float)buttonsCount / (float)buttonsInRow);

        float buttonW = Mathf.Abs(panel.GetComponent<RectTransform>().sizeDelta.x) / (float)buttonsInRow;
        float buttonH = Mathf.Abs(panel.GetComponent<RectTransform>().sizeDelta.y) / (float)rowsCount;

        float buttonSize = Mathf.Min(buttonW, buttonH);
        float offset = buttonSize / 2.0f;

        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < buttonsInRow; j++)
            {
                if (currentButtons < buttonsCount)
                {
                    currentButtons++;
                    buttons[i * buttonsInRow + j] = CreateButton("Button" + (i * buttonsInRow + j).ToString(), panel.transform,
                       new Vector2(buttonSize, buttonSize), new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1),
                       new Vector2(0.5f, 0.5f), new Vector2((offset + j * buttonSize), (-offset - i * buttonSize)),
                       buttonsSprites[i * buttonsInRow + j], Image.Type.Sliced);
                }
            }
        }
        return buttons;
    }

    public GameObject CreateImage(string name, Transform parent, Vector2 _sizeDelta, Vector2 _anchorMin, Vector2 _anchorMax,
        Vector3 _localScale, Vector2 _pivot, Vector2 _anchoredPosition, Sprite _sprite, Image.Type type)
    {
        GameObject image = new GameObject(name);
        image.transform.SetParent(parent);

        image.AddComponent<RectTransform>();
        image.AddComponent<Image>();

        //Set RectTransform
        image.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
        image.GetComponent<RectTransform>().anchorMin = _anchorMin;
        image.GetComponent<RectTransform>().anchorMax = _anchorMax;
        image.GetComponent<RectTransform>().localScale = _localScale;
        image.GetComponent<RectTransform>().pivot = _pivot;
        image.GetComponent<RectTransform>().anchoredPosition = _anchoredPosition;

        //Set Image
        image.GetComponent<Image>().sprite = _sprite;
        image.GetComponent<Image>().type = type;
        return image;
    }

    public GameObject CreateText(string name, Transform parent, Vector2 _sizeDelta, Vector2 _anchorMin, Vector2 _anchorMax,
        Vector3 _localScale, Vector2 _pivot, Vector2 _anchoredPosition, string _text, Color32 _color,
        bool _resizeTextForBestFit, Font _font, TextAnchor _textAnchor, FontStyle _fontStyle)
    {
        GameObject textObject = new GameObject(name);
        textObject.transform.SetParent(parent);
        textObject.AddComponent<RectTransform>();
        textObject.AddComponent<Text>();

        //Set RectTransform
        textObject.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
        textObject.GetComponent<RectTransform>().anchorMin = _anchorMin;
        textObject.GetComponent<RectTransform>().anchorMax = _anchorMax;
        textObject.GetComponent<RectTransform>().localScale = _localScale;
        textObject.GetComponent<RectTransform>().pivot = _pivot;
        textObject.GetComponent<RectTransform>().anchoredPosition = _anchoredPosition;

        //Set Text
        textObject.GetComponent<Text>().resizeTextForBestFit = _resizeTextForBestFit;
        textObject.GetComponent<Text>().font = _font;
        //Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        textObject.GetComponent<Text>().alignment = _textAnchor;
        //TextAnchor.MiddleCenter;
        textObject.GetComponent<Text>().fontStyle = _fontStyle;
        //FontStyle.Bold;
        textObject.GetComponent<Text>().color = _color;
        textObject.GetComponent<Text>().text = _text;

        return textObject;
    }
}
