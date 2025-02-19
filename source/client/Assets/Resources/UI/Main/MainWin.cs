/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class MainWin : GComponent
    {
        public Controller state;
        public Controller history;
        public MainCont cont;
        public CardPanel cardPanel;
        public HistoryPanel historyPanel;
        public const string URL = "ui://kkz7vzrdj1354q";

        public static MainWin CreateInstance()
        {
            return (MainWin)UIPackage.CreateObject("Main", "MainWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            history = GetControllerAt(1);
            cont = (MainCont)GetChildAt(2);
            cardPanel = (CardPanel)GetChildAt(3);
            historyPanel = (HistoryPanel)GetChildAt(5);
        }
    }
}