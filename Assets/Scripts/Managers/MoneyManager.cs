using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money;
    public int moneyDPS;
    private float actualTimer;
    private float timer = 1;
    public TextMeshProUGUI moneyText;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (actualTimer < timer)
        {
            actualTimer += 1 * Time.deltaTime;
        }
        else
        {
            actualTimer = 0;
            money += moneyDPS;
            moneyText.text = money.ToString();
        }
    }


}
