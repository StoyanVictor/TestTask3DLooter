using AxGrid.Base;
using AxGrid.Model;
using TMPro;
using UnityEngine;

public class CoinCounterService : MonoBehaviourExtBind
{
    [SerializeField] private TextMeshProUGUI coinTxt;
    private int coinCount;
    
    [Bind("ShowCoinsTaken")]
    public void ShowCoinsTaken()
    {
        IncreaseCurrentCoinCount();
        coinTxt.text = "Coins count: " + coinCount;
    }

    public void IncreaseCurrentCoinCount() => coinCount++;

}
