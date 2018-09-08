using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Singleton<T> where T : class,new()
{
    private static T _instance;
    private static readonly object syslock = new object();

    public static T Inst()
    {
        if (_instance == null)
        {
            lock (syslock)
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
            }
        }
        return _instance;
    }
}  
