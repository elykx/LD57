using System.Collections.Generic;
using UnityEngine;

public static class Shuffle
{
    public static List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            (list[i], list[rnd]) = (list[rnd], list[i]);
        }
        return list;
    }
}