using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager inst;

    public int uid;
    private void Awake()
    {
        inst = this;
        DontDestroyOnLoad(inst);
        Array.Fill(tips, 0);
    }

    private void Start()
    {
        NetManager.BindHandler(MsgStr.msg_recv_uid, OnRecvRequestUid);
        NetManager.BindHandler(MsgStr.msg_update_public_status, OnRecvUpdatePublicStatus);
        NetManager.BindHandler(MsgStr.msg_update_status, OnRecvUpdateStatus);
    }

    public AllData allData = new AllData();
    public int[] tips = new int[40];
    public int campain = 1;

    public void ChangeCardPos(bool isTask, int fromUid, int fromIdx, int toUid)
    {
        int card = RemoveCard(isTask,fromUid,fromIdx);
        AddCard(isTask,toUid,card);
        MsgHandler.Dispatch(Message.UpdateView);
    }

    public PlayerDataNew GetPlayerData(int uid) {
        foreach (var item in allData.players)
        {
            if (item.uid == uid)
                return item;
        }
        return null;
    }
    public bool ContainsUid(int puid) {
        foreach (var item in allData.players)
        {
            if (item.uid == puid)
                return true;
        }
        return false;
    }

    private int RemoveCard(bool isTask, int uid, int idx) {
        int ret;
        if (isTask) {
            if (uid == -1)
            {
                ret = allData.tasks[idx];
                allData.tasks.RemoveAt(idx);
            }
            else
            {
                PlayerDataNew data = GetPlayerData(uid);
                ret = data.tasks[idx];
                data.tasks.RemoveAt(idx);
            }
        }
        else {
            if (uid == -1)
            {
                ret = allData.cards[idx];
                allData.cards.RemoveAt(idx);
            }
            else
            {
                PlayerDataNew data = GetPlayerData(uid);
                // tip change
                if (idx < data.tipCardIndex && data.tipCardIndex != -1)
                {
                    data.tipCardIndex--;
                }
                else if (idx == data.tipCardIndex) 
                { 
                    data.tipCardIndex=-1;
                }

                ret = data.cards[idx];
                data.cards.RemoveAt(idx);

             

            }
        }
        return ret;
    }

    private void AddCard(bool isTask,int uid,int card) {
        if (isTask)
        {
            if (uid == -1)
            {
                allData.tasks.Add(card);
            }
            else
            {
                PlayerDataNew data = GetPlayerData(uid);
                data.tasks.Add(card);
            }
        }
        else
        {
            if (uid == -1)
            {
                allData.cards.Add(card);
            }
            else
            {
                PlayerDataNew data = GetPlayerData(uid);
                data.cards.Add(card);
            }
        }
    }
    private void OnRecvUpdatePublicStatus(string rawData)
    {
        Debug.Log(rawData);
        allData = JsonMapper.ToObject<AllData>(rawData);
        MsgHandler.Dispatch(Message.UpdateView);
    }
    private void OnRecvUpdateStatus(string rawData)
    {
        Debug.Log("OnRecvUpdateStatus");
        MsgUpdateStatus data = JsonMapper.ToObject<MsgUpdateStatus>(rawData);
        if (!ContainsUid(data.uid)) {
            Debug.Log("Add player "+data.uid.ToString());
            allData.players.Add(new PlayerDataNew(data.uid,data.name));
        }
        MsgHandler.Dispatch(Message.UpdateView);
    }
    private void OnRecvRequestUid(string rawData)
    {
        Debug.Log("OnRecvRequestUid");
        RMsgRequestUid data = JsonMapper.ToObject<RMsgRequestUid>(rawData);
        //set uid
        uid = data.uid;
        foreach (var item in data.players)
        {
            if (!ContainsUid(item.uid))
            {
                allData.players.Add(new PlayerDataNew(item.uid, item.name));
            }
        }
        if (data.publicData != "")
        {
            allData = JsonMapper.ToObject<AllData>(data.publicData);
        }
        MsgHandler.Dispatch(Message.UpdateView);
    }
    public void DealTaskCards(int seed,int aimDiff)
    {
        int[] taskIDs = new int[96];
        for (int i = 0; i < taskIDs.Length; i++)
        {
            taskIDs[i] = i;
        }
        Util.Shuffle(taskIDs, seed);
        int curDiff = 0;
        int index = 0;
        int playerNum = allData.players.Count;
        List<int> tasks = new List<int>();
        while (true)
        {
            int diff = TaskIndex.GetDiff(TaskIndex.GetTaskType(taskIDs[index]), playerNum);
            if (curDiff + diff < aimDiff)
            {
                tasks.Add(taskIDs[index]);
                curDiff += diff;
                index = (index+1)%taskIDs.Length;
            }
            else if (curDiff + diff > aimDiff)
            {
                index = (index+1)%taskIDs.Length;
                continue;
            }
            else if (curDiff + diff == aimDiff)
            {
                tasks.Add(taskIDs[index]);
                curDiff += diff;
                break;
            }
        }
        allData.tasks = tasks;
    }
}

public class AllData {
    public List<int> cards;
    public List<int> tasks;
    public int sosUsed;
    public List<PlayerDataNew> players;
    public int hintNum;
    public AllData() 
    {
        cards = new List<int>();
        tasks = new List<int>();
        players = new List<PlayerDataNew>();
        sosUsed = 0;
    }
}

public class PlayerDataNew {
    public List<int> cards;
    public List<int> tasks;
    public List<int> history;
    public int isCaptain;
    public int hasHint;
    public int trick;
    public int uid;
    public int tipCardIndex;
    public int tipCardType;
    public string name;
    public int taskFinished;

    public PlayerDataNew(int uid,string name) { 
        this.uid = uid;
        this.name = name;
        cards = new List<int>();
        tasks = new List<int>();
        history = new List<int>();
        isCaptain = 0;
        hasHint = 1;
        trick = 0;
        tipCardIndex = -1;
        tipCardType = 0;
        taskFinished = 0;
    }

    public PlayerDataNew() { }
}
