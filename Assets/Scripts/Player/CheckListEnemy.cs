using Ring;
using System.Collections;
using UnityEngine;

public class CheckListEnemy : MonoBehaviour
{
    public bool isCheckDetectionObject;
    [ChangeColorLabel(0.2f, 1, 1)] public Transform _mesh;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Settings.Tag_Enemy))
        {
            if (PlayerManager.Instance._playerController._currentDirection == Vector3.zero)
            {
                StartCoroutine(DelayAttackEnemy());
            }
        }
    }

   

    private IEnumerator DelayAttackEnemy()
    {
        yield return new WaitForSeconds(.2f);
        if (PlayerManager.Instance._playerController._botController != null)
        {
            CheckRotatePlayer(PlayerManager.Instance._playerController._botController.transform);
        }
    }

    private void CheckRotatePlayer(Transform other)
    {
        if (!isCheckDetectionObject)
        {
            RotatePlayer(other);
            isCheckDetectionObject = true;
            //Debug.Log($"Index animation {PlayerManager.Instance._playerController._animator.GetInteger(Settings.Animation_Player)}");
            //attack this
            //UIManager.Instance.OpenUI<Win>();
            PlayerManager.Instance._playerController._animator.SetInteger(Settings.Animation_Player, 2);
        }
    }

    private void RotatePlayer(Transform other)
    {
        Vector3 direction = (other.position - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        float currentRotationX = _mesh.transform.rotation.eulerAngles.x;
        toRotation = Quaternion.Euler(currentRotationX, toRotation.eulerAngles.y, toRotation.eulerAngles.z);
        _mesh.transform.rotation = toRotation;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Settings.Tag_Enemy))
        {
            isCheckDetectionObject = false;
            PlayerManager.Instance._playerController._botController = null;//bot gần player nhất reset lại để lấy lại bot khác
            var gameController = GameManager.Instance._gameController;
            gameController._listBotInDeathZone.Clear();
        }
        
    }
}