using Lean.Pool;
using Ring;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private JoystickPlayerExample joystick;
    [SerializeField] private CheckListEnemy check;
    [SerializeField] private PlayerManager playerManager;
    [ChangeColorLabel(0.2f, 1, 1)] public List<GameObject> _listWeaponPrefabs;

    [HeaderTextColor(0.2f, .7f, .8f, headerText = "Xác thực vũ khí nào khi mới vào game/chưa code")]
    [SerializeField] private List<GameObject> listWeapon;

    [SerializeField] public GameObject weapon;

    public void ResetIdle()
    {
        playerManager._playerController._animator.SetInteger(Settings.Animation_Player, 0);
    }

    public void ResetCheckEnemy()
    {
        check.isCheckDetectionObject = false;
        if (!weapon.activeSelf)
        {
            weapon.SetActive(true);
        }
    }

    public void ThrowWeapon()
    {
        weapon.SetActive(false);
        PlayerManager.Instance._playerWeapon._weaponPlayerThrowed = LeanPool.Spawn(_listWeaponPrefabs[0], PlayerManager.Instance._playerWeapon._transformWeapon.position, Quaternion.identity);
    }
}