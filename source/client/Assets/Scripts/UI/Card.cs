using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public partial class Card : GComponent
    {
        public int uid;
        public bool isTask;
        public int index;

        public void SetAsMovable() { 
            onClick.Add(OnClickCard);
        }

        private void OnClickCard() { 
            MainWin win = UIStarter.inst.mainWin;
            if (win.state.selectedIndex != 0) return;
            win.State0_1(this);
        }

    }
}