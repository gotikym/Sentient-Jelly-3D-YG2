using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _hatSkinItemPrefab;
    [SerializeField] private ShopItemView _borderSkinItemPrefab;

    public ShopItemView Get(ShopItem shopItem, Transform parent)
    {
        ShopItemVisitor visitor = new ShopItemVisitor(_hatSkinItemPrefab, _borderSkinItemPrefab);
        visitor.Visit(shopItem);

        ShopItemView instance = Instantiate(visitor.Prefab, parent);
        instance.Initialize(shopItem);

        return instance;
    }

    private class ShopItemVisitor : IShopItemVisitor
    {
        private ShopItemView _hatSkinItemPrefab;
        private ShopItemView _borderSkinItemPrefab;

        public ShopItemVisitor(ShopItemView hatSkinItemPrefab, ShopItemView borderSkinItemPrefab)
        {
            _hatSkinItemPrefab = hatSkinItemPrefab;
            _borderSkinItemPrefab = borderSkinItemPrefab;
        }

        public ShopItemView Prefab { get; private set; }

        public void Visit(ShopItem shopItem)
        {
            if (shopItem as HatSkinItem)
                VisitHats((HatSkinItem)shopItem);
            else if (shopItem as BorderSkinItem)
                VisitBorders((BorderSkinItem)shopItem);
        }

        public void VisitHats(HatSkinItem hatSkinItem) => Prefab = _hatSkinItemPrefab;

        public void VisitBorders(BorderSkinItem borderSkinItem) => Prefab = _borderSkinItemPrefab;
    }
}
