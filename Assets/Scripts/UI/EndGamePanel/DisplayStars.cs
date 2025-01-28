using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStars : MonoBehaviour
{
    [SerializeField] private Victory _victory;
    [SerializeField] private List<GameObject> _stars;
    [SerializeField] private TMP_Text _currentStarsCount;
    [SerializeField] private TMP_Text _pointsForStars;
    [SerializeField] private TMP_Text _pointsAfterVideoAd;

    private const int CostOneStar = 500;
    private const int MultiplyForVideoAd = 2;
    private const string ZeroText = "0";
    private const string NewStarsCountText = "новых звёзд - ";
    private const string PointsForStars = " = ";
    private const string Plus = "+ ";

    private void OnEnable()
    {
        _victory.StarsCalculated += StarsCalculate;
    }

    private void OnDisable()
    {
        _victory.StarsCalculated -= StarsCalculate;
    }

    private void StarsCalculate(int oldStarsCount, int currentStarsCount)
    {
        for (int i = 0; i < currentStarsCount; i++)
            _stars[i].SetActive(true);

        if (currentStarsCount > oldStarsCount)
        {
            currentStarsCount -= oldStarsCount;
            _currentStarsCount.text = NewStarsCountText + currentStarsCount;
            _pointsForStars.text = currentStarsCount + PointsForStars + currentStarsCount * CostOneStar;
            _pointsAfterVideoAd.text = Plus + (currentStarsCount * CostOneStar) * MultiplyForVideoAd;
        }
        else
        {
            _currentStarsCount.text = NewStarsCountText + ZeroText;
            _pointsForStars.text = ZeroText + PointsForStars + 0 * CostOneStar;
        }
    }
}