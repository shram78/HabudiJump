using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private List<Boost> _boosts;
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private AudioSource _buySound;
    [SerializeField] private AudioSource _useBoostSound;
    [SerializeField] private PlayerScore _playerScore;

    private Boost _currentBoost;
    private int _currentBoostNumber;
    private Rigidbody2D _rigidbody2D;

    public event UnityAction BeforeDie;
    public event UnityAction GameOver;
    public event UnityAction<Boost> BoostChanged;
    public event UnityAction NoNextBoost;

    public int BoostCount => _boosts.Count;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        ChangeBoost(_boosts[_currentBoostNumber]);
    }

    public void Die()
    {
        BeforeDie?.Invoke();
        StartCoroutine(Death());
    }

    public void BuyBoost(Boost boost)
    {
        _buySound.Play();

        _playerScore.SubtractTotal(boost.Price);

        _boosts.Add(boost);

        NoNextBoost?.Invoke();
    }

    public void NextBoost()
    {
        if (_boosts.Count <= 1 || _currentBoostNumber == _boosts.Count - 1)
        {
            _currentBoostNumber = 0;
            return;
        }

        else
        {
            _currentBoostNumber++;

            ChangeBoost(_boosts[_currentBoostNumber]);
        }
    }

    public void UseCurrentBoost()
    {
        if (_currentBoost == _boosts[0])
        {
            return;
        }

        else
        {
            _useBoostSound.Play();
            int powerCurrentBoost = _currentBoost.Power;
            _rigidbody2D.AddForce(new Vector2(0, powerCurrentBoost), ForceMode2D.Force);

            _boosts.Remove(_currentBoost);

            _currentBoost = _boosts[0];

            BoostChanged?.Invoke(_boosts[0]);
        }

        NoNextBoost?.Invoke();
    }
   

    private void ChangeBoost(Boost boost)
    {
        _currentBoost = boost;
        BoostChanged?.Invoke(_currentBoost);
    }

    private IEnumerator Death()
    {
        _dieSound.Play();

        yield return new WaitWhile(() =>_dieSound.isPlaying);

        GameOver?.Invoke();

        gameObject.SetActive(false);
    }
}