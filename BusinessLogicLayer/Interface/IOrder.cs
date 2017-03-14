using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IOrder
    {
        BillingModel GetCategoryDetails(BillingModel model);
        List<BillingModel> CategoryList();
        long SaveOrder(BillingModel mode);
        BillingModel Getbyid(int id);
    }
}
