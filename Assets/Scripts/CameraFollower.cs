using DG.Tweening;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void FixedUpdate(){
        
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + 14f, offset.z + target.position.z);
        
        transform.position = Vector3.SmoothDamp(transform.position,newPosition, ref velocity,0.2f);
    }
    
}
