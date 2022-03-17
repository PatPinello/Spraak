using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Acquistion : ScriptableObject
{
    public string NPCText = "Hello, my friend";
    public string displayText;
    public Dictionary<int, string> NPCDict = new Dictionary<int,  string>();
    public Dictionary<int, string> PlayerDictionary = new Dictionary<int,  string>();


    void OnEnable()
    {
        PlayerDictionary.Add(0,"Hello");
        PlayerDictionary.Add(1,"my");
        PlayerDictionary.Add(2,"friend");
        TextToDictionary(NPCText);
        CompareDictionaries(PlayerDictionary, NPCDict);
    }
    public void TextToDictionary(string _npcTxt)
    {
        string cleanTxt = CleanUpText(_npcTxt);
        int _npcKey = NPCDict.Count;

        foreach(string txtWord in cleanTxt.Split(null))
        {
            NPCDict.Add(_npcKey,txtWord);
            _npcKey++;
        }
    }
    public void AddWordToDictionary(int key, string word)
    {



        bool keyExists = PlayerDictionary.ContainsKey(key);

        if(!keyExists)
        {
            PlayerDictionary.Add(key, word);
        }
    }
    public void CompareDictionaries(Dictionary<int, string> dictOne, Dictionary<int, string> dictTwo)
    {
        int count = 0;
            foreach(int dictKey in dictOne.Keys)
            {
                foreach(int npcKey in dictTwo.Keys)
                {
                    if(dictKey.Equals(npcKey))
                    {
                        if(count.Equals(0))
                        {
                            displayText = NPCText.Replace(dictTwo[dictKey], dictOne[npcKey]);
                            count++;
                        }
                        else
                        {
                            displayText = displayText.Replace(dictTwo[dictKey], dictOne[npcKey]);
                            count++;
                        }
                    }
                }
            }
                Debug.Log("\t" + "\t" + displayText);

    }
    public string CleanUpText(string txt)
    {
        string[] cleanTxt = txt.Split(new char[]{ ',', ';', '?', '!', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        string _cleanTxt = string.Join("", cleanTxt);
        return _cleanTxt;
    }
}

