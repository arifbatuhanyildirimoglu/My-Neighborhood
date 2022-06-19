using DG.Tweening;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void LateUpdate(){
        Vector3 newPosition = new Vector3(transform.position.x, target.position.y +8.8f, offset.z + target.position.z);
        transform.DOMove(newPosition, 0.6f);
    }

    void Update()
    {
        
    }
}
