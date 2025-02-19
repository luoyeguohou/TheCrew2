/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class PlayerPanel : GComponent
    {
        public Controller isCaptain;
        public Controller clickableTask;
        public Controller clickableCard;
        public Controller hasTip;
        public GList lstCard;
        public GList lstTask;
        public GTextField txtName;
        public GTextField txtTrick;
        public GButton btnAdd;
        public GButton btnMinus;
        public GGraph btnChangePosTask;
        public GGraph btnChangePosCard;
        public const string URL = "ui://kkz7vzrdj1354p";

        public static PlayerPanel CreateInstance()
        {
            return (PlayerPanel)UIPackage.CreateObject("Main", "PlayerPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isCaptain = GetControllerAt(0);
            clickableTask = GetControllerAt(1);
            clickableCard = GetControllerAt(2);
            hasTip = GetControllerAt(3);
            lstCard = (GList)GetChildAt(1);
            lstTask = (GList)GetChildAt(2);
            txtName = (GTextField)GetChildAt(3);
            txtTrick = (GTextField)GetChildAt(4);
            btnAdd = (GButton)GetChildAt(5);
            btnMinus = (GButton)GetChildAt(6);
            btnChangePosTask = (GGraph)GetChildAt(9);
            btnChangePosCard = (GGraph)GetChildAt(10);
        }
    }
}