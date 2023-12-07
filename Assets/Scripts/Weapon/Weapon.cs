using Lean.Pool;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float _speed = 8f;
    private Vector3 _direction;

    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        if (PlayerManager.Instance._playerController._attackEvent.weapon != null)
        {
            transform.position = PlayerManager.Instance._playerController._attackEvent.weapon.transform.position;
        }
        _targetPosition = new Vector3(PlayerManager.Instance._playerController._botController.transform.position.x, transform.position.y, PlayerManager.Instance._playerController._botController.transform.position.z);
        _direction = (_targetPosition - transform.position).normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * 1000f * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
        transform.parent.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Enemy))
        {
            PlayerManager.Instance._playerController._attackEvent.weapon.SetActive(true);
            LeanPool.Despawn(PlayerManager.Instance._playerWeapon._weaponPlayerThrowed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_CheckEnemy))
        {
            Debug.Log(other.gameObject.name);
            LeanPool.Despawn(PlayerManager.Instance._playerWeapon._weaponPlayerThrowed);
        }
    }
}