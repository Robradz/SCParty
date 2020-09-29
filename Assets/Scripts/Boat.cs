using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    float timeOfLastSpin = 0f;
    bool spinning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning && Time.time <= timeOfLastSpin + 1.0f)
        {
            transform.Rotate(0f, 360 * Time.deltaTime, 0f);
        }
        else
        {
            spinning = false;
        }
    }

    public void SpinBoat()
    {
        if(Time.time >= timeOfLastSpin + .5f)
        {
            spinning = true;
            timeOfLastSpin = Time.time;
        }
        
    }
}
