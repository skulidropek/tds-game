using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeStation : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Canvas _upgradeUI;
    [SerializeField] private Canvas _playerUI;
    [SerializeField] private TextMeshProUGUI _upgradePointText;

    private int _upgradePoint;

    private void Update()
    {
        _upgradePoint = PlayerPrefs.GetInt("UpgradePoint");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string _upgradePointTextLocal = "Очков улучшений: " + _upgradePoint;
                _upgradePointText.text = _upgradePointTextLocal;
                _upgradeUI.gameObject.SetActive(!_upgradeUI.gameObject.activeSelf);
              _playerUI.gameObject.SetActive(!_playerUI.gameObject.activeSelf);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _upgradeUI.gameObject.SetActive(false);
            _playerUI.gameObject.SetActive(true);
        }
    }
}
