using UnityEngine;
using UnityEngine.UI;

public class SelectedJelly : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Image _selectedJellyImageOne;

    private Color RedJellyColor = new Color(0.9433962f, 0.1507257f, 0f, 1f);
    private Color BlueJellyColor = new Color(0.2160373f, 0f, 1f, 1f);

    private void Start()
    {
        _mediator.JellyBlueChoiced += JellyBlueChoice;
        _mediator.JellyRedChoiced += JellyRedChoice;
    }

    private void OnDisable()
    {
        _mediator.JellyBlueChoiced -= JellyBlueChoice;
        _mediator.JellyRedChoiced -= JellyRedChoice;
    }

    private void JellyRedChoice(Block block)
    {
        _selectedJellyImageOne.color = RedJellyColor;
    }

    private void JellyBlueChoice(Block block)
    {
        _selectedJellyImageOne.color = BlueJellyColor;
    }
}
