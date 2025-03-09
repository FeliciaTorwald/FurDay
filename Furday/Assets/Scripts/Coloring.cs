using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloring : MonoBehaviour
{
    private Color baseColor;
    private Color scleraColor;
    private Color beansColor;
    private Color eyesColor;
    private Color patternColor;
    private Color lineArtColor;

    private Image currentImage;
    public FlexibleColorPicker colorPicker;

    public GameObject baseButton;
    public GameObject scleraButton;
    public GameObject beansButton;
    public GameObject eyesButton;
    public GameObject patternButton;
    public GameObject lineArtButton;

    public Image baseImage;
    public Image scleraImage;
    public Image beansImage;
    public Image eyesImage;
    public Image patternImage;
    public Image lineArtImage;
    public void PaintBaseButton()
    {
        colorPicker.gameObject.SetActive(!colorPicker.gameObject.activeSelf);
        if (colorPicker.gameObject.activeSelf)
        {
            currentImage = baseImage;
        }
        else
        {
            currentImage = null;
        }
        colorPicker.GetComponent<RectTransform>().position = baseButton.GetComponent<RectTransform>().position + new Vector3(125, -115.7f, 0);
        if (baseColor.a > 0)
        {
            colorPicker.SetColor(baseColor);
        }
        else
        {
            colorPicker.SetColorNoAlpha(Color.white);
        }
    }

    public void PaintScleraButton()
    {
        colorPicker.gameObject.SetActive(!colorPicker.gameObject.activeSelf);
        if (colorPicker.gameObject.activeSelf)
        {
            currentImage = scleraImage;
        }
        else
        {
            currentImage = null;
        }
        colorPicker.GetComponent<RectTransform>().position = scleraButton.GetComponent<RectTransform>().position + new Vector3(125, -115.7f, 0);

        if (scleraColor.a > 0)
        {
            colorPicker.SetColor(scleraColor);
        }
        else
        {
            colorPicker.SetColorNoAlpha(Color.white);
        }
    }

    public void PaintBeansButton()
    {
        colorPicker.gameObject.SetActive(!colorPicker.gameObject.activeSelf);
        if (colorPicker.gameObject.activeSelf)
        {
            currentImage = beansImage;
        }
        else
        {
            currentImage = null;
        }
        colorPicker.GetComponent<RectTransform>().position = beansButton.GetComponent<RectTransform>().position + new Vector3(125, -115.7f, 0);

        if (beansColor.a > 0)
        {
            colorPicker.SetColor(beansColor);
        }
        else
        {
            colorPicker.SetColorNoAlpha(Color.white);
        }

    }
    public void PaintEyesButton()
    {
        colorPicker.gameObject.SetActive(!colorPicker.gameObject.activeSelf);
        if (colorPicker.gameObject.activeSelf)
        {
            currentImage = eyesImage;
        }
        else
        {
            currentImage = null;
        }
        colorPicker.GetComponent<RectTransform>().position = eyesButton.GetComponent<RectTransform>().position + new Vector3(125, -115.7f, 0);

        if (eyesColor.a > 0)
        {
            colorPicker.SetColor(eyesColor);
        }
        else
        {
            colorPicker.SetColorNoAlpha(Color.white);
        }
    }

    public void PaintPatternButton()
    {
        colorPicker.gameObject.SetActive(!colorPicker.gameObject.activeSelf);
        if (colorPicker.gameObject.activeSelf)
        {
            currentImage = patternImage;
        }
        else
        {
            currentImage = null;
        }
        colorPicker.GetComponent<RectTransform>().position = patternButton.GetComponent<RectTransform>().position + new Vector3(125, -115.7f, 0);

        if (patternColor.a > 0)
        {
            colorPicker.SetColor(patternColor);
        }
        else
        {
            colorPicker.SetColorNoAlpha(Color.white);
        }
    }

    public void PaintLineArtButton()
    {
        colorPicker.gameObject.SetActive(!colorPicker.gameObject.activeSelf);
        if (colorPicker.gameObject.activeSelf)
        {
            currentImage = lineArtImage;
        }
        else
        {
            currentImage = null;
        }
        colorPicker.GetComponent<RectTransform>().position = lineArtButton.GetComponent<RectTransform>().position + new Vector3(125, -115.7f, 0);

        if (lineArtColor.a > 0)
        {
            colorPicker.SetColor(lineArtColor);
        }
        else
        {
            colorPicker.SetColorNoAlpha(Color.white);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        colorPicker.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentImage != null)
        {
            Color color = colorPicker.GetColor();
            if (currentImage == baseImage)
            {
                baseColor = color;
            }
            if (currentImage == scleraImage)
            {
                scleraColor = color;
            }
            if (currentImage == beansImage)
            {
                beansColor = color;
            }
            currentImage.color = color;


        }
    }
}
