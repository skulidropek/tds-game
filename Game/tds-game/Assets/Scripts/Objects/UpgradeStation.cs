using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeStation : MonoBehaviour
{
    [SerializeField] private Canvas _upgradeUI;
    [SerializeField] private Canvas _playerUI;
    [SerializeField] private TextMeshProUGUI _upgradePointText;

    private Player player;
    private int _upgradePoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        _upgradePoint = player.Upgrade.UpgradePoint;
        string _upgradePointTextLocal = "Очков улучшений: " + _upgradePoint;
        _upgradePointText.text = _upgradePointTextLocal;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                _upgradeUI.gameObject.SetActive(!_upgradeUI.gameObject.activeSelf);
                _playerUI.gameObject.SetActive(!_playerUI.gameObject.activeSelf);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _upgradeUI.gameObject.SetActive(false);
            _playerUI.gameObject.SetActive(true);
        }
    }

    public void BuyUpgrade()
    {
        if (_upgradePoint >= 2)
        {
            player.Speed *= 2;
            _upgradePoint -= 2;
            player.Upgrade.UpgradePoint = _upgradePoint;

            Debug.Log("Вы купили апгрейд");
        }
    }
}
