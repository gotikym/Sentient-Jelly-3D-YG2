public class SelectedSkinChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public bool IsSelected { get; private set; }

    public SelectedSkinChecker(IPersistentData persistentData)
        => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        if (shopItem as HatSkinItem)
            VisitHats((HatSkinItem)shopItem);
        else if (shopItem as BorderSkinItem)
            VisitBorders((BorderSkinItem)shopItem);
    }

    public void VisitHats(HatSkinItem hatSkinItem)
        => IsSelected = _persistentData.PlayerData.SelectedHatSkin == hatSkinItem.ScinType;

    public void VisitBorders(BorderSkinItem borderSkinItem)
        => IsSelected = _persistentData.PlayerData.SelectedBorderSkin == borderSkinItem.ScinType;
}
