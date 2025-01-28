public class SkinUnlocker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinUnlocker(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        if (shopItem as HatSkinItem)
            VisitHats((HatSkinItem)shopItem);
        else if (shopItem as BorderSkinItem)
            VisitBorders((BorderSkinItem)shopItem);
    }

    public void VisitHats(HatSkinItem hatSkinItem)
        => _persistentData.PlayerData.OpenHatSkin(hatSkinItem.ScinType);

    public void VisitBorders(BorderSkinItem borderSkinItem)
        => _persistentData.PlayerData.OpenBorderSkin(borderSkinItem.ScinType);
}
