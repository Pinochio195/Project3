using UnityEngine;
using UnityEngine.UI;

public class ButtonsSettings : BaseClickButton
{
    [SerializeField]Sprite _spriteOn;
    [SerializeField]Sprite _spriteOff;
    [SerializeField]Image _sprite;
    public bool isCheck;
    protected override void OnButtonClick()
    {
        if (!isCheck)
        {
            _sprite.sprite = _spriteOff;
        }
        else
        {
            _sprite.sprite = _spriteOn;
        }
        isCheck = !isCheck;
    }
}
