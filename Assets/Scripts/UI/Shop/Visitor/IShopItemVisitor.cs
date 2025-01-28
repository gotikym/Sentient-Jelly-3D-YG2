public interface IShopItemVisitor
{
    void Visit(ShopItem shopItem);
    void VisitHats(HatSkinItem hatSkinItem);
    void VisitBorders(BorderSkinItem borderSkinItem);
}
