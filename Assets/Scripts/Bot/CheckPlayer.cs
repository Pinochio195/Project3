using Ring;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private bool isCheckDetectionObject;
    [ChangeColorLabel(0.2f, 1, 1)] public List<GameObject> _listCircle;
    [ChangeColorLabel(0.2f, 1, 1)] public BotController _botController;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Settings.Tag_Player))
        {
            var gameController = GameManager.Instance._gameController;
            gameController._listBotInDeathZone.Add(_botController);
            ActiveCircleDownEnemy(other.gameObject);
        }
    }

    private void ActiveCircleDownEnemy(GameObject objectA)
    {
        var gameController = GameManager.Instance._gameController;
        if (gameController._listBotInDeathZone.Count > 1)
        {
            gameController._listBotInDeathZone.ForEach(a => a._botController._checkPlayer._listCircle.ForEach(a => a.SetActive(false)));
            PlayerManager.Instance._playerController._botController = FindNearestObject(objectA);
            PlayerManager.Instance._playerController._botController._botController._checkPlayer._listCircle.ForEach(a => a.SetActive(true));
        }
        else
        {
            if (!isCheckDetectionObject)
            {
                isCheckDetectionObject = true;
                PlayerManager.Instance._playerController._botController = FindNearestObject(objectA);
                Debug.Log(PlayerManager.Instance._playerController._botController);
                _listCircle.ForEach(a => a.SetActive(true));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Settings.Tag_Player))
        {
            isCheckDetectionObject = false;
            _listCircle.ForEach(a => a.SetActive(false));
        }
    }

    public BotController FindNearestObject(GameObject objectA)
    {
        BotController nearestObject = null;
        float shortestDistance = Mathf.Infinity;

        foreach (BotController botObject in GameManager.Instance._gameController._listBotInDeathZone)
        {
            if (botObject == objectA)
                continue;

            float distance = Vector3.Distance(objectA.transform.position, botObject.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestObject = botObject;
            }
        }

        return nearestObject;
    }
}