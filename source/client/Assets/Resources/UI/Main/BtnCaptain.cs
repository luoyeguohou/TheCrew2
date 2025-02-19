/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class BtnCaptain : GButton
    {
        public Controller captain;
        public const string URL = "ui://kkz7vzrdj1354t";

        public static BtnCaptain CreateInstance()
        {
            return (BtnCaptain)UIPackage.CreateObject("Main", "BtnCaptain");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            captain = GetControllerAt(0);
        }
    }
}