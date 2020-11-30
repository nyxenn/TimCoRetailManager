using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string Subtotal
        {
            get { return "{0:D2}"; }
        }
        public string Tax
        {
            get { return "{0:D2}"; }
        }
        public string Total
        {
            get { return "{0:D2}"; }
        }



        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                // Make sure item is selected & quantity given

                return output;
            }
        }

        public void AddToCart() { }
        
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // Make sure item is selected

                return output;
            }
        }

        public void RemoveFromCart() { }

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
