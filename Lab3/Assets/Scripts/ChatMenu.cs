using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatMenu : MonoBehaviour
{
    GameObject UICanvas;
    Button Button;
    public void Init()
    {

        ServiceManager.instance.Pause();
        gameObject.SetActive(true);
    }
    public void OnClick()
    {
        ServiceManager.instance.Resume();
        gameObject.SetActive(false);
    
    }
    void Start()
    {
        gameObject.SetActive(false);
      
        Button = GetComponentInChildren<Button>();
        Button.onClick.AddListener(OnClick);
    }

}
