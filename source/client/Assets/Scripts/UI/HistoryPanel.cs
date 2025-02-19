using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main
{
    public partial class HistoryPanel : GComponent
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            btnClose.onClick.Add(OnClickClose);
            lstCard.itemRenderer = CardIR;
        }

        private void OnClickClose() { 
            MainWin win = UIStarter.inst.mainWin;
            win.UnShowHistory();
        }

        int uid;
        public void SetUid(int uid) { 
            this.uid = uid;
            lstCard.columnCount = DataManager.inst.allData.players.Count;
            lstCard.numItems = DataManager.inst.GetPlayerData(uid).history.Count;
        }

        private void CardIR(int index, GObject item) { 
            Card card = item as Card;
            int cardNum =  DataManager.inst.GetPlayerData(uid).history[index];
            card.image.url = "ui://Main/cardFront" + cardNum.ToString();
        }
    }
}