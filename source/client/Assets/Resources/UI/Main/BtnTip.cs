/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class BtnTip : GButton
    {
        public Controller tip;
        public const string URL = "ui://kkz7vzrdf9jl50";

        public static BtnTip CreateInstance()
        {
            return (BtnTip)UIPackage.CreateObject("Main", "BtnTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tip = GetControllerAt(0);
        }
    }
}