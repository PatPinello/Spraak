using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acquistion : ScriptableObject
{
    public string NPCText = "Hello, my friend.";
    public void AddWordToDictionary(int key, string word)
    {
        Dictionary<int, string> PlayerDictionary = new Dictionary<int,  string>();
        bool keyExists = PlayerDictionary.ContainsKey(key);

        if(!keyExists)
        {
            PlayerDictionary.Add(key, word);
        }
    }
    public void CompareDictionaries(Dictionary<int, string> dictOne, Dictionary<int, string> dictTwo, int key)
    {
        if(dictOne[key].Equals(dictTwo[key]))
        {
            foreach(string dictWord in dictOne.Values)
            {
                foreach(string txtWord in NPCText.Split(new char[]{' ',',',';','.'}))
                {

                }
            }
        }
    }     
}
