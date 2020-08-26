using UnityEngine;

public class CourseReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
    }

}
