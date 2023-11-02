using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Awake();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake() {
	QualitySettings.vSyncCount = 1;
	Application.targetFrameRate = 60;
}
}
