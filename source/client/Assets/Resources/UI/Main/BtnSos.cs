/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class BtnSos : GButton
    {
        public Controller sos;
        public const string URL = "ui://kkz7vzrdj1354s";

        public static BtnSos CreateInstance()
        {
            return (BtnSos)UIPackage.CreateObject("Main", "BtnSos");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sos = GetControllerAt(0);
        }
    }
}