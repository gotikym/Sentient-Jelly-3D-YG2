using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Timer _timer;
    [SerializeField] private List<Jelly> _allJelly;

    private IDataProvider _dataProvider;

    private Wallet _wallet;
    private OpenLevels _openLevels;
    private StarsLevels _starsLevels;

    private bool _isFinish;
    private float _timeForOneStart;
    private float _timeForTwoStart;
    private int _nextLevelNumber;
    private int _levelNumber;
    private int _currentStarsCount;
    private int _coinsForLevel;
    private int _previosStarsCount;
    private int _bonusCoins;

    private const int LevelNumberAdjustment = 1;

    private const int OneStar = 1;
    private const int TwoStar = 2;
    private const int ThreeStar = 3;

    private const int MultiplierTwo = 2;
    private const int MultiplierThree = 3;

    private const int CoinsForOneStar = 500;
    private const int CoinsForTwoStar = 1000;
    private const int CoinsForThreeStar = 1500;

    public int BonusCoins => _bonusCoins;

    public static event Action LevelFinished;
    public event Action<int,int> StarsCalculated;

    public void Initialize(IDataProvider dataProvider, Wallet wallet, OpenLevels openLevels, StarsLevels starsLevels)
    {
        _wallet = wallet;
        _openLevels = openLevels;
        _starsLevels = starsLevels;
        _dataProvider = dataProvider;
    }

    private void Start()
    {
        _levelNumber = SceneManager.GetActiveScene().buildIndex - LevelNumberAdjustment;
        _nextLevelNumber = _levelNumber + LevelNumberAdjustment;
        Jelly.JellyFilled += OnJellyFill;
    }

    private void OnDestroy()
    {
        Jelly.JellyFilled -= OnJellyFill;
    }

    public void RewardForVideoAd()
    {
        YandexLeaderboard.SetPlayerScore(_bonusCoins);
        _wallet.AddCoin(_bonusCoins);
        _dataProvider.Save();
    }

    private void OnJellyFill()
    {
        for (int i = 0; i < _allJelly.Count; i++)
        {
            if (_allJelly[i].StepsCount == 0)
            {
                _isFinish = true;
            }
            else
            {
                _isFinish = false;
                break;
            }
        }

        if (_isFinish)
            Finish();
    }

    private int CalculateCoins()
    {
        _timeForOneStart = _timer.TimeStart / MultiplierThree;
        _timeForTwoStart = _timeForOneStart * MultiplierTwo;

        if (_timer.CurrentTime <= _timeForOneStart)
            return CoinsForOneStar;
        else if (_timer.CurrentTime <= _timeForTwoStart)
            return CoinsForTwoStar;
        else if (_timer.CurrentTime > _timeForTwoStart)
            return CoinsForThreeStar;
        else
            return 0;
    }

    private void CalculateStars()
    {
        _coinsForLevel = CalculateCoins();

        switch (_coinsForLevel)
        {
            case CoinsForOneStar: _currentStarsCount = OneStar; break;
            case CoinsForTwoStar: _currentStarsCount = TwoStar; break;
            case CoinsForThreeStar: _currentStarsCount = ThreeStar; break;
        }

        _previosStarsCount = _starsLevels.GetCurrentStarsLevel(_levelNumber);
    }

    private void Finish()
    {
        CalculateStars();
        TrySaveCoins();
        TrySaveStars();

        _openLevels.TryOpenLevel(_nextLevelNumber);
        _dataProvider.Save();
        
        StarsCalculated?.Invoke(_previosStarsCount, _currentStarsCount);
        LevelFinished?.Invoke();
    }

    private void TrySaveCoins()
    {
        if (_currentStarsCount - _previosStarsCount > 0)
        {
            _bonusCoins = CoinsForOneStar * (_currentStarsCount - _previosStarsCount);

            //YandexLeaderboard.SetPlayerScore(_bonusCoins);

            _wallet.AddCoin(_bonusCoins);

            _dataProvider.Save();
        }
    }

    private void TrySaveStars()
    {
        _starsLevels.TryAddStars(_levelNumber, _currentStarsCount);

        _dataProvider.Save();
    }
}