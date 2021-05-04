using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> Information;
    void Start()
    {
        Information = new Queue<string>(); 
    }


}
