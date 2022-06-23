using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.CM;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.SM;
using PX.TM;
using PX.Objects.PO;
using PX.Common;
using PX.Data.BQL;
using PX.Objects;
using PX.Objects.AP;

namespace PX.Objects.AP
{
    public class APVendorPriceMaint_Extension : PXGraphExtension<APVendorPriceMaint>
    {
        public PXSelect<POLine> lines;

        #region Event Handlers

        protected void APVendorPrice_RowSelected(PXCache cache, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(cache, e);

            DateTime last3Month = DateTime.Now.AddMonths(-3);
            decimal? totalQty = 0;
            decimal? backOrderQty = 0;

            var row = (APVendorPrice)e.Row;
            if (row != null)
            {
                var ext = row.GetExtension<APVendorPriceExt>();
                foreach (PXResult<POLine> item in lines.Select())
                {
                    POLine line = (POLine)item;
                    if (row.InventoryID == line.InventoryID && line.VendorID == row.VendorID)
                    {
                        backOrderQty += line.OpenQty;

                        if (line.OrderDate > last3Month)
                        {
                            totalQty += line.OrderQty;
                        }
                    }
                }
                if (totalQty != 0)
                    ext.UsrTrendingQty = totalQty / 3;
                ext.UsrBackOrderQty = backOrderQty;
            }
        }



        #endregion
    }
}