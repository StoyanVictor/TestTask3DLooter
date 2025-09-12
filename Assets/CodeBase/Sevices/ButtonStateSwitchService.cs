using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStateSwitchService : MonoBehaviourExtBind
{
    [SerializeField] private Button button;
    
    [OnStart]
    public void Init()
    {
        button.onClick.AddListener(() => SwitchStateOnClick());
    }
    
    public void OnButtonPressed()
    {
        button.interactable = false;
    }
    
    [Bind("EnableButton")]
    public void EnableButton()
    {
        button.interactable = true;
    }
    private void SwitchStateOnClick()
    {
        Settings.Fsm.Invoke("Exit");
        OnButtonPressed();
        
    }
}