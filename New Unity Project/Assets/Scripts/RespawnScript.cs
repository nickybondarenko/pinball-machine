using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform respawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        ball.transform.position = respawnPoint.transform.position;
    }
}
