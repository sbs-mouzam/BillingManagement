using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Billing.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {
        BillingModel _BillingModel;
        private readonly IInvoice _invoiveBusiness;
        public InvoiceController()
        {
            _BillingModel = new BillingModel();
            _invoiveBusiness = new InvoiceBusiness();
        }
        // GET: Admin/Invoice
        public ActionResult Index(int? id)
        {
            if (id==null || id==0)
            {
                return PageRedirection();
            }
            _BillingModel.OrderId = (Int32)id;
            _BillingModel = _invoiveBusiness.GetCustomerOrderDetailsByOrderId(_BillingModel);
            if (_BillingModel.BillingList == null || !_BillingModel.BillingList.Any())
            {
                return PageRedirection();
            }
            return View(_BillingModel);
        }

        private ActionResult PageRedirection()
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Billing", action = "Index" }));
        }
    }
}