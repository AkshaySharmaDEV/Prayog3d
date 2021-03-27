using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    public GameObject Wire1;
    public GameObject Wire2;
    public GameObject Wire3;
    public GameObject Nsideammeter;
    public GameObject Ammeter2dc;
    public GameObject p2dc;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("test", Forward);
        actions.Add("connect N side to ammeter", Na);
        actions.Add("connect ammeter to dc", Dcam);
        actions.Add("connect P to dc", P2dc);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void Forward()
    {

        transform.Translate(5,0,0);

    }

    private void Na()
    {
        Wire1.GetComponent<Animator>().Play("n-a");
        Destroy(Nsideammeter);


    }

    private void Dcam()
    {
        Wire2.GetComponent<Animator>().Play("dc-am");
        Destroy(Ammeter2dc);


    }
    private void P2dc()
    {
        Wire3.GetComponent<Animator>().Play("p-dc");
        Destroy(p2dc);


    }
    



    
}
