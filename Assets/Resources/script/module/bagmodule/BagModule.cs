using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BagModule
{
    public delegate void BagInfoChangeDelegate(int ID);
    public static BagInfoChangeDelegate OnBagInfoChange;
    public static List<int> bagList = new List<int>();

    public static void AddItem(int itemID)
    {
        bagList.Add(itemID);
        if (OnBagInfoChange != null)
        {
            OnBagInfoChange.Invoke(itemID);
        }
    }

}
