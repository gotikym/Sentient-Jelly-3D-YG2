public class SkinSelector : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinSelector(IPersistentData persistentData)
        => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        if (shopItem as HatSkinItem)
            VisitHats((HatSkinItem)shopItem);
        else if (shopItem as BorderSkinItem)
            VisitBorders((BorderSkinItem)shopItem);
    }

    public void VisitHats(HatSkinItem hatSkinItem)
        => _persistentData.PlayerData.SelectedHatSkin = hatSkinItem.ScinType;

    public void VisitBorders(BorderSkinItem borderSkinItem)
        => _persistentData.PlayerData.SelectedBorderSkin = borderSkinItem.ScinType;
}
