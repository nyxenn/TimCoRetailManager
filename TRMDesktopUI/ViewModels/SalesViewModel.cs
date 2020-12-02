using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.API;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }


        private int _itemQuantity = 1;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private CartItemModel _selectedCartProduct;

        public CartItemModel SelectedCartProduct
        {
            get { return _selectedCartProduct; }
            set
            {
                _selectedCartProduct = value;
                NotifyOfPropertyChange(() => CanRemoveFromCart);
            }
        }

        private string _subtotal = $"{0:C2}";

        public string Subtotal
        {
            get { return _subtotal; }
            set
            {
                _subtotal = value;
                NotifyOfPropertyChange(() => Subtotal);
            }
        }

        private string _tax = $"{0:C2}";

        public string Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                NotifyOfPropertyChange(() => Tax);
            }
        }

        private string _total = $"{0:C2}";

        public string Total
        {
            get { return _total; }
            set
            {
                _total = value;
                NotifyOfPropertyChange(() => Total);
            }
        }

        public void CalculateTotals()
        {
            decimal subtotal = 0;
            decimal taxAmount = 0;
            decimal total = 0;

            foreach (var item in Cart)
            {
                subtotal += item.Product.RetailPrice * item.QuantityInCart;
                taxAmount += item.Product.RetailPrice * (item.Product.TaxRate / 100) * item.QuantityInCart;
            }

            total = subtotal - taxAmount;

            Subtotal = $"{subtotal:C2}";
            Tax = $"{taxAmount:C2}";
            Total = $"{total:C2}";
            
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                // Make sure item is selected & quantity given
                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }

                return output;
            }
        }

        public void AddToCart()
        {
            CartItemModel existingItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;
                //HACK - There should be a better way of refreshing the cart display
                int cartIndex = Cart.IndexOf(existingItem);
                Cart.Remove(existingItem);
                Cart.Insert(cartIndex, existingItem);
            }
            else
            {
                CartItemModel cartItem = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };

                Cart.Add(cartItem);
            }
            
            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            
            CalculateTotals();
        }
        
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                if (SelectedCartProduct != null)
                {
                    output = true;
                }

                return output;
            }
        }

        public void RemoveFromCart() 
        {
            NotifyOfPropertyChange(() => Subtotal);
        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                // Make sure cart is not empty

                return output;
            }
        }

        public void CheckOut() { }

    }
}
