using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slider2 : MonoBehaviour {

    public Text valueDisplayer;
    public Slider SecSlider;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Slider>().onValueChanged.AddListener(delegate {updateValue();});
    }

    public void IncreaseButton()
    {
        if (gameObject.GetComponent<Slider>().value + 5 <= gameObject.GetComponent<Slider>().maxValue)
        {
            gameObject.GetComponent<Slider>().value += 5;
            updateValue();
        }
    }

    public void DecreaseButton()
    {
        if (gameObject.GetComponent<Slider>().value - 5 >= gameObject.GetComponent<Slider>().minValue)
        {
            gameObject.GetComponent<Slider>().value -= 5;
            updateValue();
        }
    }

    public void updateValue()
    {
            float value = this.gameObject.GetComponent<Slider>().value;

            if (value > 140 && value <= 145) value = 145;
            else if (value > 145 && value <= 150) value = 150;
            else if (value > 150 && value <= 155) value = 155;
            else if (value > 155 && value <= 160) value = 160;
            else if (value > 160 && value <= 165) value = 165;
            else if (value > 165 && value <= 170) value = 170;
            else if (value > 170 && value <= 175) value = 175;
            else if (value > 175 && value <= 180) value = 180;
            else if (value > 180 && value <= 185) value = 185;

            gameObject.GetComponent<Slider>().value = value;
            SecSlider.value = gameObject.GetComponent<Slider>().value;
            valueDisplayer.text = SecSlider.value.ToString();

            value = 0;
    }

    public void DoNothing()
    {
        ;
    }
}
