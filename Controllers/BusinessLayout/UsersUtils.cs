using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.ViewModels.CustomModels;
using WebApplicationStore.Models.ViewModels;
using System.Security.Cryptography.Xml;
using WebApplicationStore.Models.StoreDbModels;
using NuGet.ContentModel;

namespace WebApplicationStore.Controllers.BusinessLayout
{
    public class UsersUtils
    {
        private readonly officia1_StoreContext _context;

        public UsersUtils(ILogger<HomeController> logger, officia1_StoreContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public int CheckUserId(String userId)
        {
            int _userId = 0;
            if (userId == null)
                return 0;

            if (userId.Length > 10)
            {
                // جستجو برای کاربر با نام کاربری مشخص (بدون استفاده از StringComparison)  
                var user = _context.ViewAdminUsers
                                   .FirstOrDefault(x => x.UserName.ToLower() == userId.ToLower());

                // بررسی اینکه آیا کاربر وجود دارد و سپس استخراج شناسه  
                if (user != null)
                {
                    _userId = user.Id;
                }
                else
                {
                    // مدیریت وضعیت وقتی که کاربر یافت نشد (مثلاً، می‌توانید خطایی پرتاب کنید یا مقدار پیش‌فرضی تنظیم کنید)  
                    _userId = 0;
                }
            }
            else
            {
                _userId = int.Parse(userId);
            }

            return _userId;
        }

        public int AddItemToBasket(String userId , int _productChargePropertiesId, int basketId)
        {

            int userIddb = CheckUserId(userId);

            ShoppingBasketDetails shopingBasket = new ShoppingBasketDetails();

            if (userIddb != 0)
            {
                if (basketId != 0)
                {

                    //1
                    //var selectedBasket = _context.ViewUserBaskets
                    //                        .Where(x => x.UserId == userIddb)
                    //                        .Select(basket => new ViewUserBasketCustom
                    //                        {
                    //                            Id = basket.Id,
                    //                            UserId = basket.UserId,
                    //                            BasketStatus = basket.BasketStatus,
                    //                            BasketStatusId = basket.BasketStatusId,
                    //                            ShoppingBasketId = basket.ShoppingBasketId,
                    //                            isSelected = basket.Id == basketId
                    //                        }).ToList()
                    //                        .FirstOrDefault();
                    //if(selectedBasket != null)
                    //    addOperation(_productChargePropertiesId, userIddb, selectedBasket.Id);

                    //2  
                    return addOperation(_productChargePropertiesId, userIddb, basketId);
                }
                else
                {
                    //defaultBasket

                    //var DefaultBasketType = _context.BdShoppingBasketTypes
                    //    //.Where(x => x.isdefault == true)
                    //    .OrderBy(x => x.Id)
                    //    .FirstOrDefault();
                    //var defaultBasket = _context.SdShoppingBaskets
                    //    .Where(x => x.UserId == userIddb && x.StatusId == DefaultBasketType.Id)
                    //    .ToList();

                    //  ||
                    //  \/

                    var defaultBasket = _context.SdShoppingBaskets
                                        .Where(x => x.UserId == userIddb && 
                                        
                                            x.StatusId == _context.BdShoppingBasketTypes
                                                            .Where(b => (bool)b.IsDefault)
                                                            .OrderByDescending(b => b.Id)
                                                           .Select(b => b.Id)
                                                           .FirstOrDefault()
                                                            
                                                            )
                                        .ToList().FirstOrDefault();


                    return addOperation(_productChargePropertiesId,userIddb, defaultBasket.Id);
                } 
            }
            return 0;
        }
        public int RemoveItemFromBasket(String userId , int _productChargePropertiesId, int basketId)
        {
            int userIddb = CheckUserId(userId);

            ShoppingBasketDetails shopingBasket = new ShoppingBasketDetails();

            if (userIddb != 0)
            {
                if (basketId != 0)
                {

                    //1
                    //var selectedBasket = _context.ViewUserBaskets
                    //                        .Where(x => x.UserId == userIddb)
                    //                        .Select(basket => new ViewUserBasketCustom
                    //                        {
                    //                            Id = basket.Id,
                    //                            UserId = basket.UserId,
                    //                            BasketStatus = basket.BasketStatus,
                    //                            BasketStatusId = basket.BasketStatusId,
                    //                            ShoppingBasketId = basket.ShoppingBasketId,
                    //                            isSelected = basket.Id == basketId
                    //                        }).ToList()
                    //                        .FirstOrDefault();
                    //if(selectedBasket != null)
                    //    addOperation(_productChargePropertiesId, userIddb, selectedBasket.Id);

                    //2  
                    return removeOperation(_productChargePropertiesId, userIddb, basketId);
                }
            }
            return 0;
        }

        private int addOperation(int _productChargePropertiesId ,int userIddb ,int BasketID)
        {
            int newCount = 1;
            //search in user baskets
            var searchedItemInBasket = _context.ViewUserBasketsObjects
                                        .Where(x => x.ProductChargePropertiesId == _productChargePropertiesId && x.UserId == userIddb && x.ShoppingBasketId == BasketID)
                                        .FirstOrDefault();



            if (searchedItemInBasket == null)
            {


                var ProductChargesProperties = _context.SdProductChargesProperties
                                .FirstOrDefault(x => x.Id == _productChargePropertiesId);
                var productPrice = _context.SdProductCharges
                                .FirstOrDefault(x => x.Id == ProductChargesProperties.ProductChargeId);

                //add new item
                _context.SdShoppingBasketObjects.Add(new SdShoppingBasketObject()
                {
                    Count = 1,
                    AddDate = DateTime.Now, 
                    Price = productPrice.BuyPrice,
                    ProductChargePropertiesId = _productChargePropertiesId,
                    ShoppingBasketId = BasketID,
                    
                    
                }); 
                _context.SaveChanges();

            }
            else
            {
                // add count 
                var basketObject = _context.SdShoppingBasketObjects
                                    .SingleOrDefault(x => x.Id == searchedItemInBasket.ShoppingBasketObjectsId);      

                if (basketObject != null)
                {
                    basketObject.Count++;
                    _context.SaveChanges();
                    newCount = (int)basketObject.Count;
                }
            }
            return newCount;
        }
        private int removeOperation(int _productChargePropertiesId, int userIddb, int BasketID)
        {
            int newCount = 0;
            var selectedBasket = _context.ViewUserBaskets
                                    .Where(x => x.UserId == userIddb && x.Id == BasketID)
                                    .ToList()
                                    .FirstOrDefault();


            if (selectedBasket != null) {
                //search in user baskets 
                var basketObject = _context.SdShoppingBasketObjects
                                            .SingleOrDefault(x => x.ProductChargePropertiesId == _productChargePropertiesId && x.ShoppingBasketId == BasketID);//&& x.UserId == userIddb);

                if (basketObject == null)
                {
                    return newCount;
                }
                else
                {
                    if (basketObject.Count > 1)
                    {
                        //count down
                        if (basketObject != null)
                        {
                            basketObject.Count--;
                            _context.SaveChanges();
                            newCount = (int)basketObject.Count;
                        }
                    }
                    else
                    {
                        //remove
                        if (basketObject != null)
                        {
                            _context.SdShoppingBasketObjects.Remove(basketObject);
                            _context.SaveChanges();
                        }
                    }
                }
                return newCount;
            }
            return newCount;


        }
    }
}
