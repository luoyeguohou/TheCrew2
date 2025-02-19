/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class MainCont : GComponent
    {
        public Controller sos;
        public Controller clickableTask;
        public Controller clickableCard;
        public GList lstCard;
        public GList lstTask;
        public GButton btnDealCards;
        public GTextInput txtSeed;
        public GButton btnDealTaskCards;
        public GTextInput txtDifficulty;
        public GGraph btnChangePosCard;
        public GGraph btnChangePosTask;
        public GButton btnClear;
        public GButton btnUpload;
        public GTextField txtHint;
        public GButton btnAddHint;
        public GButton btnMinusHint;
        public GList lstPlayers;
        public PlayerPanel selfPanel;
        public GList lstHistory;
        public GLoader imgCampain;
        public GButton btnAddCampain;
        public GButton btnMinusCampain;
        public GButton btnTaskCampain;
        public GButton btnReset;
        public const string URL = "ui://kkz7vzrdosib0";

        public static MainCont CreateInstance()
        {
            return (MainCont)UIPackage.CreateObject("Main", "MainCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sos = GetControllerAt(0);
            clickableTask = GetControllerAt(1);
            clickableCard = GetControllerAt(2);
            lstCard = (GList)GetChildAt(0);
            lstTask = (GList)GetChildAt(1);
            btnDealCards = (GButton)GetChildAt(2);
            txtSeed = (GTextInput)GetChildAt(3);
            btnDealTaskCards = (GButton)GetChildAt(4);
            txtDifficulty = (GTextInput)GetChildAt(5);
            btnChangePosCard = (GGraph)GetChildAt(8);
            btnChangePosTask = (GGraph)GetChildAt(9);
            btnClear = (GButton)GetChildAt(10);
            btnUpload = (GButton)GetChildAt(11);
            txtHint = (GTextField)GetChildAt(13);
            btnAddHint = (GButton)GetChildAt(14);
            btnMinusHint = (GButton)GetChildAt(15);
            lstPlayers = (GList)GetChildAt(16);
            selfPanel = (PlayerPanel)GetChildAt(17);
            lstHistory = (GList)GetChildAt(18);
            imgCampain = (GLoader)GetChildAt(19);
            btnAddCampain = (GButton)GetChildAt(20);
            btnMinusCampain = (GButton)GetChildAt(21);
            btnTaskCampain = (GButton)GetChildAt(22);
            btnReset = (GButton)GetChildAt(23);
        }
    }
}