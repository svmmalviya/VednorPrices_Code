using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.CM;
using PX.Objects.IN;
using PX.Objects.TX;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace PX.Objects.AP
{
    public class APPriceWorksheetDetailExt : PXCacheExtension<PX.Objects.AP.APPriceWorksheetDetail>
    {
        #region UsrSOH
        [PXDBDecimal]
        [PXUIField(DisplayName = "SOH at Vendor")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual Decimal? UsrSOH { get; set; }
        public abstract class usrSOH : PX.Data.BQL.BqlDecimal.Field<usrSOH> { }
        #endregion

        #region UsrBackOrderQty
        [PXDBDecimal]
        [PXUIField(DisplayName = "BackOrder Qty")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual Decimal? UsrBackOrderQty { get; set; }
        public abstract class usrBackOrderQty : PX.Data.BQL.BqlDecimal.Field<usrBackOrderQty> { }
        #endregion

        #region UsrTrendong
        [PXDBDecimal]
        [PXUIField(DisplayName = "Trending Qty")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual Decimal? UsrTrendong { get; set; }
        public abstract class usrTrendong : PX.Data.BQL.BqlDecimal.Field<usrTrendong> { }
        #endregion
    }
}