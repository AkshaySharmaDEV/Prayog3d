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
    public GameObject Wire4;
    public GameObject Wire5;
    public GameObject Nsideammeter;
    public GameObject Ammeter2dc;
    public GameObject p2dc;
    public GameObject Nv2ndc;
    public GameObject Pv2pdc;
    public GameObject E1;
    public GameObject E2;
    public GameObject E3;
    public GameObject E4;
    public GameObject E5;
    
    

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("test", Forward);
        actions.Add("connect N side to ammeter", Na);
        actions.Add("connect ammeter to dc", Dcam);
        actions.Add("connect P side to dc", P2dc);
        actions.Add("connect negative side of voltmeter to negative dc terminal", Nnv2ndc);
        actions.Add("connect positive side of voltmeter to positive dc terminal", Ppv2pdc);

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
        E1.GetComponent<Animator>().Play("e1");
        // Destroy(Nsideammeter);


    }

    private void Dcam()
    {
        Wire2.GetComponent<Animator>().Play("dc-am");
        E2.GetComponent<Animator>().Play("e2");
    
        


    }
    private void P2dc()
    {
        Wire3.GetComponent<Animator>().Play("p-dc");
        E3.GetComponent<Animator>().Play("e3");
        


    }
    private void Nnv2ndc()
    {
        Wire4.GetComponent<Animator>().Play("nv2ndc");
        E4.GetComponent<Animator>().Play("e4");
        
        


    }

    private void Ppv2pdc()
    {
        Wire5.GetComponent<Animator>().Play("pv2pdc");
        E5.GetComponent<Animator>().Play("e5");
        


    }
    



    
}
