using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] public Transform _meshPlayer;
    [SerializeField] public Animator _animator;

    public void FixedUpdate()
    {
        PlayerManager.Instance._playerController._currentDirection = (Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal).normalized;
        rb.velocity = new Vector3(PlayerManager.Instance._playerController._currentDirection.x * speed, rb.velocity.y, PlayerManager.Instance._playerController._currentDirection.z * speed);
        if (PlayerManager.Instance._playerController._currentDirection != Vector3.zero)
        {
            TargetEnemy();
        }
        else
        {
            if (_animator.GetInteger(Settings.Animation_Player) != 0 && _animator.GetInteger(Settings.Animation_Player) != 2)
            {
                _animator.SetInteger(Settings.Animation_Player, 0);
                //Debug.Log("Animator đã về 0");
            }
        }
    }

    public void TargetEnemy()
    {
        Quaternion toRotation = Quaternion.LookRotation(PlayerManager.Instance._playerController._currentDirection, Vector3.up);
        _meshPlayer.transform.rotation = toRotation;
        _animator.SetInteger(Settings.Animation_Player, 1);
        PlayerManager.Instance._playerController._direction = PlayerManager.Instance._playerController._currentDirection;// lưu direction để phóng lợn
    }
}