using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main
{
    public partial class CardPanel : GComponent
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            btnMove.onClick.Add(OnClickMove);
            btnClose.onClick.Add(OnClickClose);
            btnTipAsMax.onClick.Add(OnClickTipAsMax);
            btnTipAsMin.onClick.Add(OnClickTipAsMin);
            btnTipAsOnly.onClick.Add(OnClickTipAsOnly);
            btnUntip.onClick.Add(OnClickUnTip);
            btnFinish.onClick.Add(OnClickFinish);
        }

        private void SetTipType(int tipType) {
            MainWin win = UIStarter.inst.mainWin;
            Card c = win.currShownCard;
            if (c.uid == -1 || !DataManager.inst.ContainsUid(c.uid))
            {
                return;
            }
            PlayerDataNew data = DataManager.inst.GetPlayerData(c.uid);
            data.tipCardIndex = c.index;
            data.tipCardType = tipType;
            win.State1_0();
            MsgHandler.Dispatch(Message.UpdateView);
        }

        public void OnClickTipAsMax() {
            SetTipType(1);
        }
        public void OnClickTipAsMin() {
            SetTipType(3);

        }
        public void OnClickTipAsOnly() { 
            SetTipType(2);
        }

        public void OnClickClose()
        {
            MainWin win = UIStarter.inst.mainWin;
            win.State1_0();
        }

        public void OnClickFinish() {
            MainWin win = UIStarter.inst.mainWin;
            Card c = win.currShownCard;
            PlayerDataNew data =  DataManager.inst.GetPlayerData(c.uid);
            data.taskFinished = data.taskFinished ^ (1 << c.index);
            MsgHandler.Dispatch(Message.UpdateView);
            win.State1_0();
        }

        public void OnClickUnTip() {
            MainWin win = UIStarter.inst.mainWin;
            Card c = win.currShownCard;
            if (c.uid == -1  || !DataManager.inst.ContainsUid(c.uid))
            {
                return;
            }
            PlayerDataNew data = DataManager.inst.GetPlayerData(c.uid);
            data.tipCardIndex = -1;
            data.tipCardType = 0;
            win.State1_0();
            MsgHandler.Dispatch(Message.UpdateView);
        }
        public void OnClickMove()
        { 
            MainWin win = UIStarter.inst.mainWin;
            win.State1_2();
        }
    }
}