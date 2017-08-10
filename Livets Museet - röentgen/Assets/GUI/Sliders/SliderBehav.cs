using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderBehav : MonoBehaviour {

    public GameObject mAppController;
    public Text valueDisplayer;

    public float value = 0;

    private void Update()
    {
          valueDisplayer.text = SetNewValueEvery5Unitys(gameObject.GetComponent<Slider>().value).ToString();
    }

    public void IncreaseButton()
    {
        if (this.gameObject.GetComponent<Slider>().value + 5 <= this.gameObject.GetComponent<Slider>().maxValue) this.gameObject.GetComponent<Slider>().value += 5;
    }

    public void DecreaseButton()
    {
        if (this.gameObject.GetComponent<Slider>().value + 5 >= this.gameObject.GetComponent<Slider>().minValue) this.gameObject.GetComponent<Slider>().value -= 5;
    }   

    public void updateSliderValue(Slider v)
    {
        value = SetNewValueEvery5Unitys(gameObject.GetComponent<Slider>().value);

        gameObject.GetComponent<Slider>().value = value;
        v.value = gameObject.GetComponent<Slider>().value;
        valueDisplayer.text = v.value.ToString();
    }
    


    private static float SetNewValueEvery5Unitys(float value)
    {
       // value = this.gameObject.GetComponent<Slider>().value;

        if (value > 140 && value <= 145) value = 145;
        else if (value > 145 && value <= 150) value = 150;
        else if (value > 150 && value <= 155) value = 155;
        else if (value > 155 && value <= 160) value = 160;
        else if (value > 160 && value <= 165) value = 165;
        else if (value > 165 && value <= 170) value = 170;
        else if (value > 170 && value <= 175) value = 175;
        else if (value > 175 && value <= 180) value = 180;
        else if (value > 180 && value <= 185) value = 185;
        return value;
    }
}
