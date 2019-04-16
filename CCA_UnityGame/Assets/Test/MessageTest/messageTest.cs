using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageTest : MonoBehaviour
{
    void Awake()
    {
        //监听消息
        UMessengerManager.AddListener("TestAwake", OnCallBack_1);
        UMessengerManager.AddListener<int>("TestAwake2", OnCallBack_2);
        //发送不带参数广播
        UMessengerManager.Broadcast("TestAwake");
    }

    void Start()
    {
        //发送带参数广播
        UMessengerManager.Broadcast<int>("TestAwake2",1000);
    }
    void OnDestroy()
    {
        //移除监听
        UMessengerManager.RemoveListener("TestAwake", OnCallBack_1);
        UMessengerManager.RemoveListener<int>("TestAwake2", OnCallBack_2);
    }
    //消息回调
    void OnCallBack_1()
    {
        Debug.Log("awake");
    }

    void OnCallBack_2(int num)
    {
        Debug.Log("start" + num);
    }
}
