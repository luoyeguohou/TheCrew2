/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class HistoryPanel : GComponent
    {
        public GList lstCard;
        public GButton btnClose;
        public const string URL = "ui://kkz7vzrdf9jl4z";

        public static HistoryPanel CreateInstance()
        {
            return (HistoryPanel)UIPackage.CreateObject("Main", "HistoryPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lstCard = (GList)GetChildAt(1);
            btnClose = (GButton)GetChildAt(2);
        }
    }
}