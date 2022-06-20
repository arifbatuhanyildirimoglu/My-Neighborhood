using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollower : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Store"))
        {
            target = GameObject.FindGameObjectWithTag("Cart").transform;
            offset = transform.position - target.position;
        }else if (SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - target.position;    
        }
        
    }

    void FixedUpdate(){
        
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + offset.y, offset.z + target.position.z);

        if (SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            transform.position = Vector3.SmoothDamp(transform.position,newPosition, ref velocity,0.2f);
        }
        else
        {
            transform.position = newPosition;
        }
        
    }
    
}
