using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace Main
{
    public partial class PlayerPanel : GComponent
    {
        public int uid;

        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            lstCard.itemRenderer = CardIR;
            lstTask.itemRenderer = TaskIR;
            btnAdd.onClick.Add(AddTrick);
            btnMinus.onClick.Add(MinusTrick);
            btnChangePosTask.onClick.Add(OnClickTaskList);
            btnChangePosCard.onClick.Add(OnClickCardList);
            isCaptain.onChanged.Add(()=>DataManager.inst.GetPlayerData(uid).isCaptain = isCaptain.selectedIndex);
            hasTip.onChanged.Add(()=>DataManager.inst.GetPlayerData(uid).hasHint = hasTip.selectedIndex);
        }

        private void OnClickCardList()
        {
            MainWin win = UIStarter.inst.mainWin;
            if (win.state.selectedIndex != 2) return;
            Card card = UIStarter.inst.mainWin.currShownCard;
            DataManager.inst.ChangeCardPos(card.isTask, card.uid, card.index,uid);
            win.State2_0();
        }
        private void OnClickTaskList()
        {
            MainWin win = UIStarter.inst.mainWin;
            if (win.state.selectedIndex != 2) return;
            Card card = UIStarter.inst.mainWin.currShownCard;
            DataManager.inst.ChangeCardPos(card.isTask, card.uid, card.index,uid);
            win.State2_0();
        }

        public void SetUid(int uid)
        {
            this.uid = uid;
            txtName.SetVar("name", DataManager.inst.GetPlayerData(uid).name).FlushVars();
            UpdateCardView();
            UpdateTaskView();
            UpdatreTrick();
            isCaptain.selectedIndex = DataManager.inst.GetPlayerData(uid).isCaptain;
            hasTip.selectedIndex = DataManager.inst.GetPlayerData(uid).hasHint;
        }

        private void UpdateCardView()
        {
            lstCard.numItems = DataManager.inst.GetPlayerData(uid).cards.Count;
        }

        private void UpdateTaskView()
        {
            lstTask.numItems = DataManager.inst.GetPlayerData(uid).tasks.Count;
        }

        private void CardIR(int index, GObject item)
        {
            PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
            Card card = (Card)item;
            bool front = index == data.tipCardIndex || uid == DataManager.inst.uid;
            card.tip.selectedIndex = index == data.tipCardIndex ? data.tipCardType:0;
            card.image.url = "ui://Main/" + (front ? ("cardFront" + data.cards[index].ToString()) : "cardBack");
            card.uid = uid;
            card.isTask = false;
            card.index = index;
            card.SetAsMovable();
        }

        private void TaskIR(int index, GObject item)
        {
            Card card = (Card)item;
            PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
            if (IsBitSet(data.taskFinished, card.index))
            {
                card.image.url = "ui://Main/taskBack" + TaskIndex.index[data.tasks[index]].ToString();
            }
            else { 
                card.image.url = "ui://Main/taskFront" + (data.tasks[index] + 1).ToString();
            }
            card.uid = uid;
            card.isTask = true;
            card.index = index;
            card.SetAsMovable();
        }

        private bool IsBitSet(int num, int bitIndex)
        {
            return (num & (1 << bitIndex)) != 0;
        }

        private void UpdatreTrick()
        {
            txtTrick.SetVar("trick", DataManager.inst.GetPlayerData(uid).trick.ToString()).FlushVars();
        }

        public void AddTrick()
        {
            PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
            data.trick++;
            UpdatreTrick();
        }

        public void MinusTrick()
        {
            PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
            data.trick--;
            UpdatreTrick();
        }
    }
}