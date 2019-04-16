using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UMessengerManager
{
    public delegate void Callback();
    public delegate void Callback<T>(T arg1);
    public delegate void Callback<T, U>(T arg1, U arg2);
    public delegate void Callback<T, U, V>(T arg1, U arg2, V arg3);

    public static Dictionary<string, Delegate> eventDic = new Dictionary<string, Delegate>();
    public static void AddListener(string eventvar, Callback callback)
    {
        if (!eventDic.ContainsKey(eventvar))
        {
            eventDic.Add(eventvar, callback);
        }
        else
        {
            eventDic[eventvar] = (Callback)eventDic[eventvar] + callback;
        }
    }
    public static void AddListener<T>(string eventvar, Callback<T> callback)
    {
        if (!eventDic.ContainsKey(eventvar))
        {
            eventDic.Add(eventvar, callback);
        }
        else
        {
            eventDic[eventvar] = (Callback<T>)eventDic[eventvar] + callback;
        }
    }
    public static void AddListener<T,U>(string eventvar, Callback<T,U> callback)
    {
        if (!eventDic.ContainsKey(eventvar))
        {
            eventDic.Add(eventvar, callback);
        }
        else
        {
            eventDic[eventvar] = (Callback<T,U>)eventDic[eventvar] + callback;
        }
    }
    public static void AddListener<T,U,V>(string eventvar, Callback<T, U, V> callback)
    {
        if (!eventDic.ContainsKey(eventvar))
        {
            eventDic.Add(eventvar, callback);
        }
        else
        {
            eventDic[eventvar] = (Callback<T, U, V>)eventDic[eventvar] + callback;
        }
    }

    public static void RemoveListener(string eventvar)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            eventDic.Remove(eventvar);
        }
    }
    public static void RemoveListener(string eventvar, Callback callback)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            var allhandle = eventDic[eventvar];
            if (allhandle == null)
            {
                eventDic.Remove(eventvar);
            }
            else
            {
                try
                {
                    eventDic[eventvar] = (Callback)eventDic[eventvar] - callback;
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
        CheckListener(eventvar);
    }
    public static void RemoveListener<T>(string eventvar,Callback<T> callback)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            try
            {
                eventDic[eventvar] = (Callback<T>)eventDic[eventvar] - callback;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        CheckListener(eventvar);
    }
    public static void RemoveListener<T,U>(string eventvar, Callback<T,U> callback)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            try
            {
                eventDic[eventvar] = (Callback<T, U>)eventDic[eventvar] - callback;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        CheckListener(eventvar);
    }
    public static void RemoveListener<T,U,V>(string eventvar, Callback<T,U,V> callback)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            try
            {
                eventDic[eventvar] = (Callback<T, U, V>)eventDic[eventvar] - callback;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        CheckListener(eventvar);
    }
    private static void CheckListener(string eventvar)
    {
        if (eventDic.ContainsKey(eventvar) && eventDic[eventvar] == null)
        {
            eventDic.Remove(eventvar);
        }
    }
    public static void Broadcast(string eventvar)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            if (eventDic.TryGetValue(eventvar, out Delegate d))
            {
                if (d != null)
                {
                    foreach (var del in d.GetInvocationList())
                    {
                        del.Method.Invoke(del.Target, null);
                    }
                }
            }
        }
    }
    public static void Broadcast<T>(string eventvar,T arg1)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            if (eventDic.TryGetValue(eventvar, out Delegate d))
            {
                if (d != null)
                {
                    foreach (var del in d.GetInvocationList())
                    {
                        del.Method.Invoke(del.Target, new object[1] { arg1 });
                    }
                }
            }
        }
    }
    public static void Broadcast<T,U>(string eventvar,T arg1,U arg2)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            if (eventDic.TryGetValue(eventvar, out Delegate d))
            {
                if (d != null)
                {
                    foreach (var del in d.GetInvocationList())
                    {                       
                        del.Method.Invoke(del.Target, new object[2] { arg1, arg2 });
                    }
                }
            }
        }
    }
    public static void Broadcast<T, U,V>(string eventvar, T arg1, U arg2, V arg3)
    {
        if (eventDic.ContainsKey(eventvar))
        {
            if (eventDic.TryGetValue(eventvar, out Delegate d))
            {
                if (d != null)
                {
                    foreach (var del in d.GetInvocationList())
                    {
                        del.Method.Invoke(del.Target, new object[3] { arg1, arg2 , arg3 });
                    }
                }
            }
        }
    }  
 }

