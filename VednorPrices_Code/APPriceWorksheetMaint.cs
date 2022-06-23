using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Common;
using PX.Data;
using PX.Objects.Common;
using PX.Objects.Common.Extensions;
using PX.Objects.CS;
using PX.Objects.CM;
using PX.Objects.IN;
using PX.Objects.GL;
using PX.Api;
using PX.Objects.Common.Scopes;
using PX.Data.BQL;
using PX.Objects;
using PX.Objects.AP;
using PX.Objects.PO;

namespace PX.Objects.AP
{
    public class APPriceWorksheetMaint_Extension : PXGraphExtension<APPriceWorksheetMaint>
    {
        public PXSelect<POLine> lines;
        #region Event Handlers

        protected void APPriceWorksheetDetail_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {

            var row = (APPriceWorksheetDetail)e.Row;
            DateTime last3Month = DateTime.Now.AddMonths(-3);
            decimal? totalQty = 0;
            decimal? backOrderQty = 0;

            if (row != null)
            {

                var ext = row.GetExtension<APPriceWorksheetDetailExt>();
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
                    ext.UsrTrendong = totalQty / 3;
                ext.UsrBackOrderQty = backOrderQty;
            }
        }



        #endregion
    }
}