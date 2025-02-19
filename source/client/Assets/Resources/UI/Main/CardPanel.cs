/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class CardPanel : GComponent
    {
        public Controller canTip;
        public Controller isTaskInHand;
        public GButton btnTipAsMax;
        public GButton btnTipAsMin;
        public GButton btnTipAsOnly;
        public GButton btnMove;
        public GLoader image;
        public GButton btnUntip;
        public GButton btnClose;
        public GButton btnFinish;
        public const string URL = "ui://kkz7vzrdj1354v";

        public static CardPanel CreateInstance()
        {
            return (CardPanel)UIPackage.CreateObject("Main", "CardPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            canTip = GetControllerAt(0);
            isTaskInHand = GetControllerAt(1);
            btnTipAsMax = (GButton)GetChildAt(2);
            btnTipAsMin = (GButton)GetChildAt(3);
            btnTipAsOnly = (GButton)GetChildAt(4);
            btnMove = (GButton)GetChildAt(5);
            image = (GLoader)GetChildAt(6);
            btnUntip = (GButton)GetChildAt(7);
            btnClose = (GButton)GetChildAt(8);
            btnFinish = (GButton)GetChildAt(9);
        }
    }
}