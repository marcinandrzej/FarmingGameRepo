using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceMenuScript : MonoBehaviour
{
    public static ResourceMenuScript instance;

    public GameObject resourcesPanel;
    public Sprite[] resourcesSprites;

    private GameObject[] resourcesImages;
    private GameObject[] resourcesTxt;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        SetUp();
        UpdateResource(4, 124);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetUp()
    {
        resourcesImages = new GameObject[resourcesSprites.Length];
        resourcesTxt = new GameObject[resourcesSprites.Length];

        float offsetX = 5.0f;

        float buttonW = (Mathf.Abs(resourcesPanel.GetComponent<RectTransform>().sizeDelta.x) - (2 * offsetX)) / (float)resourcesSprites.Length;
        float buttonH = Mathf.Abs(resourcesPanel.GetComponent<RectTransform>().sizeDelta.y);

        float buttonSize = Mathf.Min(buttonW, buttonH);

        float textH = buttonH - buttonSize;

        for (int i = 0; i < resourcesSprites.Length; i++)
        {
            resourcesImages[i] = GuiScript.instance.CreateImage("Image" + i.ToString(), resourcesPanel.transform,
                new Vector2(buttonSize, buttonSize), new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1),
                new Vector2(0, 1), new Vector2((offsetX + buttonSize * i), 0), resourcesSprites[i], Image.Type.Sliced);
            resourcesTxt[i] = GuiScript.instance.CreateText("Image" + i.ToString(), resourcesPanel.transform,
                new Vector2(buttonSize, textH), new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1),
                new Vector2(0, 1), new Vector2((offsetX + buttonSize * i), -buttonSize), "0", new Color32(255, 255, 255, 255),
                true, Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font, TextAnchor.MiddleCenter, FontStyle.Normal);
        }
    }

    public void UpdateResource(int resource, int count)
    {
        resourcesTxt[resource].GetComponent<Text>().text = count.ToString();
    }
}
