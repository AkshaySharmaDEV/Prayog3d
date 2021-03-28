using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class VoiceLoad : MonoBehaviour
{
    
    public GameObject E3;
    public string PNR0;
    public string PNR1;
    
    
    

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("perform pn juction", Perform);
        actions.Add("take reading", Reading);
        

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void Perform()
    {

        SceneManager.LoadScene(PNR0);
        E3.GetComponent<Animator>().Play("e3");

    }

    private void Reading()
    {

        SceneManager.LoadScene(PNR1);
        

    }

    


    
}
