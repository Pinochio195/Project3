using Ring;
using UnityEngine;

public class PlayerManager : RingSingleton<PlayerManager>
{
    [HeaderTextColor(0.2f, .7f, .8f, headerText = "Player Component")]
    public PlayerController _playerController;
    public PlayerWeapon _playerWeapon;
    protected override void Awake()
    {
        RandomStartPoint();
    }

    private void RandomStartPoint()
    {
        transform.position = _playerController._listTransformStart[Random.Range(0, _playerController._listTransformStart.Count)].position;
    }

    private void Update()
    {
    }

    public void CheckEnemy()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 checkPosition = transform.position;
        Gizmos.DrawWireSphere(checkPosition, _playerController.radius);
    }
}