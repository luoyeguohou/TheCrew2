using FairyGUI;
using Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStarter : MonoBehaviour
{
    public static UIStarter inst;
    private void Awake()
    {
        inst = this;
        UIConfig.defaultFont = "Font1";
    }
    public MainWin mainWin;
    void Start()
    {
        UIPackage.AddPackage("UI/Main");
        MainBinder.BindAll();
        GComponent gcom = UIPackage.CreateObject("Main", "MainWin").asCom;
        GRoot.inst.AddChild(gcom);
        gcom.MakeFullScreen();
        mainWin = (MainWin)gcom;
    }
}
