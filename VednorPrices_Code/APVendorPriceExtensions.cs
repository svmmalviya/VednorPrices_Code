using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.CM;
using PX.Objects.IN;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace PX.Objects.AP
{
    public class APVendorPriceExt : PXCacheExtension<PX.Objects.AP.APVendorPrice>
    {
        #region UsrSOH at Vendor

        public decimal? _SOH;
        public decimal? _TQty;


        [PXDBDecimal]
        [PXUIField(DisplayName = "SOH at Vendor")]
        public virtual Decimal? UsrSOH {
            get { return _SOH != null ? _SOH : 0; }
            set { _SOH = value != null ? value : 0; }
        }
        public abstract class usrSOH : PX.Data.BQL.BqlDecimal.Field<usrSOH> { }
        #endregion

        #region UsrBackOrderQty
        [PXDBDecimal]
        [PXUIField(DisplayName = "BackOrder Qty")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual Decimal? UsrBackOrderQty { get; set; }
        public abstract class usrBackOrderQty : PX.Data.BQL.BqlDecimal.Field<usrBackOrderQty> { }
        #endregion

        #region UsrTrendingQty
        [PXDBDecimal]
        [PXUIField(DisplayName = "Trending Qty")]
        [PXDefault(TypeCode.Decimal,"0.0")]
        public virtual Decimal? UsrTrendingQty {
            get { return _TQty != null ? _TQty : 0; }
            set { _TQty = value != null ? value : 0; }
        }
        public abstract class usrTrendingQty : PX.Data.BQL.BqlDecimal.Field<usrTrendingQty> { }
        #endregion
    }
}