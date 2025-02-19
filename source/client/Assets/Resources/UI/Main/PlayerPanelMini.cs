/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class PlayerPanelMini : GComponent
    {
        public Controller isCaptain;
        public Controller hasHint;
        public GTextField txtName;
        public GTextField txtTrick;
        public Card card;
        public GTextField txtCardNum;
        public GButton btnHistory;
        public GList lstTask;
        public const string URL = "ui://kkz7vzrdf9jl4x";

        public static PlayerPanelMini CreateInstance()
        {
            return (PlayerPanelMini)UIPackage.CreateObject("Main", "PlayerPanelMini");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isCaptain = GetControllerAt(0);
            hasHint = GetControllerAt(1);
            txtName = (GTextField)GetChildAt(1);
            txtTrick = (GTextField)GetChildAt(2);
            card = (Card)GetChildAt(5);
            txtCardNum = (GTextField)GetChildAt(7);
            btnHistory = (GButton)GetChildAt(8);
            lstTask = (GList)GetChildAt(11);
        }
    }
}