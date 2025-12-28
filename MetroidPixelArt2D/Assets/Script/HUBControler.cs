using TMPro;
using UnityEngine;

public class HUBControler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPoint, textTime, textLife;

    public void UpdatePointsText(string totalPoints)
    {
        textPoint.text = totalPoints;
    }

    public void UpdateTimeText(float totalTime)
    {
        textPoint.text = totalTime.ToString("0000");
    }

    public void UpdateLifeText(int lifes)
    {
        string textLifes = "[] ";
        string textTotalLifes = "";
        for (int i = 0; i < lifes; i++)
        {
            textTotalLifes += textTotalLifes;
        }
        textPoint.text = textLifes;
    }
}
