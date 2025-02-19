/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class Card : GComponent
    {
        public Controller tip;
        public GLoader image;
        public const string URL = "ui://kkz7vzrdj1354m";

        public static Card CreateInstance()
        {
            return (Card)UIPackage.CreateObject("Main", "Card");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tip = GetControllerAt(0);
            image = (GLoader)GetChildAt(0);
        }
    }
}