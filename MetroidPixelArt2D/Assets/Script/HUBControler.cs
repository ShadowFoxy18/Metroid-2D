using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUBControler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPoint, textTime;

    [SerializeField]
    Transform lifesZone;
    [SerializeField]
    GameObject life;

    public void UpdatePointsText(int totalPoints)
    {
        textPoint.text = totalPoints.ToString("0000");
    }

    public void UpdateTimeText(float totalTime)
    {
        textPoint.text = totalTime.ToString("0000");
    }

    public void UpdateLifeText(int lifes)
    {
        
        
        
    }


    void CheckLifes(int lifes)
    {
        
    }

    
    public void CreateLife()
    {
        //Instantiate(life, lifesZone.position,  Quaternion.identity, lifesZone);
    }
}
