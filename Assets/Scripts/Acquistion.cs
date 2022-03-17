using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Acquistion : ScriptableObject
{
    public string NPCText = "Bonjour, mon ami.";
    
    

    void OnEnable()
    {
        TextToDictionary(NPCText);
        
    }
    
    public void TextToDictionary(string _npcTxt)
    {   
        Dictionary<int, string> NPCDict = new Dictionary<int,  string>();
        string cleanTxt = CleanUpText(_npcTxt);
        int _npcKey = NPCDict.Count;

        foreach(string txtWord in cleanTxt.Split(null))
        {
            NPCDict.Add(_npcKey,txtWord);
            _npcKey++;
        }
        Debug.Log(NPCDict[0]);
        Debug.Log(NPCDict[1]);
        Debug.Log(NPCDict[2]);
    }
    public void AddWordToDictionary(int key, string word)
    {
        Dictionary<int, string> PlayerDictionary = new Dictionary<int,  string>();
            PlayerDictionary.Add(1,"Hello");
            PlayerDictionary.Add(2,"my");
            
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
            foreach(int dictKey in dictOne.Keys)
            {
                foreach(int npcKey in dictTwo.Keys)
                { 
                    foreach(string txtWord in NPCText.Split(new char[]{' ',',',';','.'}))
                    {
                        if(dictOne[dictKey].Equals(dictTwo[npcKey]))
                        {

                        }
                    }   
                }
            }
        }
    }
    public string CleanUpText(string txt)
    {
        string[] cleanTxt = txt.Split(new char[]{ ',', ';', '?', '!', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        string _cleanTxt = string.Join("", cleanTxt);
        return _cleanTxt;    
    }     
}

