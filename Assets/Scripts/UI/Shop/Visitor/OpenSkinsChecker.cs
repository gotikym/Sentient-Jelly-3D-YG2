using System.Linq;

public class OpenSkinsChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public bool IsOpened { get; private set; }

    public OpenSkinsChecker(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        if (shopItem as HatSkinItem)
            VisitHats((HatSkinItem)shopItem);
        else if (shopItem as BorderSkinItem)
            VisitBorders((BorderSkinItem)shopItem);
    }

    public void VisitHats(HatSkinItem hatSkinItem)
        => IsOpened = _persistentData.PlayerData.OpenHatSkins.Contains(hatSkinItem.ScinType);

    public void VisitBorders(BorderSkinItem borderSkinItem)
        => IsOpened = _persistentData.PlayerData.OpenBorderSkins.Contains(borderSkinItem.ScinType);
}
