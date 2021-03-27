using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class Launcher : MonoBehaviour
{
    public float rotationMin = 0.0f;
    public float rotationMax = 45.0f;
    public Slider rotationSlider;
    public Slider powerSlider;
 
    [SerializeField] float currentRoation = 25.0f;
 
    // Use this for initialization
    void Start()
    {
        rotationSlider = GameObject.Find("RotationSlider").GetComponent<Slider>();
        powerSlider = GameObject.Find("PowerSlider").GetComponent<Slider>();
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(90.0f, 90.0f, rotationSlider.value);
    }
 
    void OnGUI()
    {
        currentRoation = GUI.HorizontalSlider(new Rect(-280.0f, 165.0f, 228.0f, 57.0f), currentRoation, 0.0f, 45.0f);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, currentRoation);
    }
 
}
 