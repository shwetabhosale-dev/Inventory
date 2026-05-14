using Inventory.Models;
using Inventory.ViewModel.BillViewModel;
using Inventory.ViewModel.CustomerViewModel;
using Inventory.ViewModel.InvoiceViewModel;
using Inventory.ViewModel.ProductViewModel;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> CustomerTypeModelToCustomerTypeListViewModel(this IEnumerable<CustomerType> customerTypeModel)
        {
            List<CustomerTypeListViewModel> list = new List<CustomerTypeListViewModel>();
            foreach (var customerTypeItem in customerTypeModel)
            {
                list.Add(new CustomerTypeListViewModel
                {
                    CustomerTypeId = customerTypeItem.CustomerTypeId,
                    CustomerTypeName = customerTypeItem.CustomerTypeName,
                    Description = customerTypeItem.Description
                });
            }
            return list;
        }

        public static IEnumerable<CustomerListViewModel> CustomerModelToCustomerListViewModel(this IEnumerable<Customer> customerModel)
        {
            List<CustomerListViewModel> list = new List<CustomerListViewModel>();
            foreach (var customerItem in customerModel)
            {
                list.Add(new CustomerListViewModel
                {
                    CustomerId = customerItem.CustomerId,
                    CustomerName = customerItem.CustomerName,
                    CustomerTypeId = customerItem.CustomerTypeId,
                    Address = customerItem.Address,
                    City = customerItem.City,
                    State = customerItem.State,
                    ZipCode = customerItem.ZipCode,
                    Phone = customerItem.Phone,
                    Email = customerItem.Email,
                    ContactPerson = customerItem.ContactPerson
                });
            }
            return list;
        }

        public static IEnumerable<BillTypeListViewModel> BillTypeModelToBillTypeListViewModel(this IEnumerable<BillType> billTypeModel)
        {
            List<BillTypeListViewModel> list = new List<BillTypeListViewModel>();
            foreach (var billTypeItem in billTypeModel)
            {
                list.Add(new BillTypeListViewModel
                {
                    BillTypeId = billTypeItem.BillTypeId,
                    BillTypeName = billTypeItem.BillTypeName,
                    Description = billTypeItem.Description
                });
            }
            return list;
        }

        public static IEnumerable<BillListViewModel> BillModelToBillListViewModel(this IEnumerable<Bill> billModel)
        {
            List<BillListViewModel> list = new List<BillListViewModel>();
            foreach (var billItem in billModel)
            {
                list.Add(new BillListViewModel
                {
                    BillId = billItem.BillId,
                    BillTypeId = billItem.BillTypeId,
                    BillName = billItem.BillName,
                    BillDate = billItem.BillDate,
                    VendorInvoiceNumber = billItem.VendorInvoiceNumber
                });
            }
            return list;
        }

        public static IEnumerable<InvoiceTypeListViewModel> InvoiceTypeModelToInvoiceTypeListViewModel(this IEnumerable<InvoiceType> invoiceTypes)
        {
            List<InvoiceTypeListViewModel> list = new List<InvoiceTypeListViewModel>();
            foreach (var InvoiceTypeItem in invoiceTypes)
            {
                list.Add(new InvoiceTypeListViewModel
                {
                    InvoiceTypeId = InvoiceTypeItem.InvoiceTypeId,
                    InvoiceTypeName = InvoiceTypeItem.InvoiceTypeName,
                    Description = InvoiceTypeItem.Description
                });
            }
            return list;
        }

        public static IEnumerable<InvoiceListViewModel> InvoiceListToInvoiceListViewModel(this IEnumerable<Invoice> invoices)
        {
            List<InvoiceListViewModel> list = new List<InvoiceListViewModel>();
            foreach (var InvoiceTtem in invoices)
            {
                list.Add(new InvoiceListViewModel
                {
                    InvoiceId = InvoiceTtem.InvoiceId,
                    InvoiceName = InvoiceTtem.InvoiceName,
                    InvoiceDate = InvoiceTtem.InvoiceDate,
                    InvoiceDueDate = InvoiceTtem.InvoiceDueDate,
                    InvoiceTypeId = InvoiceTtem.InvoiceTypeId,
                    ShipmentId = InvoiceTtem.ShipmentId

                });
            }
            return list;
        }

        public static IEnumerable<ProductListViewModel> ProductListToProductListViewModel(this IEnumerable<Product> products)
        {
            List<ProductListViewModel> list = new List<ProductListViewModel>();
            foreach (var ProductTtem in products)
            {
                list.Add(new ProductListViewModel
                {
                    ProductId = ProductTtem.ProductId,
                    ProductCode = ProductTtem.ProductCode,
                    ProductImage = ProductTtem.ProductImage,
                    ProductName = ProductTtem.ProductName,
                    ByingPrice = ProductTtem.ByingPrice,
                    SellingPrice = ProductTtem.SellingPrice,
                    Barcode = ProductTtem.Barcode,
                    BranchId = ProductTtem.BranchId,
                    CurrencyId = ProductTtem.CurrencyId,
                    Description = ProductTtem.Description,
                    MeasureUnitId = ProductTtem.MeasureUnitId
                });
            }
            return list;
        }

        public static IEnumerable<ProductTypeListViewModel> ProductTypeToProductTypeListViewModel(this IEnumerable<ProductType> ProductTypes)
        {
            List<ProductTypeListViewModel> list = new List<ProductTypeListViewModel>();
            foreach(var ProductTypeTtem in ProductTypes)
            {
                list.Add(new ProductTypeListViewModel
                {
                    ProductTypeId = ProductTypeTtem.ProductTypeId,
                    ProductTypeName = ProductTypeTtem.ProductTypeName,
                    Description = ProductTypeTtem.Description
                });
            }
            return list;
        }
    }
}
