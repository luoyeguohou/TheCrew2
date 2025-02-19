

public struct PlayerRawData {

    public string data;
    public int uid;
    public string name;
}

public struct MsgRecv
{
    public string cmd;
    public string data;
    public MsgRecv(string cmd,string data) { 
        this.cmd = cmd;
        this.data = data;
    }
}

public struct RMsgRequestUid
{
    public int uid;
    public string name;
    public string publicData;
    public PlayerRawData[] players;
}

public struct MsgRequestUid
{
    public string cmd;
    public string name;
    public MsgRequestUid(string name)
    {
        cmd = MsgStr.msg_recv_uid;
        this.name = name;
    }
}

public struct MsgUpdateStatus
{
    public int uid;
    public string data;
    public string name;
    public MsgUpdateStatus(int uid, string data, string name)
    {
        this.uid = uid;
        this.data = data;
        this.name = name;
    }
}
public class MsgStr { 
    public const string msg_recv_uid = "RequestUid";
    public const string msg_update_status = "UpdateStatus";
    public const string msg_update_public_status = "UpdatePublicStatus";
    public const string Heart = "Heart";
}