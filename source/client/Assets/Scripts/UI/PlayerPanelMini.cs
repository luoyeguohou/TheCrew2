using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

namespace Main
{
    public partial class PlayerPanelMini : GComponent
    {
        public int uid;

        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            lstTask.itemRenderer = TaskIR;
        }
        public void SetUid(int uid)
        {
            this.uid = uid;
            PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
            txtName.SetVar("name", data.name).FlushVars();
            txtTrick.SetVar("trick", data.trick.ToString()).FlushVars();
            isCaptain.selectedIndex = data.isCaptain;
            hasHint.selectedIndex = data.hasHint;
            txtCardNum.SetVar("num", data.cards.Count.ToString()).FlushVars();
            if (data.tipCardIndex == -1)
            {
                card.image.url = "ui://Main/cardBack";
                card.tip.selectedIndex = 0;
            }
            else
            { 
                card.image.url = "ui://Main/cardFront" +data.cards[data.tipCardIndex].ToString();
                card.tip.selectedIndex = data.tipCardType;
            }

            btnHistory.onClick.Add(OnClickHistory);

            lstTask.numItems = data.tasks.Count;
        }

        private void OnClickHistory()
        {
            MainWin win = UIStarter.inst.mainWin;
            win.ShowHistory(uid);
        }

        private void TaskIR(int index, GObject item)
        {
            Card card = (Card)item;
            PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
            if (IsBitSet(data.taskFinished, card.index))
            {
                card.image.url = "ui://Main/taskBack" + TaskIndex.index[data.tasks[index]].ToString();
            }
            else
            {
                card.image.url = "ui://Main/taskFront" + (DataManager.inst.GetPlayerData(uid).tasks[index] + 1).ToString();
            }
            card.uid = uid;
            card.isTask = true;
            card.index = index;
        }

        private bool IsBitSet(int num, int bitIndex)
        {
            return (num & (1 << bitIndex)) != 0;
        }

    }
}
