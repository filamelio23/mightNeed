 if (associatedProducts.Any())
                {
                    contextProduct = associatedProducts.OrderBy(x => x.DisplayOrder).First();
                    _services.DisplayControl.Announce(contextProduct);
                }
            }
            else
            {
                priceModel.DisableBuyButton = product.DisableBuyButton || !context.AllowShoppingCart || !context.AllowPrices;
                priceModel.DisableWishlistButton = product.DisableWishlistButton || !context.AllowWishlist || !context.AllowPrices;
                priceModel.AvailableForPreOrder = product.AvailableForPreOrder;//good
            }
        public async Task<List<BrandOverviewModel>> PrepareBrandOverviewModelAsync(
            ICollection<ProductManufacturer> brands,
            IDictionary<int, BrandOverviewModel> cachedModels = null,
            bool withPicture = false)
        {
            var model = new List<BrandOverviewModel>();
            cachedModels ??= new Dictionary<int, BrandOverviewModel>();
            IDictionary<int, MediaFileInfo> mediaFileLookup = null;

            if (withPicture)
            {
                var manufacturerFileIds = brands
                    .Select(x => x.Manufacturer.MediaFileId ?? 0)
                    .Where(x => x > 0)
                    .Distinct()
                    .ToArray();//nice
