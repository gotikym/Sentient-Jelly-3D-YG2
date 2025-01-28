using UnityEngine;

public class Learning : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private Block _secondBlock;
    [SerializeField] private GameObject _learningObjectOne;
    [SerializeField] private GameObject _learningObjectTwo;
    [SerializeField] private GameObject _learningObjectThree;

    private bool _isSecondLearningActivated = false;
    private bool _isThirdLearningActivated = false;

    private void Start()
    {
        if (_timer.IsPlaying)
            _timer.SwitchTimerStatus();

        _player.BlockIsChoiced += BlockIsChoice;
        _player.BlockIsChoiced += ActivateThirdLearning;
    }

    private void OnDisable()
    {
        _player.BlockIsChoiced -= BlockIsChoice;
        _player.BlockIsChoiced -= ActivateThirdLearning;
    }

    private void BlockIsChoice(Block block)
    {
        if (_isSecondLearningActivated == false)
        {
            if (block.IsJelly)
            {
                _learningObjectOne.SetActive(false);
                _learningObjectTwo.SetActive(true);
                _isSecondLearningActivated = true;
            }
        }
    }

    private void ActivateThirdLearning(Block block)
    {
        if (_isThirdLearningActivated == false)
        {
            if (block.Id == _secondBlock.Id && _isSecondLearningActivated)
            {
                _learningObjectTwo.SetActive(false);
                _learningObjectThree.SetActive(true);
                _timer.SwitchTimerStatus();
                _isThirdLearningActivated = true;
            }
        }
    }
}
