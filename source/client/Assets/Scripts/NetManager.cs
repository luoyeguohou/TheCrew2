using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Generic;
using LitJson;

public class NetManager : MonoBehaviour
{
    // net about
    private static TcpClient tcpClient;
    private static NetworkStream networkStream;
    private static StreamReader reader;
    private static StreamWriter writer;
    private static object lockObj = new object();  // ��������������Դ
    public static NetManager inst;

    void Start()
    {
        // ֻ����һ��ʵ��
        inst = this;
        DontDestroyOnLoad(inst);
    }

    public static void Connect(string ipAddress,int portNum)
    {
        // ���ӵ������
        tcpClient = new TcpClient(ipAddress, portNum); // �޸�Ϊ��ķ���˵�ַ�Ͷ˿�
        networkStream = tcpClient.GetStream();
        reader = new StreamReader(networkStream, Encoding.ASCII);
        writer = new StreamWriter(networkStream, Encoding.ASCII) { AutoFlush = true };

        Debug.Log("Connected to server. Type a message to send:");


        Thread receiveThread = new Thread(ReceiveMessages);
        receiveThread.Start();
    }

    public static void SendMessageToServer(string cmd, string message)
    {
        // ������Ϣ��������
        writer.WriteLine(JsonMapper.ToJson(new MsgRecv(cmd, message)));
    }
    static void ReceiveMessages()
    {
        try
        {
            while (true)
            {
                string message = reader.ReadLine();
                if (message != null)
                {
                    Debug.Log(message);
                    MsgRecv msg = JsonMapper.ToObject<MsgRecv>(message);
                    lock (lockObj)
                    {
                        if (handlers.ContainsKey(msg.cmd))
                        {
                            foreach (ReceiveMessageDelegate handler in new List<ReceiveMessageDelegate>(handlers[msg.cmd]))
                            {
                                handler(msg.data);
                            }
                        }
                    }
                }
            }
        }
        catch (IOException)
        {
            Debug.Log("Connection lost.");
        }
    }


    // msg
    public delegate void ReceiveMessageDelegate(string message);
    private static Dictionary<string, List<ReceiveMessageDelegate>> handlers = new Dictionary<string, List<ReceiveMessageDelegate>>();
    public static void BindHandler(string name, ReceiveMessageDelegate handler)
    {
        lock (lockObj)
        {
            if (!handlers.ContainsKey(name))
            {
                handlers[name] = new List<ReceiveMessageDelegate>();
            }
            handlers[name].Add(handler);
        }

    }

    public static void UnbindHandler(string name, ReceiveMessageDelegate handler)
    {
        lock (lockObj)
        {
            if (!handlers.ContainsKey(name))
            {
                return;
            }
            handlers[name].Remove(handler);
        }
    }
}

