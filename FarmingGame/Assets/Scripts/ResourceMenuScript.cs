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
    private GameObject[] resourceCostTxt;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        SetUp();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetUp()
    {
        resourcesImages = new GameObject[resourcesSprites.Length];
        resourcesTxt = new GameObject[resourcesSprites.Length];
        resourceCostTxt = new GameObject[resourcesSprites.Length];

        float offsetX = 5.0f;
        float offsetY = 5.0f;

        float buttonW = (Mathf.Abs(resourcesPanel.GetComponent<RectTransform>().sizeDelta.x) - (2 * offsetX)) / (float)resourcesSprites.Length;
        float buttonH = Mathf.Abs(resourcesPanel.GetComponent<RectTransform>().sizeDelta.y) - (2 * offsetY);

        float buttonSize = Mathf.Min(buttonW, buttonH);

        float textH = (buttonH - buttonSize)/2;

        for (int i = 0; i < resourcesSprites.Length; i++)
        {
            resourcesImages[i] = GuiScript.instance.CreateImage("Image" + i.ToString(), resourcesPanel.transform,
                new Vector2(buttonSize, buttonSize), new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1),
                new Vector2(0, 1), new Vector2((offsetX + buttonSize * i), -offsetY), resourcesSprites[i], Image.Type.Sliced);
            resourcesTxt[i] = GuiScript.instance.CreateText("Text" + i.ToString(), resourcesPanel.transform,
                new Vector2(buttonSize, textH), new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1),
                new Vector2(0, 1), new Vector2((offsetX + buttonSize * i), -buttonSize - offsetY), "0", new Color32(255, 255, 255, 255),
                true, Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font, TextAnchor.MiddleCenter, FontStyle.Normal);
            resourceCostTxt[i] = GuiScript.instance.CreateText("CostTxt" + i.ToString(), resourcesPanel.transform,
                new Vector2(buttonSize, textH), new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1),
                new Vector2(0, 1), new Vector2((offsetX + buttonSize * i), -(buttonH - textH) - offsetY), "0", new Color32(255, 0, 0, 255),
                true, Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font, TextAnchor.MiddleCenter, FontStyle.Normal);
            resourceCostTxt[i].SetActive(false);
        }
    }

    public void UpdateResources(Dictionary<RESOURCES, int> dict)
    {
        for (int i = 0; i < resourcesTxt.Length - 1; i++)
        {
            resourcesTxt[i].GetComponent<Text>().text = dict[(RESOURCES)i].ToString();
        }
    }

    public void UpdateCoins(int coins)
    {
        resourcesTxt[resourcesTxt.Length - 1].GetComponent<Text>().text = coins.ToString();
    }

    public void UpdateCost(Dictionary<RESOURCES, int> dict, int coins)
    {
        for (int i = 0; i < resourceCostTxt.Length - 1; i++)
        {
            resourceCostTxt[i].GetComponent<Text>().text = dict[(RESOURCES)i].ToString();
            if (dict[(RESOURCES)i] == 0)
            {
                resourceCostTxt[i].SetActive(false);
            }
            else
            {
                if (dict[(RESOURCES)i] > 0)
                {
                    resourceCostTxt[i].GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                }
                else
                {
                    resourceCostTxt[i].GetComponent<Text>().color = new Color32(255, 0, 0, 255);
                }
                resourceCostTxt[i].SetActive(true);
            }
        }
        resourceCostTxt[resourceCostTxt.Length - 1].SetActive(true);
        resourceCostTxt[resourceCostTxt.Length - 1].GetComponent<Text>().text = coins.ToString();
    }

    public void HideCost()
    {
        for (int i = 0; i < resourceCostTxt.Length; i++)
        {
            resourceCostTxt[i].SetActive(false);
        }
    }
}
