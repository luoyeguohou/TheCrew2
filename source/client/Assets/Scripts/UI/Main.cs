using FairyGUI;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public partial class MainWin : GComponent
    {
        // state 0 not select card 1 select card 2 choose place
        public Card currShownCard;

        public Controller sos;
        public Controller clickableTask;
        public Controller clickableCard;
        public GList lstCard;
        public GList lstTask;
        public GButton btnDealCards;
        public GTextInput txtSeed;
        public GButton btnDealTaskCards;
        public GTextInput txtDifficulty;
        public GList lstPlayers;
        public GButton btnClear;
        public GButton btnUpload;
        public GGraph btnChangePosCard;
        public GGraph btnChangePosTask;
        public GTextField txtHint;
        public GButton btnAddHint;
        public GButton btnMinusHint;
        public PlayerPanel selfPanel;
        public GLoader imgCampain;
        public GButton btnAddCampain;
        public GButton btnMinusCampain;
        public GButton btnTaskCampain;
        public GButton btnReset;
        public GList lstHistory;

        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            sos = cont.sos;
            lstCard = cont.lstCard;
            lstTask = cont.lstTask;
            btnDealCards = cont.btnDealCards;
            txtSeed = cont.txtSeed;
            btnDealTaskCards = cont.btnDealTaskCards;
            txtDifficulty = cont.txtDifficulty;
            lstPlayers = cont.lstPlayers;
            btnClear = cont.btnClear;
            btnUpload = cont.btnUpload;
            btnChangePosCard = cont.btnChangePosCard;
            btnChangePosTask = cont.btnChangePosTask;
            clickableCard = cont.clickableCard;
            clickableTask = cont.clickableTask;
            txtHint = cont.txtHint;
            btnAddHint = cont.btnAddHint;
            btnMinusHint = cont.btnMinusHint;
            selfPanel = cont.selfPanel;
            imgCampain = cont.imgCampain;
            btnAddCampain = cont.btnAddCampain;
            btnMinusCampain = cont.btnMinusCampain;
            btnTaskCampain = cont.btnTaskCampain;
            lstHistory = cont.lstHistory;
            btnReset = cont.btnReset;

            btnDealCards.onClick.Add(DealCards);
            btnDealTaskCards.onClick.Add(DealTaskCards);
            btnClear.onClick.Add(OnClickClear);

            lstTask.itemRenderer = TaskIR;
            lstCard.itemRenderer = CardIR;
            lstPlayers.itemRenderer = PlayerIR;
            btnChangePosTask.onClick.Add(OnClickTaskList);
            btnChangePosCard.onClick.Add(OnClickCardList);
            btnUpload.onClick.Add(Upload);
            sos.onChanged.Add(() => DataManager.inst.allData.sosUsed = sos.selectedIndex);
            btnAddHint.onClick.Add(AddHintNum);
            btnMinusHint.onClick.Add(MinusHintNum);
            lstHistory.itemRenderer = HistoryIR;
            btnAddCampain.onClick.Add(AddCampain);
            btnMinusCampain.onClick.Add(MinusCampain);
            btnTaskCampain.onClick.Add(DealCampainTask);
            btnReset.onClick.Add(ResetHistory);

            MsgHandler.Bind(Message.UpdateView, UpdateAllView);
            initHistory();
            UpdateCampain();
        }

        private void DealCampainTask()
        {
            DataManager.inst.allData.tasks = new List<int> { 37, 46 ,54 , 75 };
            lstTask.numItems = DataManager.inst.allData.tasks.Count;
        }

        private void AddCampain()
        {
            DataManager.inst.campain = Mathf.Clamp(DataManager.inst.campain + 1, 1, 33);
            UpdateCampain();
        }

        private void MinusCampain()
        {
            DataManager.inst.campain = Mathf.Clamp(DataManager.inst.campain - 1, 1, 33);
            UpdateCampain();
        }

        private void UpdateCampain()
        {
            imgCampain.url = "ui://Main/t" + DataManager.inst.campain.ToString();
        }

        private void ResetHistory()
        {
            Array.Fill(DataManager.inst.tips, 0);
            initHistory();
        }

        private void initHistory()
        {
            lstHistory.numItems = 40;
        }

        private void HistoryIR(int index, GObject item)
        {
            Card card = item as Card;
            bool front = DataManager.inst.tips[index] == 0;
            card.image.url = GetHistoryUrl(index, front);
            card.onClick.Add(() =>
            {
                DataManager.inst.tips[index] = DataManager.inst.tips[index] == 0 ? 1 : 0;
                bool front = DataManager.inst.tips[index] == 0;
                card.image.url = GetHistoryUrl(index, front);
            });
        }

        private string GetHistoryUrl(int index, bool front)
        {
            return "ui://Main/" + (front ? "cardFront" + (index + 1).ToString() : "cardBack");
        }

        private void Upload()
        {
            Debug.Log(JsonMapper.ToJson(DataManager.inst.allData));
            NetManager.SendMessageToServer(MsgStr.msg_update_public_status, JsonMapper.ToJson(DataManager.inst.allData));
        }

        private void UpdateAllView()
        {
            UpdateCardView();
            UpdateTaskView();
            UpdatePlayerView();
            UpdateHintView();
        }

        private void AddHintNum()
        {
            DataManager.inst.allData.hintNum++;
            UpdateHintView();
        }
        private void MinusHintNum()
        {
            DataManager.inst.allData.hintNum--;
            UpdateHintView();
        }
        private void UpdateHintView()
        {
            txtHint.SetVar("num", DataManager.inst.allData.hintNum.ToString()).FlushVars();
        }

        private void OnClickClear()
        {
            PlayerDataNew data = DataManager.inst.GetPlayerData(DataManager.inst.uid);

            DataManager.inst.allData.cards.ForEach(card =>
            {
                data.history.Add(card);
            });
            DataManager.inst.allData.cards.Clear();
            UpdateCardView();
        }

        private void OnClickCardList()
        {
            if (state.selectedIndex != 2) return;
            DataManager.inst.ChangeCardPos(currShownCard.isTask, currShownCard.uid, currShownCard.index, -1);
            State2_0();
        }
        private void OnClickTaskList()
        {
            if (state.selectedIndex != 2) return;
            DataManager.inst.ChangeCardPos(currShownCard.isTask, currShownCard.uid, currShownCard.index, -1);
            State2_0();
        }

        public void UpdatePlayerView()
        {
            lstPlayers.numItems = DataManager.inst.allData.players.Count;
            selfPanel.SetUid(DataManager.inst.uid);
        }

        public void UpdateCardView()
        {
            lstCard.numItems = DataManager.inst.allData.cards.Count;
        }

        private void DealCards()
        {
            int[] cards = new int[40];
            for (int i = 1; i <= cards.Length; i++)
            {
                cards[i - 1] = i;
            }
            Util.Shuffle(cards, int.Parse(txtSeed.text));


            foreach (var item in DataManager.inst.allData.players)
            {
                item.cards = new List<int>();
            }

            Dictionary<int, List<int>> cardsWithPlayer = new Dictionary<int, List<int>>();
            int index = 0;
            foreach (int card in cards)
            {
                int uid = DataManager.inst.allData.players[index].uid;
                if (!cardsWithPlayer.ContainsKey(uid))
                {
                    cardsWithPlayer[uid] = new List<int>();
                }
                cardsWithPlayer[uid].Add(card);
                index = (index + 1) % DataManager.inst.allData.players.Count;
            }

            foreach (var item in cardsWithPlayer)
            {
                int uid = item.Key;
                List<int> cardpool = item.Value;
                PlayerDataNew data = DataManager.inst.GetPlayerData(uid);
                data.cards = cardpool;
            }

            MsgHandler.Dispatch(Message.UpdateView);
        }
        private void DealTaskCards()
        {
            DataManager.inst.DealTaskCards(int.Parse(txtSeed.text), int.Parse(txtDifficulty.text));
            lstTask.numItems = DataManager.inst.allData.tasks.Count;
        }

        private void UpdateTaskView()
        {
            lstTask.numItems = DataManager.inst.allData.tasks.Count;
        }

        private void TaskIR(int index, GObject item)
        {
            Card card = item as Card;
            card.image.url = "ui://Main/taskFront" + (DataManager.inst.allData.tasks[index] + 1).ToString();
            card.uid = -1;
            card.isTask = true;
            card.index = index;
            card.SetAsMovable();
        }

        private void CardIR(int index, GObject item)
        {
            Card card = item as Card;
            card.image.url = "ui://Main/cardFront" + DataManager.inst.allData.cards[index].ToString();
            card.uid = -1;
            card.isTask = false;
            card.index = index;
            card.SetAsMovable();
        }

        // todo
        private void PlayerIR(int index, GObject item)
        {
            PlayerPanelMini playerPanel = item as PlayerPanelMini;
            playerPanel.SetUid(DataManager.inst.allData.players[index].uid);
        }

        public void State0_1(Card card)
        {
            if (history.selectedIndex != 0) return;
            if (state.selectedIndex != 0) return;
            currShownCard = card;
            state.selectedIndex = 1;
            cardPanel.image.url = card.image.url;
            cardPanel.canTip.selectedIndex = (!card.isTask) && card.uid != -1 ? 1 : 0;
            cardPanel.isTaskInHand.selectedIndex = (card.isTask && card.uid != -1) ? 1 : 0;
        }

        public void State1_0()
        {
            if (history.selectedIndex != 0) return;
            if (state.selectedIndex != 1) return;
            state.selectedIndex = 0;
            currShownCard = null;
        }

        public void State1_2()
        {
            if (history.selectedIndex != 0) return;
            if (state.selectedIndex != 1) return;
            state.selectedIndex = 2;
            (currShownCard.isTask ? selfPanel.clickableTask : selfPanel.clickableCard).selectedIndex = 1;
            (currShownCard.isTask ? clickableTask : clickableCard).selectedIndex = 1;
        }


        public void State2_0()
        {
            if (history.selectedIndex != 0) return;
            if (state.selectedIndex != 2) return;
            state.selectedIndex = 0;
            selfPanel.clickableCard.selectedIndex = 0;
            selfPanel.clickableTask.selectedIndex = 0;
            clickableCard.selectedIndex = 0;
            clickableTask.selectedIndex = 0;
        }

        public void ShowHistory(int uid) {
            if (state.selectedIndex != 0) return;
            history.selectedIndex = 1;
            historyPanel.SetUid(uid);
        }

        public void UnShowHistory()
        {
            if (state.selectedIndex != 0) return;
            history.selectedIndex = 0;
        }
    }
}