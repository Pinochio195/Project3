using Lean.Pool;
using UnityEngine;

public class CheckTouch : MonoBehaviour
{
    [SerializeField] private BotController _botController;
    [SerializeField] private Material _dieMaterial;
    [SerializeField] private SkinnedMeshRenderer _enemyMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Weapon))
        {
            _botController._botController._particleSystem.startColor = _botController._botController._BodySkinnedMeshRendererBot.material.color;
            _botController._botController._particleSystem.Play();
            _botController._botController._isCheckDieEnemy = true;
            //_enemyMaterial.material = _dieMaterial;
            _enemyMaterial.material.color = new Color(_enemyMaterial.material.color.r * .3f, _enemyMaterial.material.color.g * .3f, _enemyMaterial.material.color.b * .3f, _enemyMaterial.material.color.a);
            LeanPool.Despawn(this.gameObject, 3);
            _botController._botController._collider.enabled = false;
            _botController._botController._rigidbody.isKinematic = true;
            _botController._botController._listCirlce.SetActive(false);
        }
    }
}