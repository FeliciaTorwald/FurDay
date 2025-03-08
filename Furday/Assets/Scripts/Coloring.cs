using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloring : MonoBehaviour
{
    private Image currentImage;
    public FlexibleColorPicker colorPicker;
    public GameObject baseButton;
    public GameObject scleraButton;
    public Image baseImage;
    public Image scleraImage;
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
        colorPicker.GetComponent<RectTransform>().position = baseButton.GetComponent<RectTransform>().position +new Vector3 (125,-115.7f,0);
        colorPicker.SetColor(Color.red);
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
        colorPicker.SetColor(Color.red);
    }
    // Start is called before the first frame update
    void Start()
    {
        colorPicker.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentImage != null)
        {
            currentImage.color = colorPicker.GetColor();
        }
    }
}
