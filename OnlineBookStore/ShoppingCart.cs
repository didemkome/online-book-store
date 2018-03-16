﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public class ShoppingCart
    {
        public string PaymentType;
        public float PaymentAmount;
        public List<ItemToPurchase> ItemsToPurchase = new List<ItemToPurchase>();
    }
}
