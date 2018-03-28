using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ApplicationCore.Entities;

namespace AStores.ViewModel { 
    public class PriceManagementViewModel : BaseViewModel
    {
        public ICollectionView Products { get; private set; }

        public PriceManagementViewModel()
        {
            var products = new List<NProduct>
                                 {
                                     new NProduct
                                         {
                                                Id=1,
                                             F_FullName = "Christian",
                                             F_EnCode = "01003",
                                             F_ImageUrl1 = "http://www.wpftutorial.net",
                                             F_GuidePrice = 3.12m,
                                             F_SalePrice = 3.52m
                                     },
                                     new NProduct
                                         {
                                         Id=2,
                                             F_FullName = "Cherry",
                                             F_EnCode = "01004",
                                             F_ImageUrl1 = "http://www.wpftutorial.net",
                                             F_GuidePrice = 6.12m,
                                             F_SalePrice = 6.52m

                                         },
                                     new NProduct
                                         {
                                         Id=3,
                                             F_FullName = "Apppple",
                                             F_EnCode = "01005",
                                             F_ImageUrl1 = "http://www.wpftutorial.net",
                                             F_GuidePrice = 5.12m,
                                             F_SalePrice = 5.52m
                                         },
                                     new NProduct
                                         {
                                         Id=4,
                                             F_FullName = "Pearl",
                                             F_EnCode = "01006",
                                             F_ImageUrl1 = "http://www.wpftutorial.net",
                                             F_GuidePrice = 4.12m,
                                             F_SalePrice = 4.52m
                                         }
                                 };

            Products = CollectionViewSource.GetDefaultView(products);

        }

    }

    public class NProduct: Product
    {
        public int Id { get; set; }
    }
}
